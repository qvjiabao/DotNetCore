
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.IRepository
{
    public interface IJDItineraryCostRepository
    {

        /// <summary>
        /// 获取所有行程金额
        /// </summary>
        /// <returns></returns>
        IEnumerable<JDItineraryCostModel> GetAllJDItineraryCosts(string where);

        /// <summary>
        /// 删除行程金额
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        int RemoveJDItineraryCostByCode(string code, string userName, string displayName);

        /// <summary>
        /// 新增行程金额
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int CreateJDItineraryCost(JDItineraryCostModel model);

        /// <summary>
        /// 编辑行程金额
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int UpdateJDItineraryCost(JDItineraryCostModel model);

        /// <summary>
        /// 检查行程金额是否存在
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        bool ExistxJDItineraryCost(string jDItineraryCode, string carTypeCode, string relationCode = "");

        /// <summary>
        /// 根据编码获取行程金额
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        JDItineraryCostModel GetJDItineraryCostByCode(string relationCode);
    }
}
