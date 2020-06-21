using Jabo.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.Repository
{
    public class BaseRepository
    {

        public string GetConnectionString
        {
            get
            {
                return AppConfigurtaion.Configuration["ConnectionString"];
            }
        }
    }
}
