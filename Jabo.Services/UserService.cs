using Jabo.IRepository;
using Jabo.IServices;
using Jabo.Models;
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
    }
}
