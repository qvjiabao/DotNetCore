using Jabo.IRepository;
using Jabo.IServices;
using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jabo.Services
{
    public class OrderZWYSService : IOrderZWYSService
    {
        private IOrderZWYSRepository _orderZWYSRepository;

        public OrderZWYSService(IOrderZWYSRepository orderZWYSRepository)
        {
            _orderZWYSRepository = orderZWYSRepository;
        }

        public bool ExistsOrderNo(string orderNo, int orderId)
        {
            return _orderZWYSRepository.ExistsOrderNo(orderNo, orderId);
        }

        public IEnumerable<OrderZWYSModel> GetAllOrderZWYSs(string orderNo, string cYBNo, string pickupDate, string recipient, string signatory, string signDate)
        {
            var sql = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(orderNo))
            {
                sql.Append($" and  OrderNo like '%{orderNo}%' ");
            }

            if (!string.IsNullOrWhiteSpace(cYBNo))
            {
                sql.Append($" and  CYBNo like '%{cYBNo}%' ");
            }
            if (!string.IsNullOrWhiteSpace(recipient))
            {
                sql.Append($" and  Recipient like '%{recipient}%' ");
            }
            if (!string.IsNullOrWhiteSpace(signatory))
            {
                sql.Append($" and  Signatory like '%{signatory}%' ");
            }
            if (!string.IsNullOrWhiteSpace(pickupDate))
            {
                var dateArray = pickupDate.Split(" - ");

                sql.Append($" and  PickupDate >= '{dateArray[0].Trim()}' and PickupDate <= '{dateArray[1].Trim()}'");
            }
            if (!string.IsNullOrWhiteSpace(signDate))
            {
                var dateArray = signDate.Split(" - ");

                sql.Append($" and  SignDate >= '{dateArray[0].Trim()}' and SignDate <= '{dateArray[1].Trim()}'");
            }

            var list = _orderZWYSRepository.GetAllOrderZWYSs(sql.ToString());

            return list;
        }

        public OrderZWYSModel GetOrderZWYSByOrderNo(string orderNo)
        {
            return _orderZWYSRepository.GetOrderZWYSByOrderNo(orderNo);
        }

        public bool RemoveOrderZWYSByOrderNo(IEnumerable<OrderZWYSModel> list, string userName, string displayName)
        {
            if (list.Count() == 0) return false;

            var str = list.Aggregate(string.Empty, (s, n) => s += $",'{n.OrderNo}'");

            return _orderZWYSRepository.RemoveOrderZWYSByOrderNo(str.Substring(1), userName, displayName) > 0;
        }

        public bool SaveOrderZWYS(OrderZWYSModel order)
        {
            if (order.OrderId == 0)
            {

                return _orderZWYSRepository.CreateOrderZWYS(order) > 0;
            }
            else
            {
                var model = _orderZWYSRepository.GetOrderZWYSByOrderNo(order.OrderNo);
                model.OrderNo = order.OrderNo;
                model.CYBNo = order.CYBNo;
                model.PickupDate = order.PickupDate;
                model.FranchiseStore = order.FranchiseStore;
                model.StoreStar = order.StoreStar;
                model.Recipient = order.Recipient;
                model.CityLevel = order.CityLevel;
                model.Phone = order.Phone;
                model.Address = order.Address;
                model.Pieces = order.Pieces;
                model.Signatory = order.Signatory;
                model.SignDate = order.SignDate;
                model.ProvinceCode = order.ProvinceCode;
                model.ProvinceName = order.ProvinceName;
                model.CityCode = order.CityCode;
                model.CityName = order.CityName;
                model.AreaCode = order.AreaCode;
                model.AreaName = order.AreaName;
                model.ModifyDate = model.ModifyDate;
                model.ModifyDisplayName = model.ModifyDisplayName;
                model.ModifyUserName = model.ModifyUserName;

                return _orderZWYSRepository.UpdateOrderZWYS(order) > 0;
            }
        }
    }
}
