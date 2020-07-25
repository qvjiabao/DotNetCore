using Dapper;
using Jabo.Dapper;
using Jabo.IRepository;
using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jabo.Repository
{
    public class OrderJDRepository : BaseRepository, IOrderJDRepository
    {
        public int CreateOrderJD(OrderJDModel order)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Insert<OrderJDModel>(order);

                return (int)count;
            }
        }

        public bool ExistsOrderNo(string orderNo, int orderId)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                if (orderId == 0)
                {
                    var model = GetOrderJDByOrderNo(orderNo);

                    return model != null;
                }
                else
                {
                    var sql = @"select A.*,B.DicName AS ProjectName,C.DicName AS CarTypeName from YX_OrderJD A 
                        inner join YX_Dic B on A.ProjectCode = B.DicCode
                        inner join YX_Dic C on A.CarTypeCode = C.DicCode
                        where A.IsDeleted = 0 and orderNo = @orderNo and OrderId <> @orderId";

                    var model = connection.QueryFirstOrDefault<OrderJDModel>(sql, new { orderNo, orderId });

                    return model != null;
                }
            }
        }

        public IEnumerable<OrderJDModel> GetAllOrderJDs(string where)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var sql = @"select A.*,B.DicName AS ProjectName,C.DicName AS CarTypeName from YX_OrderJD A 
                    inner join YX_Dic B on A.ProjectCode = B.DicCode
                    inner join YX_Dic C on A.CarTypeCode = C.DicCode
                    where A.IsDeleted = 0 " + where + " Order By A.OrderDate desc";

                var list = connection.Query<OrderJDModel>(sql);

                return list;
            }
        }

        public OrderJDModel GetOrderJDByOrderNo(string orderNo)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {

                var sql = @"select A.*,B.DicName AS ProjectName,C.DicName AS CarTypeName from YX_OrderJD A 
                        inner join YX_Dic B on A.ProjectCode = B.DicCode
                        inner join YX_Dic C on A.CarTypeCode = C.DicCode
                        where A.IsDeleted = 0 and orderNo = @orderNo";

                var model = connection.QueryFirstOrDefault<OrderJDModel>(sql, new { orderNo });

                return model;
            }
        }

        public int RemoveOrderJDByOrderNo(string orderNo, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute(@$" UPDATE YX_OrderJD SET IsDeleted = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where OrderNo in ({orderNo})", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now });

                return count;
            }
        }

        public int UpdateOrderJD(OrderJDModel role)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Update<OrderJDModel>(role);

                return count;
            }
        }

        public int SettleState(string orderNo, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute(@$" UPDATE YX_OrderJD SET SettleState = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where OrderNo in ({orderNo})", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now });

                return count;
            }
        }
    }
}
