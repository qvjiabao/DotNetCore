using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IServices
{
    public interface IOrderJDService
    {
        /// <summary>
        /// 检查订单编号是否存在
        /// </summary>
        /// <param name="orderNo"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        bool ExistsOrderNo(string orderNo, int orderId);

        /// <summary>
        /// 保存京东订单
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        bool SaveOrderJD(OrderJDModel order);

        /// <summary>
        /// 根据编码获取京东订单
        /// </summary>
        /// <returns></returns>
        OrderJDModel GetOrderJDByOrderNo(string orderNo);

        /// <summary>
        /// 获取所有京东订单
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        IEnumerable<OrderJDModel> GetAllOrderJDs(string projectCode, string orderNo, string carNo, string sealNo, string departure, string terminal, string orderDate);

        /// <summary>
        /// 获取充值记录
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        IEnumerable<OrderJDModel> GetOilCardTopupLog(string carNo);

        /// <summary>
        /// 删除京东订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        bool RemoveOrderJDByOrderNo(IEnumerable<OrderJDModel> list, string userName, string displayName);

        /// <summary>
        /// 结算订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        bool SettleState(IEnumerable<OrderJDModel> list, string userName, string displayName);

    }
}
