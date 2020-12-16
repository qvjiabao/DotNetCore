using QJB.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.ImplRepository
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
