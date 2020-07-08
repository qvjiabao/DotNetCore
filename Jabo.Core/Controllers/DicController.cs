using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jabo.Core.Filter;
using Jabo.Core.ViewModels;
using Jabo.IServices;
using Jabo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jabo.Core.Controllers
{
    [CheckLogin]
    public class DicController : BaseController
    {
        private readonly IDicService _dicService;
        private readonly IMapper _mapper;

        public DicController(IMapper mapper, IDicService dicService)
        {
            _dicService = dicService;
            _mapper = mapper;
        }

        public IActionResult DicList()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<DicTypeVModel> GetDicTypeList()
        {
            var dicList = _dicService.GetAllDicType();

            var list = _mapper.Map<IEnumerable<DicTypeModel>, IEnumerable<DicTypeVModel>>(dicList);

            return list;
        }

        [HttpGet]
        public Hashtable GetDicListByTypeCode(string dicTypeCode, int limit = 10, int page = 1)
        {
            var all = _dicService.GetDicListByTypeCode(dicTypeCode);

            var list = all.Skip((page - 1) * limit).Take(limit);

            var convertList = _mapper.Map<IEnumerable<DicModel>, IEnumerable<DicVModel>>(list);

            var tab = new Hashtable();

            tab["count"] = all.Count();

            tab["data"] = convertList;

            tab["code"] = "0";

            return tab;
        }
    }
}