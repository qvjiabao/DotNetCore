using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
    [Authorize]
    public class OrderJDController : BaseController
    {
        private readonly IOrderJDService _orderZWYSService;
        private readonly IMapper _mapper;
        private readonly IHostEnvironment _hostEnvironment;

        public OrderJDController(IMapper mapper, IOrderJDService orderZWYSService, IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
            _orderZWYSService = orderZWYSService;
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

        /// <summary>
        /// excel导出功能
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FileResult Export(string projectCode, string orderNo, string carNo, string sealNo, string departure, string terminal, string orderDate)
        {
            var list = _orderZWYSService.GetAllOrderJDs(projectCode, orderNo, carNo, sealNo, departure, terminal, orderDate);

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

                var fileName = "燕翔外仓车辆明细" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx";

                return File(package.GetAsByteArray(), AppConfigurtaion.Configuration["FileContentType"], fileName);
            }
        }

        [HttpGet]
        public OrderJDVModel GetOrderJDByOrderNo(string orderNo)
        {
            var order = _orderZWYSService.GetOrderJDByOrderNo(orderNo);

            var vmodel = _mapper.Map<OrderJDVModel>(order);

            return vmodel;
        }
        [HttpPost]
        public JsonHttpActionResult SaveOrderJD(OrderJDModel order)
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

            success = _orderZWYSService.SaveOrderJD(order);

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

            var success = _orderZWYSService.SettleState(list, user.UserName, user.DisplayName);

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

            var success = _orderZWYSService.RemoveOrderJDByOrderNo(list, user.UserName, user.DisplayName);

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
            var all = _orderZWYSService.GetAllOrderJDs(projectCode, orderNo, carNo, sealNo, departure, terminal, orderDate);

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