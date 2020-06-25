using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IRepository
{
    public interface IUserRepository
    {

        /// <summary>
        /// 根据账号密码获取用户信息
        /// </summary>
        /// <returns></returns>
        UserModel GetUserByUserNameAndPwd(string userName, string pwd);

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserModel> GetAllUsers(string where);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        int RemoveUserByCode(string userCodes, string userName, string displayName);

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        int CreateUser(UserModel user);

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        int UpdateUser(UserModel user);

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        bool ExistxUserName(string userName, string userCode = "");

        /// <summary>
        /// 根据编码获取用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        UserModel GetUserByUserCode(string userCode);
    }
}
