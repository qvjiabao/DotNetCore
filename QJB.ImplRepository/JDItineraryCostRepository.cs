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
    public class JDItineraryCostRepository : BaseRepository, IJDItineraryCostRepository
    {
        public int CreateJDItineraryCost(JDItineraryCostModel model)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Insert<JDItineraryCostModel>(model);

                return (int)count;
            }
        }

        public bool ExistxJDItineraryCost(string jDItineraryCode, string carTypeCode, string relationCode = "")
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                if (string.IsNullOrWhiteSpace(relationCode))
                {
                    var model = connection.GetList<JDItineraryCostModel>("where IsDeleted = 0 and JDItineraryCode = @jDItineraryCode and CarTypeCode = @carTypeCode  ",
                        new { jDItineraryCode, carTypeCode }).FirstOrDefault();

                    return model != null;
                }
                else
                {
                    var model = connection.GetList<JDItineraryCostModel>("where IsDeleted = 0 and JDItineraryCode = @jDItineraryCode and CarTypeCode = @carTypeCode  and RelationCode <> @relationCode",
                        new { jDItineraryCode, carTypeCode, relationCode }).FirstOrDefault();

                    return model != null;
                }
            }
        }

        public IEnumerable<JDItineraryCostModel> GetAllJDItineraryCosts(string where)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var sql = @"select RelationId,RelationCode,JDItineraryCode,CarTypeCode,DicName CarType,	
                    Cost,YX_JDItineraryCost.CreateDate
                from YX_JDItineraryCost
                inner join YX_Dic  on CarTypeCode = DicCode
                where YX_JDItineraryCost.IsDeleted = 0 " + where + " order by YX_JDItineraryCost.CreateDate desc";

                var list = connection.Query<JDItineraryCostModel>(sql);

                return list;
            }
        }

        public JDItineraryCostModel GetJDItineraryCostByCode(string relationCode)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var model = connection.GetList<JDItineraryCostModel>("where IsDeleted = 0 and RelationCode = @relationCode ",
                    new { relationCode }).FirstOrDefault();

                return model;
            }
        }

        public int RemoveJDItineraryCostByCode(string relationCode, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute($@" UPDATE YX_JDItineraryCost SET IsDeleted = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where RelationCode in ({relationCode})", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now });

                return count;
            }
        }

        public int UpdateJDItineraryCost(JDItineraryCostModel role)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Update<JDItineraryCostModel>(role);

                return count;
            }
        }
    }
}
