using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IRepository
{
    public interface IOrderZWYSRepository
    {
        /// <summary>
        /// 获取所有植物医生订单
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrderZWYSModel> GetAllOrderZWYSs(string where);

        /// <summary>
        /// 删除植物医生订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int RemoveOrderZWYSByOrderNo(string orderNo, string userName, string displayName);

        /// <summary>
        /// 结算订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int SettleState(string orderNo, string userName, string displayName);

        /// <summary>
        /// 获取字段集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        IEnumerable<OrderZWYSModel> GetOrderZWYSByFranchiseStore(string where, string fieldName);

        /// <summary>
        /// 新增植物医生订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int CreateOrderZWYS(OrderZWYSModel order);

        /// <summary>
        /// 编辑植物医生订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int UpdateOrderZWYS(OrderZWYSModel order);

        /// <summary>
        /// 检查植物医生订单编号是否存在
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        bool ExistsOrderNo(string orderNo, int orderId);

        /// <summary>
        /// 根据订单编号获取订单
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        OrderZWYSModel GetOrderZWYSByOrderNo(string orderNo);
    }
}
