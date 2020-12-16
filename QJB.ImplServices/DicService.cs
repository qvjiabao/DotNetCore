using QJB.IRepository;
using QJB.IServices;
using QJB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QJB.ImplService
{
    public class DicService : IDicService
    {
        private readonly IDicRepository _dicRepository;

        public DicService(IDicRepository dicRepository)
        {
            _dicRepository = dicRepository;
        }

        public bool ExistsDicName(string dicName, string dicTypeCode, string dicCode = "")
        {
            return _dicRepository.ExistsDicName(dicName, dicTypeCode, dicCode);
        }

        public IEnumerable<DicTypeModel> GetAllDicType()
        {
            return _dicRepository.GetAllDicType();
        }

        public DicModel GetDicByCode(string dicCode)
        {
            return _dicRepository.GetDicByCode(dicCode);
        }

        public IEnumerable<DicModel> GetDicListByTypeCode(string typeCode)
        {
            return _dicRepository.GetDicListByTypeCode(typeCode);
        }

        public bool RemoveDicByCode(IEnumerable<DicModel> list, string userName, string displayName)
        {
            if (list.Count() == 0) return false;

            return _dicRepository.RemoveDic(list.FirstOrDefault().DicCode, userName, displayName) > 0;
        }

        public bool SaveDic(DicModel dicModel)
        {
            if (string.IsNullOrWhiteSpace(dicModel.DicCode))
            {
                dicModel.DicCode = Guid.NewGuid().ToString();

                return _dicRepository.CreateDic(dicModel) > 0;
            }
            else
            {
                var model = _dicRepository.GetDicByCode(dicModel.DicCode);
                model.DicName = dicModel.DicName;
                model.Sort = dicModel.Sort;
                model.ModifyDate = dicModel.ModifyDate;
                model.ModifyDisplayName = dicModel.ModifyDisplayName;
                model.ModifyUserName = dicModel.ModifyUserName;

                return _dicRepository.UpdateDic(model) > 0;
            }
        }
    }
}
