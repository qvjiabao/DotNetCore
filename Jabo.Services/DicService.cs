using Jabo.IRepository;
using Jabo.IServices;
using Jabo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.Services
{
    public class DicService : IDicService
    {
        private readonly IDicRepository _dicRepository;

        public DicService(IDicRepository dicRepository)
        {
            _dicRepository = dicRepository;
        }

        public IEnumerable<DicTypeModel> GetAllDicType()
        {
            return _dicRepository.GetAllDicType();
        }

        public IEnumerable<DicModel> GetDicListByTypeCode(string typeCode)
        {
            return _dicRepository.GetDicListByTypeCode(typeCode);
        }
    }
}
