using Jabo.IRepository;
using Jabo.IServices;
using Jabo.Models;
using Jabo.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jabo.Services
{
    public class UserService : IUserService
    {

        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel GetUserByUserNameAndPwd(string userName, string pwd)
        {
            pwd = EncryptTool.GetMd5By32(pwd);

            return _userRepository.GetUserByUserNameAndPwd(userName, pwd);
        }

        public IEnumerable<UserModel> GetAllUsers(string displayName)
        {
            var sql = string.Empty;

            if (!string.IsNullOrWhiteSpace(displayName))
            {
                sql = $" and  DisplayName like '%{displayName}%' ";
            }

            var list = _userRepository.GetAllUsers(sql);

            return list;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userCode"></param>
        /// <returns></returns>
        public bool RemoveUserByCode(IEnumerable<UserModel> list)
        {
            if (list.Count() == 0) return false;

            var str = list.Aggregate(string.Empty, (s, n) => s += $",'{n.UserCode}'");

            return _userRepository.RemoveUserByCode(str.Substring(1)) > 0;
        }

        public UserModel GetUserByUserCode(string userCode)
        {
            return _userRepository.GetUserByUserCode(userCode);
        }

        public bool ExistsUserName(string userName, string userCode = "")
        {
            return _userRepository.ExistxUserName(userName, userCode);
        }

        public bool SaveUser(UserModel userModel, bool IsChangePwd = false)
        {
            if (string.IsNullOrWhiteSpace(userModel.UserCode))
            {
                userModel.UserCode = Guid.NewGuid().ToString();
                userModel.PassWord = EncryptTool.GetMd5By32("123456");
                return _userRepository.CreateUser(userModel) > 0;
            }
            else
            {
                var model = _userRepository.GetUserByUserCode(userModel.UserCode);
                model.DisplayName = userModel.DisplayName;
                model.Sex = userModel.Sex;
                model.Phone = userModel.Phone;
                model.ModifyDate = userModel.ModifyDate;
                model.ModifyDisplayName = userModel.ModifyDisplayName;
                model.ModifyUserName = userModel.ModifyUserName;
                if (IsChangePwd)
                    model.PassWord = EncryptTool.GetMd5By32(userModel.PassWord);

                return _userRepository.UpdateUser(model) > 0;
            }
        }
    }
}
