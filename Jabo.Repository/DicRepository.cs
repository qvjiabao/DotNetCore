using Dapper;
using Jabo.Dapper;
using Jabo.IRepository;
using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.Repository
{
    public class DicRepository : BaseRepository, IDicRepository
    {
        public int CreateDicType(DicTypeModel dicType)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Insert<DicTypeModel>(dicType);

                return (int)count;
            }
        }

        public IEnumerable<DicTypeModel> GetAllDicType()
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.GetList<DicTypeModel>("where IsDeleted = 0  order by CreateDate desc");

                return list;
            }
        }

        public IEnumerable<DicModel> GetDicListByTypeCode(string typeCode)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.GetList<DicModel>("where IsDeleted = 0 and DicTypeCode=@typeCode order by Sort desc", new { typeCode });

                return list;
            }
        }

        public int RemoveDicType(string dicTypeCode, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute(@$" UPDATE YX_DicType SET IsDeleted = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where userCode in ({dicTypeCode})", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now });

                return count;
            }
        }

        public int UpdateDicType(DicTypeModel dicType)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Update<DicTypeModel>(dicType);

                return count;
            }
        }
    }
}
