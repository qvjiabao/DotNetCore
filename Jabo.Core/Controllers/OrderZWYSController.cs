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
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Jabo.Core.Controllers
{
    /// <summary>
    /// 植物医生订单
    /// </summary>
    public class OrderZWYSController : BaseController
    {
        private readonly IOrderZWYSService _orderZWYSService;
        private readonly IMapper _mapper;

        public OrderZWYSController(IMapper mapper, IOrderZWYSService orderZWYSService)
        {
            _orderZWYSService = orderZWYSService;
            _mapper = mapper;
        }

        public IActionResult OrderZWYSView()
        {
            return View();
        }
        public IActionResult OrderZWYSSave()
        {
            return View();
        }

        public IActionResult OrderList()
        {
            return View();
        }

        public IActionResult OrderZWYSMenuList()
        {
            return View();
        }

        /// <summary>
        /// excel导出功能
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Export(string franchiseStore, string orderNo, string cYBNo, string pickupDate, string recipient, string signatory, string signDate)
        {
            var list = _orderZWYSService.GetAllOrderZWYSs(franchiseStore, orderNo, cYBNo, pickupDate, recipient, signatory, signDate);

            using (var package = new ExcelPackage())
            {
                OfficeOpenXml.ExcelWorksheet sheet = package.Workbook.Worksheets.Add("订单信息");

                sheet.Row(1).Height = 22;//设置行高

                sheet.Column(1).Width = 8;//设置列宽
                sheet.Column(2).Width = 15;//设置列宽
                sheet.Column(3).Width = 20;//设置列宽
                sheet.Column(4).Width = 25;//设置列宽
                sheet.Column(5).Width = 30;//设置列宽
                sheet.Column(6).Width = 10;//设置列宽
                sheet.Column(7).Width = 10;//设置列宽
                sheet.Column(8).Width = 10;//设置列宽
                sheet.Column(9).Width = 10;//设置列宽
                sheet.Column(10).Width = 10;//设置列宽
                sheet.Column(11).Width = 10;//设置列宽
                sheet.Column(12).Width = 15;//设置列宽
                sheet.Column(13).Width = 100;//设置列宽
                sheet.Column(14).Width = 10;//设置列宽
                sheet.Column(15).Width = 10;//设置列宽
                sheet.Column(16).Width = 10;//设置列宽
                sheet.Column(17).Width = 50;//设置列宽
                sheet.Column(18).Width = 8;//设置列宽

                #region write header
                sheet.Cells[1, 1].Value = "序号";
                sheet.Cells[1, 2].Value = "提货日期";
                sheet.Cells[1, 3].Value = "订单号";
                sheet.Cells[1, 4].Value = "仓易宝单号";
                sheet.Cells[1, 5].Value = "专营店号";
                sheet.Cells[1, 6].Value = "门店星级";
                sheet.Cells[1, 7].Value = "收件人";
                sheet.Cells[1, 8].Value = "省份";
                sheet.Cells[1, 9].Value = "城市";
                sheet.Cells[1, 10].Value = "区县";
                sheet.Cells[1, 11].Value = "城市等级";
                sheet.Cells[1, 12].Value = "电话";
                sheet.Cells[1, 13].Value = "收货地址";
                sheet.Cells[1, 14].Value = "件数";
                sheet.Cells[1, 15].Value = "签收人";
                sheet.Cells[1, 16].Value = "签收日期";
                sheet.Cells[1, 17].Value = "备注";
                sheet.Cells[1, 18].Value = "结算";

                using (ExcelRange range = sheet.Cells[1, 1, 1, 18])
                {
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;//水平居中
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;//垂直居中
                    range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Cyan);
                }
                #endregion

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

                package.Save();

                return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "植物医生" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xlsx");
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
        public Hashtable GetOrderZWYSByFranchiseStore(string franchiseStore, int limit = 0, int page = 1)
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