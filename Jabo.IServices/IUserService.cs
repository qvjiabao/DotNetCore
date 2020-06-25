using Jabo.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// 检查用户是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userCode"></param>
        /// <returns></returns>
        bool ExistsUserName(string userName, string userCode = "");

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        bool SaveUser(UserModel userModel, bool IsChangePwd = false);

        /// <summary>
        /// 根据编码获取用户
        /// </summary>
        /// <returns></returns>
        UserModel GetUserByUserCode(string userCode);

        /// <summary>
        /// 根据账号密码获取用户信息
        /// </summary>
        /// <returns></returns>
        UserModel GetUserByUserNameAndPwd(string userName, string pwd);

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="displayName"></param>
        /// <returns></returns>
        IEnumerable<UserModel> GetAllUsers(string displayName);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        bool RemoveUserByCode(IEnumerable<UserModel> list, string userName, string displayName);
    }
}
