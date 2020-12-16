using QJB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.IServices
{
    public interface IOrderZWYSService
    {
        /// <summary>
        /// 检查订单编号是否存在
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        bool ExistsOrderNo(string orderNo, int orderId);

        /// <summary>
        /// 保存植物医生订单
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        bool SaveOrderZWYS(OrderZWYSModel order);

        /// <summary>
        /// 根据编码获取植物医生订单
        /// </summary>
        /// <returns></returns>
        OrderZWYSModel GetOrderZWYSByOrderNo(string orderNo);

        /// <summary>
        /// 获取所有植物医生订单
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        IEnumerable<OrderZWYSModel> GetAllOrderZWYSs(string franchiseStore, string orderNo, string cYBNo, string pickupDate, string recipient, string signatory, string signDate);

        /// <summary>
        /// 获取所有专营店号
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        IEnumerable<OrderZWYSModel> GetOrderZWYSByFranchiseStore(string franchiseStore);

        /// <summary>
        /// 删除植物医生订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        bool RemoveOrderZWYSByOrderNo(IEnumerable<OrderZWYSModel> list, string userName, string displayName);

        /// <summary>
        /// 结算订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        bool SettleState(IEnumerable<OrderZWYSModel> list, string userName, string displayName);

    }
}
