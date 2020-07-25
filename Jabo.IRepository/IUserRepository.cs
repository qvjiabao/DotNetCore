using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.IRepository
{
    public interface IUserRepository: IBaseRepository<UserModel>
    {
        /// <summary>
        /// 根据账号密码获取用户信息
        /// </summary>
        /// <returns></returns>
        UserModel GetUserByUserNameAndPwd(string userName, string pwd);

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        bool ExistxUserName(string userName, string userCode = "");
    }
}
