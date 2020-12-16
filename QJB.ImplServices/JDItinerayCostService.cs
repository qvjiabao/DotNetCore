using QJB.IRepository;
using QJB.IServices;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QJB.ImplService
{
    public class JDItineraryCostService : IJDItineraryCostService
    {

        private readonly IJDItineraryCostRepository _jDItinerayRepository;

        public JDItineraryCostService(IJDItineraryCostRepository jDItinerayRepository)
        {
            _jDItinerayRepository = jDItinerayRepository;
        }
        public bool ExistxJDItineraryCost(string jDItineraryCode, string carTypeCode, string relationCode = "")
        {
            return _jDItinerayRepository.ExistxJDItineraryCost(jDItineraryCode, carTypeCode, relationCode);
        }

        public IEnumerable<JDItineraryCostModel> GetAllJDItineraryCosts(string jDItineraryCode)
        {
            var sql = string.Empty;

            if (!string.IsNullOrWhiteSpace(jDItineraryCode))
            {
                sql = $" and  JDItineraryCode = '{jDItineraryCode}' ";
            }

            var list = _jDItinerayRepository.GetAllJDItineraryCosts(sql);

            return list;
        }

        public JDItineraryCostModel GetJDItineraryCostByCode(string relationCode)
        {
            return _jDItinerayRepository.GetJDItineraryCostByCode(relationCode);
        }

        public bool RemoveJDItineraryCostByCode(IEnumerable<JDItineraryCostModel> list, string userName, string displayName)
        {
            if (list.Count() == 0) return false;

            var str = list.Aggregate(string.Empty, (s, n) => s += $",'{n.RelationCode}'");

            return _jDItinerayRepository.RemoveJDItineraryCostByCode(str.Substring(1), userName, displayName) > 0;
        }

        public bool SaveJDItineraryCost(JDItineraryCostModel costModel)
        {
            if (string.IsNullOrWhiteSpace(costModel.RelationCode))
            {
                costModel.RelationCode = Guid.NewGuid().ToString();

                return _jDItinerayRepository.CreateJDItineraryCost(costModel) > 0;
            }
            else
            {
                var model = _jDItinerayRepository.GetJDItineraryCostByCode(costModel.RelationCode);
                model.CarTypeCode = costModel.CarTypeCode;
                model.CarType = costModel.CarType;
                model.JDItineraryCode = costModel.JDItineraryCode;
                model.Cost = costModel.Cost;
                model.ModifyDate = costModel.ModifyDate;
                model.ModifyDisplayName = costModel.ModifyDisplayName;
                model.ModifyUserName = costModel.ModifyUserName;

                return _jDItinerayRepository.UpdateJDItineraryCost(model) > 0;
            }
        }
    }
}
