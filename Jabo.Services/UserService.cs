using Jabo.IRepository;
using Jabo.IServices;
using Jabo.Models;
using System;
using System.Collections.Generic;
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
    }
}
