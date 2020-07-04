using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jabo.Core.Result;
using Jabo.Core.ViewModels;
using Jabo.IServices;
using Jabo.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public OrderZWYSVModel GetOrderZWYSByOrderNo(string orderNo)
        {
            var order = _orderZWYSService.GetOrderZWYSByOrderNo(orderNo);

            var vmodel = _mapper.Map<OrderZWYSVModel>(order);

            return vmodel;
        }
        [HttpPost]
        public JsonHttpActionResult SaveOrderZWYSMenu(OrderZWYSModel order)
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


        [HttpPost]
        public JsonHttpActionResult RemoveOrderZWYSByCode(IEnumerable<OrderZWYSModel> list)
        {
            var j = new JsonHttpActionResult();

            if (list.Count() == 0)
            {
                return j.ErrorMessage("请选择要删除的植物医生订单");
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
        public Hashtable GetOrderZWYSPage(string orderNo, string cYBNo, string pickupDate, string recipient, string signatory, string signDate
            , int limit = 0, int page = 1)
        {
            var all = _orderZWYSService.GetAllOrderZWYSs(orderNo, cYBNo,pickupDate, recipient, signatory, signDate);

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