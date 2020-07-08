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
        /// 根据类型获取字典
        /// </summary>
        /// <returns></returns>
        IEnumerable<DicModel> GetDicListByTypeCode(string typeCode);

    }
}
