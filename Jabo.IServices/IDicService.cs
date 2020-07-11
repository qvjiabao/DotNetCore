using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IServices
{
    public interface IDicService
    {
        /// <summary>
        /// 获取所有字典类型
        /// </summary>
        /// <returns></returns>
        IEnumerable<DicTypeModel> GetAllDicType();

        /// <summary>
        /// 检查数据是否存在
        /// </summary>
        /// <param name="dicName"></param>
        /// <param name="dicTypeCode"></param>
        /// <param name="dicCode"></param>
        /// <returns></returns>
        bool ExistsDicName(string dicName, string dicTypeCode, string dicCode = "");

        /// <summary>
        /// 根据类型获取字典
        /// </summary>
        /// <returns></returns>
        IEnumerable<DicModel> GetDicListByTypeCode(string typeCode);

        /// <summary>
        /// 根据字典编码获取字典
        /// </summary>
        /// <returns></returns>
        DicModel GetDicByCode(string dicCode);

        /// <summary>
        /// 保存字典
        /// </summary>
        /// <param name="roleModel"></param>
        /// <returns></returns>
        bool SaveDic(DicModel dicModel);

        /// <summary>
        /// 删除字典
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        bool RemoveDicByCode(IEnumerable<DicModel> list, string userName, string displayName);


    }
}
