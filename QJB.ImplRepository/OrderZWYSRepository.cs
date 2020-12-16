using Dapper;
using QJB.Dapper;
using QJB.ImplRepository;
using QJB.IRepository;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QJB.ImplRepository
{
    public class OrderZWYSRepository : BaseRepository, IOrderZWYSRepository
    {
        public int CreateOrderZWYS(OrderZWYSModel order)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Insert<OrderZWYSModel>(order);

                return (int)count;
            }
        }

        public bool ExistsOrderNo(string orderNo, int orderId)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                if (orderId == 0)
                {
                    var model = connection.GetList<OrderZWYSModel>("where IsDeleted = 0 and orderNo = @orderNo ",
                        new { orderNo = orderNo }).FirstOrDefault();

                    return model != null;
                }
                else
                {
                    var model = connection.GetList<OrderZWYSModel>("where IsDeleted = 0 and orderNo = @orderNo and OrderId <> @orderId",
                        new { orderNo = orderNo, orderId = orderId }).FirstOrDefault();

                    return model != null;
                }
            }
        }

        /// <summary>
        /// 获取字段集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public IEnumerable<OrderZWYSModel> GetOrderZWYSByFranchiseStore(string where, string fieldName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.Query<OrderZWYSModel>(" select distinct " + fieldName + " from YX_OrderZWYS  where IsDeleted = 0  " + where);

                return list;
            }
        }

        public IEnumerable<OrderZWYSModel> GetAllOrderZWYSs(string where)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.GetList<OrderZWYSModel>("where IsDeleted = 0 " + where + " order by CreateDate desc");

                return list;
            }
        }

        public OrderZWYSModel GetOrderZWYSByOrderNo(string orderNo)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var model = connection.GetList<OrderZWYSModel>("where IsDeleted = 0 and OrderNo = @orderNo ",
                    new { orderNo = orderNo }).FirstOrDefault();

                return model;
            }
        }

        public int RemoveOrderZWYSByOrderNo(string orderNo, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute($@" UPDATE YX_OrderZWYS SET IsDeleted = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where OrderNo in ({orderNo})", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now });

                return count;
            }
        }

        public int UpdateOrderZWYS(OrderZWYSModel role)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Update<OrderZWYSModel>(role);

                return count;
            }
        }

        public int SettleState(string orderNo, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute($@" UPDATE YX_OrderZWYS SET SettleState = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where OrderNo in ({orderNo})", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now });

                return count;
            }
        }
    }
}
