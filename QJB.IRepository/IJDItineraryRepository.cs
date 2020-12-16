using QJB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.IRepository
{
    public interface IJDItineraryRepository
    {

        /// <summary>
        /// 获取所有行程
        /// </summary>
        /// <returns></returns>
        IEnumerable<JDItineraryModel> GetAllJDItinerarys(string where);

        /// <summary>
        /// 删除行程
        /// </summary>
        /// <param name="itineraryCode"></param>
        /// <returns></returns>
        int RemoveJDItineraryByCode(string itineraryCode, string userName, string displayName);

        /// <summary>
        /// 新增行程
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int CreateJDItinerary(JDItineraryModel role);

        /// <summary>
        /// 编辑行程
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int UpdateJDItinerary(JDItineraryModel role);

        /// <summary>
        /// 检查行程名是否存在
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        bool ExistxJDItinerary(string departure, string terminal, string itineraryCode = "");

        /// <summary>
        /// 根据编码获取行程
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        JDItineraryModel GetJDItineraryByCode(string itineraryCode);
    }
}
