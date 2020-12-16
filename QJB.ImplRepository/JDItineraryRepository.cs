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
    public class JDItineraryRepository : BaseRepository, IJDItineraryRepository
    {
        public int CreateJDItinerary(JDItineraryModel role)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Insert<JDItineraryModel>(role);

                return (int)count;
            }
        }

        public bool ExistxJDItinerary(string departure, string terminal, string itineraryCode = "")
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                if (string.IsNullOrWhiteSpace(itineraryCode))
                {
                    var model = connection.GetList<JDItineraryModel>("where IsDeleted = 0 and Departure = @departure and Terminal = @terminal  ",
                        new { departure, terminal }).FirstOrDefault();

                    return model != null;
                }
                else
                {
                    var model = connection.GetList<JDItineraryModel>("where IsDeleted = 0 and Departure = @departure and Terminal = @terminal  and JDItineraryCode <> @itineraryCode",
                        new { departure, terminal, itineraryCode }).FirstOrDefault();

                    return model != null;
                }
            }
        }

        public IEnumerable<JDItineraryModel> GetAllJDItinerarys(string where)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.GetList<JDItineraryModel>("where IsDeleted = 0 " + where + " order by CreateDate desc");

                return list;
            }
        }

        public JDItineraryModel GetJDItineraryByCode(string itineraryCode)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var model = connection.GetList<JDItineraryModel>("where IsDeleted = 0 and JDItineraryCode = @itineraryCode ",
                    new { itineraryCode }).FirstOrDefault();

                return model;
            }
        }

        public int RemoveJDItineraryByCode(string itineraryCode, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute($@" UPDATE YX_JDItinerary SET IsDeleted = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where JDItineraryCode in ({itineraryCode})", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now });

                return count;
            }
        }

        public int UpdateJDItinerary(JDItineraryModel role)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Update<JDItineraryModel>(role);

                return count;
            }
        }
    }
}
