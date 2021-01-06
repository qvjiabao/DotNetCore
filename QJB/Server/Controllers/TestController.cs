using Microsoft.AspNetCore.Mvc;
using QJB.Server.ES.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QJB.Server.Controllers
{
    public class TestController : BaseController
    {

        private UserContent userContent;

        public TestController(UserContent _userConcent)
        {
            userContent = _userConcent;
        }

        public object Index()
        {

            var list = userContent.GetAllUseres();

            return list;
        }
    }
}
