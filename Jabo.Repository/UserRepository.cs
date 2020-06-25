using Dapper;
using Jabo.Dapper;
using Jabo.IRepository;
using Jabo.Models;
using Jabo.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jabo.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public int CreateUser(UserModel user)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Insert<UserModel>(user);

                return (int)count;
            }
        }

        public bool ExistxUserName(string userName, string userCode = "")
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                if (string.IsNullOrWhiteSpace(userCode))
                {
                    var model = connection.GetList<UserModel>("where IsDeleted = 0 and UserName = @userName ",
                        new { userName = userName }).FirstOrDefault();

                    return model != null;
                }
                else
                {
                    var model = connection.GetList<UserModel>("where IsDeleted = 0 and UserName = @userName and UserCode <> @userCode",
                        new { userName = userName, userCode = userCode }).FirstOrDefault();

                    return model != null;
                }
            }
        }

        public IEnumerable<UserModel> GetAllUsers(string where)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.GetList<UserModel>("where IsDeleted = 0 " + where + " order by CreateDate desc");

                return list;
            }
        }

        public UserModel GetUserByUserCode(string userCode)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var model = connection.GetList<UserModel>("where IsDeleted = 0 and UserCode = @userCode ",
                    new { userCode = userCode }).FirstOrDefault();

                return model;
            }
        }

        public UserModel GetUserByUserNameAndPwd(string userName, string pwd)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
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
        public int RemoveUserByCode(string userCodes, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute(@$" UPDATE YX_Users SET IsDeleted = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where userCode in ({userCodes})", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now });

                return count;
            }
        }

        public int UpdateUser(UserModel user)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Update<UserModel>(user);

                return count;
            }
        }
    }
}
