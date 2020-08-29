using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using Jabo.Core.Result;
using Jabo.Core.ViewModels;
using Jabo.IServices;
using Jabo.Models;
using Jabo.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml;

namespace Jabo.Core.Controllers
{

    /// <summary>
    /// 京东订单
    /// </summary>
     
    public class OrderJDController : BaseController
    {
        private readonly IOrderJDService _orderJDService;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _hostEnvironment;

        public OrderJDController(IMapper mapper, IOrderJDService orderJDService, IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _orderJDService = orderJDService;
            _mapper = mapper;
        }

        public IActionResult OrderJDView()
        {
            return View();
        }
        public IActionResult OrderJDSave()
        {
            return View();
        }
        public IActionResult OrderList()
        {
            return View();
        }
        public IActionResult OrderJDOilTopupList()
        {
            return View();
        }

        /// <summary>
        /// excel导出功能
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FileResult Export(string projectCode, string orderNo, string carNo, string sealNo, string departure, string terminal, string orderDate)
        {
            var list = _orderJDService.GetAllOrderJDs(projectCode, orderNo, carNo, sealNo, departure, terminal, orderDate);

            var path = _hostEnvironment.ContentRootPath + "/TempFiles/jd_model.xlsx";

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
                    sheet.Cells[pos, 2].Value = item.ProjectName;
                    sheet.Cells[pos, 3].Value = Convert.ToDateTime(item.OrderDate).ToString("yyyy-MM-dd");
                    sheet.Cells[pos, 4].Value = item.StartTime;
                    sheet.Cells[pos, 5].Value = item.EndTime;
                    sheet.Cells[pos, 6].Value = item.OrderNo;
                    sheet.Cells[pos, 7].Value = item.SealNo;
                    sheet.Cells[pos, 8].Value = item.CarNo;
                    sheet.Cells[pos, 9].Value = item.Driver;
                    sheet.Cells[pos, 10].Value = item.Departure;
                    sheet.Cells[pos, 11].Value = item.Terminal;
                    sheet.Cells[pos, 12].Value = item.CarTypeName;
                    sheet.Cells[pos, 13].Value = item.Beats;
                    sheet.Cells[pos, 14].Value = item.Mileage;
                    sheet.Cells[pos, 15].Value = item.HighspeedCharge;
                    sheet.Cells[pos, 16].Value = item.Cost;
                    sheet.Cells[pos, 17].Value = item.Rebate;
                    sheet.Cells[pos, 18].Value = item.Freight;
                    sheet.Cells[pos, 19].Value = item.OilCardBalance;
                    sheet.Cells[pos, 20].Value = item.Kilometers;
                    sheet.Cells[pos, 21].Value = item.OilCardTopup;
                    sheet.Cells[pos, 22].Value = item.OilCardUse;
                    sheet.Cells[pos, 23].Value = item.Repairfee;
                    sheet.Cells[pos, 24].Value = item.Fine;
                    sheet.Cells[pos, 25].Value = item.SuTongCard;
                    sheet.Cells[pos, 26].Value = item.Paycash;
                    sheet.Cells[pos, 27].Value = Convert.ToBoolean(item.SettleState) ? "是" : "否";

                    using (ExcelRange range = sheet.Cells[pos, 1, pos, 27])
                    {
                        range.Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                        range.Style.Border.Bottom.Color.SetColor(Color.Black);
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                    }

                    pos++;
                    index++;
                }
                #endregion

                var fileName = "燕翔外仓车辆明细" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                return File(package.GetAsByteArray(), AppConfigurtaion.Configuration["FileContentType"], fileName);
            }
        }

        [HttpGet]
        public OrderJDVModel GetOrderJDByOrderNo(string orderNo)
        {
            var order = _orderJDService.GetOrderJDByOrderNo(HttpUtility.UrlDecode(orderNo));

            var vmodel = _mapper.Map<OrderJDVModel>(order);

            return vmodel;
        }

        /// <summary>
        /// 获取植物医生订单分页列表
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="limit"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet]
        public Hashtable GetOilCardTopupLog(string carNo, int limit = 0, int page = 1)
        {

            if (string.IsNullOrEmpty(carNo))
                carNo = "无车牌号";

            var all = _orderJDService.GetOilCardTopupLog(carNo);

            var list = all.Skip((page - 1) * limit).Take(limit);

            var convertList = _mapper.Map<IEnumerable<OrderJDModel>, IEnumerable<OrderJDVModel>>(list);

            var tab = new Hashtable();

            tab["count"] = all.Count();

            tab["data"] = convertList;

            tab["code"] = "0";

            return tab;
        }

        [HttpPost]
        public JsonHttpActionResult SaveOrderJD(OrderJDModel order)
        {
            var j = new JsonHttpActionResult();
            var success = true;
            if (order.OrderId == 0)
            {
                //检查订单号是否存在
                if (order.OrderNo != "无单号")
                {
                    var checkOrderNo = _orderJDService.ExistsOrderNo(order.OrderNo, order.OrderId);
                    if (checkOrderNo)
                        return j.ErrorMessage("订单号已存在");
                }
                order.CreateDate = DateTime.Now;
                order.CreateUserName = UserInfo.UserName;
                order.CreateDisplayName = UserInfo.DisplayName;
                order.IsDeleted = false;
                order.SettleState = false;
            }
            else
            {
                if (order.OrderNo != "无单号")
                {
                    //检查订单号是否存在
                    var checkOrderNo = _orderJDService.ExistsOrderNo(order.OrderNo, order.OrderId);
                    if (checkOrderNo)
                        return j.ErrorMessage("订单号已存在");
                }
                order.ModifyDate = DateTime.Now;
                order.ModifyUserName = UserInfo.UserName;
                order.ModifyDisplayName = UserInfo.DisplayName;
            }

            success = _orderJDService.SaveOrderJD(order);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpPost]
        public JsonHttpActionResult SettleState(IEnumerable<OrderJDModel> list)
        {
            var j = new JsonHttpActionResult();

            if (list.Count() == 0)
            {
                return j.ErrorMessage("请选择要结算的订单");
            }

            var user = UserInfo;

            var success = _orderJDService.SettleState(list, user.UserName, user.DisplayName);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpPost]
        public JsonHttpActionResult RemoveOrderJDByCode(IEnumerable<OrderJDModel> list)
        {
            var j = new JsonHttpActionResult();

            if (list.Count() == 0)
            {
                return j.ErrorMessage("请选择要删除的订单");
            }

            var user = UserInfo;

            var success = _orderJDService.RemoveOrderJDByOrderNo(list, user.UserName, user.DisplayName);

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
        public Hashtable GetOrderJDPage(string projectCode, string orderNo, string carNo, string sealNo, string departure, string terminal, string orderDate
            , int limit = 0, int page = 1)
        {
            var all = _orderJDService.GetAllOrderJDs(projectCode, orderNo, carNo, sealNo, departure, terminal, orderDate);

            var list = all.Skip((page - 1) * limit).Take(limit);

            var convertList = _mapper.Map<IEnumerable<OrderJDModel>, IEnumerable<OrderJDVModel>>(list);

            var tab = new Hashtable();

            tab["count"] = all.Count();

            tab["data"] = convertList;

            tab["code"] = "0";

            return tab;
        }
    }
}