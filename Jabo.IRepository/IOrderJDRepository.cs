using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IRepository
{
    public interface IOrderJDRepository
    {
        /// <summary>
        /// 获取所有京东订单
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderJDModel> GetAllOrderJDs(string where);

        /// <summary>
        /// 删除京东订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int RemoveOrderJDByOrderNo(string orderNo, string userName, string displayName);

        /// <summary>
        /// 结算订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int SettleState(string orderNo, string userName, string displayName);

        /// <summary>
        /// 新增京东订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int CreateOrderJD(OrderJDModel order);

        /// <summary>
        /// 编辑京东订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int UpdateOrderJD(OrderJDModel order);

        /// <summary>
        /// 检查京东订单编号是否存在
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        bool ExistsOrderNo(string orderNo, int orderId);

        /// <summary>
        /// 根据订单编号获取订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        OrderJDModel GetOrderJDByOrderNo(string orderNo);
    }
}
