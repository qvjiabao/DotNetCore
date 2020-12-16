using QJB.IRepository;
using QJB.IServices;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QJB.ImplService
{
    public class JDItinerayService : IJDItineraryService
    {

        private readonly IJDItineraryRepository _jDItinerayRepository;

        public JDItinerayService(IJDItineraryRepository jDItinerayRepository)
        {
            _jDItinerayRepository = jDItinerayRepository;
        }
        public bool ExistxJDItinerary(string departure, string terminal, string itineraryCode = "")
        {
            return _jDItinerayRepository.ExistxJDItinerary(departure, terminal, itineraryCode);
        }

        public IEnumerable<JDItineraryModel> GetAllJDItinerarys()
        {
            var list = _jDItinerayRepository.GetAllJDItinerarys(string.Empty);

            return list;
        }

        public IEnumerable<JDItineraryModel> GetAllJDItinerarys(string departure, string terminal)
        {
            var sql = string.Empty;

            if (!string.IsNullOrWhiteSpace(departure))
            {
                sql = $" and  Departure like '%{departure}%' ";
            }

            if (!string.IsNullOrWhiteSpace(terminal))
            {
                sql = $" and  Terminal like '%{terminal}%' ";
            }

            var list = _jDItinerayRepository.GetAllJDItinerarys(sql);

            return list;
        }

        public IEnumerable<JDItineraryModel> GetTerminalByDeparture(string departure)
        {
            var sql = string.Empty;

            if (!string.IsNullOrWhiteSpace(departure))
            {
                sql = $" and  Departure = '{departure}' ";
            }

            var list = _jDItinerayRepository.GetAllJDItinerarys(sql);

            return list;
        }

        public JDItineraryModel GetJDItineraryByCode(string itineraryCode)
        {
            return _jDItinerayRepository.GetJDItineraryByCode(itineraryCode);
        }

        public bool RemoveJDItineraryByCode(IEnumerable<JDItineraryModel> list, string userName, string displayName)
        {
            if (list.Count() == 0) return false;

            var str = list.Aggregate(string.Empty, (s, n) => s += $",'{n.JDItineraryCode}'");

            return _jDItinerayRepository.RemoveJDItineraryByCode(str.Substring(1), userName, displayName) > 0;
        }

        public bool SaveJDItinerary(JDItineraryModel itineraryModel)
        {
            if (string.IsNullOrWhiteSpace(itineraryModel.JDItineraryCode))
            {
                itineraryModel.JDItineraryCode = Guid.NewGuid().ToString();

                return _jDItinerayRepository.CreateJDItinerary(itineraryModel) > 0;
            }
            else
            {
                var model = _jDItinerayRepository.GetJDItineraryByCode(itineraryModel.JDItineraryCode);
                model.Departure = itineraryModel.Departure;
                model.Terminal = itineraryModel.Terminal;
                model.Mileage = itineraryModel.Mileage;
                model.ModifyDate = itineraryModel.ModifyDate;
                model.ModifyDisplayName = itineraryModel.ModifyDisplayName;
                model.ModifyUserName = itineraryModel.ModifyUserName;

                return _jDItinerayRepository.UpdateJDItinerary(model) > 0;
            }
        }
    }
}
