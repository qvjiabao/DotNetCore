﻿using Dapper;
using QJB.Dapper;
using QJB.ImplRepository;
using QJB.IRepository;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QJB.ImplRepository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public int CreateModel(UserModel t)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Insert<UserModel>(t);

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

        public UserModel GetModelByCode(string code)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var model = connection.GetList<UserModel>("where IsDeleted = 0 and UserCode = @userCode ",
                    new { userCode = code }).FirstOrDefault();

                return model;
            }
        }

        public IEnumerable<UserModel> GetModels(string where)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.GetList<UserModel>("where IsDeleted = 0 " + where + " order by CreateDate desc");

                return list;
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

        public int RemoveModelByCode(string codes, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute($@" UPDATE YX_Users SET IsDeleted = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where userCode in ({codes})", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now });

                return count;
            }
        }

        public int UpdateModel(UserModel t)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Update<UserModel>(t);

                return count;
            }
        }
    }
}
