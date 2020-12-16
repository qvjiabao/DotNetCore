using QJB.IRepository;
using QJB.IServices;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jabo.Services
{
    public class OrderJDService : IOrderJDService
    {
        private IOrderJDRepository _orderJDRepository;

        public OrderJDService(IOrderJDRepository orderJDRepository)
        {
            _orderJDRepository = orderJDRepository;
        }

        public bool ExistsOrderNo(string orderNo, int orderId)
        {
            return _orderJDRepository.ExistsOrderNo(orderNo, orderId);
        }

        public IEnumerable<OrderJDModel> GetAllOrderJDs(string projectCode, string orderNo, string carNo, string sealNo, string departure, string terminal, string orderDate)
        {
            var sql = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(projectCode))
            {
                sql.Append($" and  A.ProjectCode = '{projectCode}' ");
            }

            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                sql.Append($" and  A.OrderNo like '%{orderNo}%' ");
            }

            if (!string.IsNullOrWhiteSpace(carNo))
            {
                sql.Append($" and  A.CarNo like '%{carNo}%' ");
            }
            if (!string.IsNullOrWhiteSpace(sealNo))
            {
                sql.Append($" and  A.SealNo like '%{sealNo}%' ");
            }
            if (!string.IsNullOrWhiteSpace(departure))
            {
                sql.Append($" and  A.Departure like '%{departure}%' ");
            }
            if (!string.IsNullOrWhiteSpace(terminal))
            {
                sql.Append($" and  A.Terminal like '%{terminal}%' ");
            }
            if (!string.IsNullOrWhiteSpace(orderDate))
            {
                var dateArray = orderDate.Split('-');

                sql.Append($" and  A.OrderDate >= '{dateArray[0].Trim()}' and A.OrderDate <= '{dateArray[1].Trim()}'");
            }

            var list = _orderJDRepository.GetAllOrderJDs(sql.ToString());

            return list;
        }

        public IEnumerable<OrderJDModel> GetOilCardTopupLog(string carNo)
        {
            var sql = new StringBuilder();

            sql.Append($" and  A.CarNo = '{carNo}' and OilCardTopup > 0 ");

            var list = _orderJDRepository.GetAllOrderJDs(sql.ToString());

            return list;
        }

        public OrderJDModel GetOrderJDByOrderNo(string orderNo)
        {
            return _orderJDRepository.GetOrderJDByOrderNo(orderNo);
        }

        public bool RemoveOrderJDByOrderNo(IEnumerable<OrderJDModel> list, string userName, string displayName)
        {
            if (list.Count() == 0) return false;

            var str = list.Aggregate(string.Empty, (s, n) => s += $",'{n.OrderNo}'");

            return _orderJDRepository.RemoveOrderJDByOrderNo(str.Substring(1), userName, displayName) > 0;
        }

        public bool SaveOrderJD(OrderJDModel order)
        {
            if (order.OrderId == 0)
            {

                return _orderJDRepository.CreateOrderJD(order) > 0;
            }
            else
            {
                var model = _orderJDRepository.GetOrderJDByOrderNo(order.OrderNo);


                model.ProjectCode = order.ProjectCode;
                model.OrderNo = order.OrderNo;
                model.SealNo = order.SealNo;
                model.OrderDate = order.OrderDate;
                model.StartTime = order.StartTime;
                model.EndTime = order.EndTime;
                model.CarNo = order.CarNo;
                model.Driver = order.Driver;
                model.Departure = order.Departure;
                model.Terminal = order.Terminal;
                model.CarTypeCode = order.CarTypeCode;
                model.Beats = order.Beats;
                model.Mileage = order.Mileage;
                model.HighspeedCharge = order.HighspeedCharge;
                model.Cost = order.Cost;
                model.Rebate = order.Rebate;
                model.Freight = order.Freight;
                model.OilCardBalance = order.OilCardBalance;
                model.Kilometers = order.Kilometers;
                model.OilCardTopup = order.OilCardTopup;
                model.OilCardUse = order.OilCardUse;
                model.Repairfee = order.Repairfee;
                model.Fine = order.Fine;
                model.SuTongCard = order.SuTongCard;
                model.Paycash = order.Paycash;
                model.Remark = order.Remark;
                model.ModifyDate = order.ModifyDate;
                model.ModifyDisplayName = order.ModifyDisplayName;
                model.ModifyUserName = order.ModifyUserName;

                return _orderJDRepository.UpdateOrderJD(model) > 0;
            }
        }

        public bool SettleState(IEnumerable<OrderJDModel> list, string userName, string displayName)
        {
            if (list.Count() == 0) return false;

            var str = list.Aggregate(string.Empty, (s, n) => s += $",'{n.OrderNo}'");

            return _orderJDRepository.SettleState(str.Substring(1), userName, displayName) > 0;
        }
    }
}
