using QJB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.IRepository
{
    public interface IDicRepository
    {

        /// <summary>
        /// 根据编码获取字典
        /// </summary>
        /// <returns></returns>
        DicModel GetDicByCode(string dicCode);

        /// <summary>
        /// 检查数据是否存在
        /// </summary>
        /// <param name="dicName"></param>
        /// <param name="dicTypeCode"></param>
        /// <param name="dicCode"></param>
        /// <returns></returns>
        bool ExistsDicName(string dicName, string dicTypeCode, string dicCode = "");

        /// <summary>
        /// 获取所有字典类型
        /// </summary>
        /// <returns></returns>
        IEnumerable<DicTypeModel> GetAllDicType();

        /// <summary>
        /// 根据类型获取字典
        /// </summary>
        /// <returns></returns>
        IEnumerable<DicModel> GetDicListByTypeCode(string typeCode);

        /// <summary>
        /// 删除字典
        /// </summary>
        /// <param name="dicCode"></param>
        /// <returns></returns>
        int RemoveDic(string dicCode, string userName, string displayName);

        /// <summary>
        /// 编辑字典
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int UpdateDic(DicModel dic);

        /// <summary>
        /// 新增字典
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int CreateDic(DicModel dic);
    }
}
