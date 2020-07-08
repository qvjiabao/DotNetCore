using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IRepository
{
    public interface IDicRepository
    {
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
        /// 删除字典类型
        /// </summary>
        /// <param name="dicTypeCode"></param>
        /// <returns></returns>
        int RemoveDicType(string dicTypeCode, string userName, string displayName);

        /// <summary>
        /// 编辑字典类型
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int UpdateDicType(DicTypeModel dicType);

        /// <summary>
        /// 新增字典类型
        /// </summary>
        /// <param name="roleCode"></param>
        /// <returns></returns>
        int CreateDicType(DicTypeModel dicType);
    }
}
