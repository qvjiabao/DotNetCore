using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QJB.IServices;
using QJB.Models;
using QJB.Server.Controllers;
using QJB.Server.Result;
using QJB.Shared;
using QJB.Tools;

namespace QJB.Server.Controllers
{
    /// <summary>
    /// 植物医生订单
    /// </summary>

    public class OrderZWYSController : BaseController
    {
        private readonly IOrderZWYSService _orderZWYSService;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _hostEnvironment;

        public OrderZWYSController(IMapper mapper, IOrderZWYSService orderZWYSService, IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _orderZWYSService = orderZWYSService;
            _mapper = mapper;
        }

        //public IActionResult OrderZWYSView()
        //{
        //    return View();
        //}
        //public IActionResult OrderZWYSSave()
        //{
        //    return View();
        //}

        //public IActionResult OrderList()
        //{
        //    return View();
        //}

        //public IActionResult OrderZWYSMenuList()
        //{
        //    return View();
        //}

        /// <summary>
        /// excel导出功能
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FileResult Export(string franchiseStore, string orderNo, string cYBNo, string pickupDate, string recipient, string signatory, string signDate)
        {
            var list = _orderZWYSService.GetAllOrderZWYSs(franchiseStore, orderNo, cYBNo, pickupDate, recipient, signatory, signDate);

            var path = _hostEnvironment.ContentRootPath + "/TempFiles/zwys_model.xlsx";

            var file = new FileInfo(path);

            using (var package = new ExcelPackage(file))
            {
                OfficeOpenXml.ExcelWorksheet sheet = package.Workbook.Worksheets[0];

                #region write content
                int pos = 2;
                int index = 1;
                foreach (var item in list)
                {
                    sheet.Row(pos).Height = 20;//设置行高
                    sheet.Cells[pos, 1].Value = index;
                    sheet.Cells[pos, 2].Value = Convert.ToDateTime(item.PickupDate).ToString("yyyy-MM-dd");
                    sheet.Cells[pos, 3].Value = item.OrderNo;
                    sheet.Cells[pos, 4].Value = item.CYBNo;
                    sheet.Cells[pos, 5].Value = item.FranchiseStore;
                    sheet.Cells[pos, 6].Value = item.StoreStar;
                    sheet.Cells[pos, 7].Value = item.Recipient;
                    sheet.Cells[pos, 8].Value = item.ProvinceName;
                    sheet.Cells[pos, 9].Value = item.CityName;
                    sheet.Cells[pos, 10].Value = item.AreaName;
                    sheet.Cells[pos, 11].Value = item.CityLevel;
                    sheet.Cells[pos, 12].Value = item.Phone;
                    sheet.Cells[pos, 13].Value = item.Address;
                    sheet.Cells[pos, 14].Value = item.Pieces;
                    sheet.Cells[pos, 15].Value = item.Signatory;
                    sheet.Cells[pos, 16].Value = Convert.ToDateTime(item.SignDate).ToString("yyyy-MM-dd");
                    sheet.Cells[pos, 17].Value = item.Remark;
                    sheet.Cells[pos, 18].Value = Convert.ToBoolean(item.SettleState) ? "是" : "否";

                    using (ExcelRange range = sheet.Cells[pos, 1, pos, 18])
                    {
                        range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Color.SetColor(Color.Black);
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    }

                    pos++;
                    index++;
                }
                #endregion

                var fileName = "植物医生" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                return File(package.GetAsByteArray(), AppConfigurtaion.Configuration["FileContentType"], fileName);
            }
        }

        [HttpGet]
        public OrderZWYSVModel GetOrderZWYSByOrderNo(string orderNo)
        {
            var order = _orderZWYSService.GetOrderZWYSByOrderNo(orderNo);

            var vmodel = _mapper.Map<OrderZWYSVModel>(order);

            return vmodel;
        }
        [HttpPost]
        public JsonHttpActionResult SaveOrderZWYS(OrderZWYSModel order)
        {
            var j = new JsonHttpActionResult();
            var success = true;
            if (order.OrderId == 0)
            {
                //检查订单号是否存在
                var checkOrderNo = _orderZWYSService.ExistsOrderNo(order.OrderNo, order.OrderId);
                if (checkOrderNo)
                    return j.ErrorMessage("订单号已存在");
                order.CreateDate = DateTime.Now;
                order.CreateUserName = UserInfo.UserName;
                order.CreateDisplayName = UserInfo.DisplayName;
                order.IsDeleted = false;
                order.SettleState = false;
            }
            else
            {
                //检查订单号是否存在
                var checkOrderNo = _orderZWYSService.ExistsOrderNo(order.OrderNo, order.OrderId);
                if (checkOrderNo)
                    return j.ErrorMessage("订单号已存在");
                order.ModifyDate = DateTime.Now;
                order.ModifyUserName = UserInfo.UserName;
                order.ModifyDisplayName = UserInfo.DisplayName;
            }

            success = _orderZWYSService.SaveOrderZWYS(order);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        /// <summary>
        /// 获取植物医生订单分页列表
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public Hashtable GetOrderZWYSByFranchiseStore(string franchiseStore, int limit = 10, int page = 1)
        {
            var all = _orderZWYSService.GetOrderZWYSByFranchiseStore(franchiseStore);

            var list = all.Skip((page - 1) * limit).Take(limit);

            var convertList = _mapper.Map<IEnumerable<OrderZWYSModel>, IEnumerable<OrderZWYSVModel>>(list);

            var tab = new Hashtable();

            tab["count"] = all.Count();

            tab["data"] = convertList;

            tab["code"] = "0";

            return tab;
        }

        [HttpPost]
        public JsonHttpActionResult SettleState(IEnumerable<OrderZWYSModel> list)
        {
            var j = new JsonHttpActionResult();

            if (list.Count() == 0)
            {
                return j.ErrorMessage("请选择要结算的订单");
            }

            var user = UserInfo;

            var success = _orderZWYSService.SettleState(list, user.UserName, user.DisplayName);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpPost]
        public JsonHttpActionResult RemoveOrderZWYSByCode(IEnumerable<OrderZWYSModel> list)
        {
            var j = new JsonHttpActionResult();

            if (list.Count() == 0)
            {
                return j.ErrorMessage("请选择要删除的订单");
            }

            var user = UserInfo;

            var success = _orderZWYSService.RemoveOrderZWYSByOrderNo(list, user.UserName, user.DisplayName);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        /// <summary>
        /// 获取植物医生订单分页列表
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public Hashtable GetOrderZWYSPage(string franchiseStore, string orderNo, string cYBNo, string pickupDate, string recipient, string signatory, string signDate
            , int limit = 0, int page = 1)
        {
            var all = _orderZWYSService.GetAllOrderZWYSs(franchiseStore, orderNo, cYBNo, pickupDate, recipient, signatory, signDate);

            var list = all.Skip((page - 1) * limit).Take(limit);

            var convertList = _mapper.Map<IEnumerable<OrderZWYSModel>, IEnumerable<OrderZWYSVModel>>(list);

            var tab = new Hashtable();

            tab["count"] = all.Count();

            tab["data"] = convertList;

            tab["code"] = "0";

            return tab;
        }
    }
}