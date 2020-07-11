using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jabo.Core.Filter;
using Jabo.Core.Result;
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

        public IActionResult DicSave()
        {
            return View();
        }


        [HttpPost]
        public JsonHttpActionResult SaveDicInfo(DicModel model)
        {
            var j = new JsonHttpActionResult();
            var success = true;
            if (string.IsNullOrWhiteSpace(model.DicCode))
            {
                //检查数据是否存在
                var checkUserName = _dicService.ExistsDicName(model.DicName, model.DicTypeCode);
                if (checkUserName)
                    return j.ErrorMessage("数据已存在");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = UserInfo.UserName;
                model.CreateDisplayName = UserInfo.DisplayName;
                model.IsDeleted = false;

            }
            else
            {
                //检查数据是否存在
                var checkUserName = _dicService.ExistsDicName(model.DicName, model.DicTypeCode, model.DicCode);
                if (checkUserName)
                    return j.ErrorMessage("数据已存在");
                model.ModifyDate = DateTime.Now;
                model.ModifyUserName = UserInfo.UserName;
                model.ModifyDisplayName = UserInfo.DisplayName;
            }

            success = _dicService.SaveDic(model);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpGet]
        public DicVModel GetDicByCode(string dicCode)
        {
            var user = _dicService.GetDicByCode(dicCode);

            var vmodel = _mapper.Map<DicVModel>(user);

            return vmodel;
        }

        [HttpGet]
        public IEnumerable<DicTypeVModel> GetDicTypeList()
        {
            var dicList = _dicService.GetAllDicType();

            var list = _mapper.Map<IEnumerable<DicTypeModel>, IEnumerable<DicTypeVModel>>(dicList);

            return list;
        }

        [HttpPost]
        public JsonHttpActionResult RemoveDicByCode(IEnumerable<DicModel> list)
        {
            var j = new JsonHttpActionResult();

            if (list.Count() == 0)
            {
                return j.ErrorMessage("请选择要删除的数据");
            }

            var user = UserInfo;

            var success = _dicService.RemoveDicByCode(list, user.UserName, user.DisplayName);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
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