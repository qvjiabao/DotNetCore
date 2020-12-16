using QJB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.IServices
{
    public interface IJDItineraryService
    {

        /// <summary>
        /// 检查行程是否存在
        /// </summary>
        /// <param name="departure"></param>
        /// <param name="terminal"></param>
        /// <param name="itineraryCode"></param>
        /// <returns></returns>
        bool ExistxJDItinerary(string departure, string terminal, string itineraryCode = "");

        /// <summary>
        /// 保存行程
        /// </summary>
        /// <param name="itineraryModel"></param>
        /// <returns></returns>
        bool SaveJDItinerary(JDItineraryModel itineraryModel);

        /// <summary>
        /// 根据编码获取行程
        /// </summary>
        /// <returns></returns>
        JDItineraryModel GetJDItineraryByCode(string itineraryCode);

        /// <summary>
        /// 获取所有行程
        /// </summary>
        /// <returns></returns>
        IEnumerable<JDItineraryModel> GetAllJDItinerarys();

        /// <summary>
        /// 根据行程获取目的地
        /// </summary>
        /// <param name="departure"></param>
        /// <returns></returns>
        IEnumerable<JDItineraryModel> GetTerminalByDeparture(string departure);

        /// <summary>
        /// 获取所有行程
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        IEnumerable<JDItineraryModel> GetAllJDItinerarys(string departure, string terminal);

        /// <summary>
        /// 删除行程
        /// </summary>
        /// <param name="itineraryCode"></param>
        /// <returns></returns>
        bool RemoveJDItineraryByCode(IEnumerable<JDItineraryModel> list, string userName, string displayName);
    }
}
