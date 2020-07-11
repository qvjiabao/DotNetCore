using Dapper;
using Jabo.Dapper;
using Jabo.IRepository;
using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jabo.Repository
{
    public class DicRepository : BaseRepository, IDicRepository
    {
        public int CreateDic(DicModel dicType)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Insert<DicModel>(dicType);

                return (int)count;
            }
        }

        public bool ExistsDicName(string dicName, string dicTypeCode, string dicCode = "")
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                if (string.IsNullOrWhiteSpace(dicCode))
                {
                    var model = connection.GetList<DicModel>("where IsDeleted = 0 and DicName = @dicName and DicTypeCode = @dicTypeCode  ",
                        new { dicName, dicTypeCode }).FirstOrDefault();

                    return model != null;
                }
                else
                {
                    var model = connection.GetList<DicModel>("where IsDeleted = 0 and DicName = @dicName and DicTypeCode = @dicTypeCode  and DicCode <> @dicCode",
                        new { dicName, dicTypeCode, dicCode }).FirstOrDefault();

                    return model != null;
                }
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

        public DicModel GetDicByCode(string dicCode)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var model = connection.GetList<DicModel>("where IsDeleted = 0 and DicCode = @dicCode ",
                    new { dicCode = dicCode }).FirstOrDefault();

                return model;
            }
        }

        public IEnumerable<DicModel> GetDicListByTypeCode(string typeCode)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var list = connection.GetList<DicModel>("where IsDeleted = 0 and DicTypeCode=@typeCode order by Sort asc", new { typeCode });

                return list;
            }
        }

        public int RemoveDic(string dicCode, string userName, string displayName)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Execute(@$" UPDATE YX_Dic SET IsDeleted = 1,ModifyUserName = @modifyUserName,ModifyDisplayName = @modifyDisplayName
                    ,ModifyDate = @modifyDate where DicCode =  @dicCode ", new { modifyUserName = userName, modifyDisplayName = displayName, modifyDate = DateTime.Now, dicCode });

                return count;
            }
        }

        public int UpdateDic(DicModel dic)
        {
            using (var connection = DataBase.GetOpenConnection(GetConnectionString))
            {
                var count = connection.Update<DicModel>(dic);

                return count;
            }
        }
    }
}
