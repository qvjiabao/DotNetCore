﻿using QJB.IRepository;
using QJB.IServices;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QJB.ImplService
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

        public IEnumerable<OrderZWYSModel> GetAllOrderZWYSs(string franchiseStore, string orderNo, string cYBNo, string pickupDate, string recipient, string signatory, string signDate)
        {
            var sql = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(franchiseStore))
            {
                sql.Append($" and  FranchiseStore like '%{franchiseStore}%' ");
            }

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
                var dateArray = pickupDate.Split('-');

                sql.Append($" and  PickupDate >= '{dateArray[0].Trim()}' and PickupDate <= '{dateArray[1].Trim()}'");
            }
            if (!string.IsNullOrWhiteSpace(signDate))
            {
                var dateArray = signDate.Split('-');

                sql.Append($" and  SignDate >= '{dateArray[0].Trim()}' and SignDate <= '{dateArray[1].Trim()}'");
            }

            var list = _orderZWYSRepository.GetAllOrderZWYSs(sql.ToString());

            return list;
        }

        public IEnumerable<OrderZWYSModel> GetOrderZWYSByFranchiseStore(string franchiseStore)
        {
            var sql = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(franchiseStore))
            {
                sql.Append($" and  FranchiseStore like '%{franchiseStore}%' ");
            }

            var list = _orderZWYSRepository.GetOrderZWYSByFranchiseStore(sql.ToString(), "FranchiseStore");

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
                model.Remark = order.Remark;
                model.ModifyDate = order.ModifyDate;
                model.ModifyDisplayName = order.ModifyDisplayName;
                model.ModifyUserName = order.ModifyUserName;

                return _orderZWYSRepository.UpdateOrderZWYS(model) > 0;
            }
        }

        public bool SettleState(IEnumerable<OrderZWYSModel> list, string userName, string displayName)
        {
            if (list.Count() == 0) return false;

            var str = list.Aggregate(string.Empty, (s, n) => s += $",'{n.OrderNo}'");

            return _orderZWYSRepository.SettleState(str.Substring(1), userName, displayName) > 0;
        }
    }
}
