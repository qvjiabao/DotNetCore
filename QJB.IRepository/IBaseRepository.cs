using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 根据编码获取数据
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        T GetModelByCode(string code);
        /// <summary>
        /// 获取所有数据信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetModels(string where);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        int RemoveModelByCode(string codes, string userName, string displayName);

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        int CreateModel(T t);

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        int UpdateModel(T t);
    }
}
