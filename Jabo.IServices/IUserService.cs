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
    }
}
