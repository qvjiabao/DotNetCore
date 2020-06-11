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
        public UserModel GetUserByUserNameAndPwd(string userName, string pwd)
        {
            using (var connection = DataBase.GetOpenConnection())
            {
                var model = connection.GetList<UserModel>("where IsDeleted = 0 and UserName = @UserName and PassWord = @PassWord",
                    new { UserName = userName, PassWord = pwd }).FirstOrDefault();

                return model;
            }
        }
    }
}
