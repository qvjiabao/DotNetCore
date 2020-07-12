using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IServices
{
    public interface IJDItineraryCostService
    {

        /// <summary>
        /// 检查行程金额是否存在
        /// </summary>
        /// <param name="jDItineraryCode"></param>
        /// <param name="carTypeCode"></param>
        /// <param name="relationCode"></param>
        /// <returns></returns>
        bool ExistxJDItineraryCost(string jDItineraryCode, string carTypeCode, string relationCode = "");

        /// <summary>
        /// 保存行程金额
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool SaveJDItineraryCost(JDItineraryCostModel model);

        /// <summary>
        /// 根据编码获取行程金额
        /// </summary>
        /// <returns></returns>
        JDItineraryCostModel GetJDItineraryCostByCode(string relationCode);

        /// <summary>
        /// 获取所有行程金额
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        IEnumerable<JDItineraryCostModel> GetAllJDItineraryCosts(string jDItineraryCode);

        /// <summary>
        /// 删除行程金额
        /// </summary>
        /// <param name="itineraryCode"></param>
        /// <returns></returns>
        bool RemoveJDItineraryCostByCode(IEnumerable<JDItineraryCostModel> list, string userName, string displayName);
    }
}
