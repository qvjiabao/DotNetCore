using Dapper;
using Jabo.Dapper;
using Jabo.IRepository;
using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jabo.Repository
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<UserModel> GetAllUsers(string where)
        {
            using (var connection = DataBase.GetOpenConnection())
            {
                var list = connection.GetList<UserModel>("where IsDeleted = 0 " + where);

                return list;
            }
        }

        public UserModel GetUserByUserCode(string userCode)
        {
            using (var connection = DataBase.GetOpenConnection())
            {
                var model = connection.Get<UserModel>(userCode);

                return model;
            }
        }

        public UserModel GetUserByUserNameAndPwd(string userName, string pwd)
        {
            using (var connection = DataBase.GetOpenConnection())
            {
                var model = connection.GetList<UserModel>("where IsDeleted = 0 and UserName = @UserName and PassWord = @PassWord",
                    new { UserName = userName, PassWord = pwd }).FirstOrDefault();

                return model;
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public int RemoveUserByCode(string userCodes)
        {
            using (var connection = DataBase.GetOpenConnection())
            {
                var count = connection.Execute($" UPDATE YX_Users SET IsDeleted = 1 where userCode in ({userCodes})");

                return count;
            }
        }
    }
}
