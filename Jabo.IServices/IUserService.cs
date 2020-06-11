using Jabo.Models;
using System;
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
    }
}
