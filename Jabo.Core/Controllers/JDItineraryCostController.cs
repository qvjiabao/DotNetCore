using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Jabo.Core.Result;
using Jabo.Core.ViewModels;
using Jabo.IServices;
using Jabo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jabo.Core.Controllers
{
    [Authorize]
    public class JDItineraryCostController : BaseController
    {
        private readonly IJDItineraryCostService _jDItinerayService;
        private readonly IMapper _mapper;

        public JDItineraryCostController(IMapper mapper, IJDItineraryCostService jDItinerayService)
        {
            _jDItinerayService = jDItinerayService;
            _mapper = mapper;
        }

        public IActionResult JDItineraryCostList()
        {
            return View();
        }

        public IActionResult JDItineraryCostSave()
        {
            return View();
        }

        [HttpGet]
        public JsonHttpActionResult GetJDItineraryCosts(string jDItineraryCode)
        {
            var j = new JsonHttpActionResult();

            if (string.IsNullOrEmpty(jDItineraryCode)) return j.SetData(new List<JDItineraryCostVModel>()).SucceedMessage();

            var all = _jDItinerayService.GetAllJDItineraryCosts(jDItineraryCode);

            var convertList = _mapper.Map<IEnumerable<JDItineraryCostModel>, IEnumerable<JDItineraryCostVModel>>(all);

            return j.SetData(convertList).SucceedMessage();

        }

        [HttpGet]
        public JDItineraryCostVModel GetJDItineraryCostByCode(string relationCode)
        {
            var user = _jDItinerayService.GetJDItineraryCostByCode(relationCode);

            var vmodel = _mapper.Map<JDItineraryCostVModel>(user);

            return vmodel;
        }

        [HttpPost]
        public JsonHttpActionResult SaveJDItineraryCostInfo(JDItineraryCostModel model)
        {
            var j = new JsonHttpActionResult();
            var success = true;
            if (string.IsNullOrWhiteSpace(model.RelationCode))
            {
                var checkJDItineraryCostName = _jDItinerayService.ExistxJDItineraryCost(model.JDItineraryCode, model.CarTypeCode);
                if (checkJDItineraryCostName)
                    return j.ErrorMessage("车型已存在");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = UserInfo.UserName;
                model.CreateDisplayName = UserInfo.DisplayName;
                model.IsDeleted = false;
            }
            else
            {
                var checkJDItineraryCostName = _jDItinerayService.ExistxJDItineraryCost(model.JDItineraryCode, model.CarTypeCode, model.RelationCode);
                if (checkJDItineraryCostName)
                    return j.ErrorMessage("车型已存在");
                model.ModifyDate = DateTime.Now;
                model.ModifyUserName = UserInfo.UserName;
                model.ModifyDisplayName = UserInfo.DisplayName;
            }

            success = _jDItinerayService.SaveJDItineraryCost(model);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpPost]
        public JsonHttpActionResult RemoveJDItineraryCostByCode(IEnumerable<JDItineraryCostModel> list)
        {
            var j = new JsonHttpActionResult();

            if (list.Count() == 0)
            {
                return j.ErrorMessage("请选择要删除的车型");
            }

            var user = UserInfo;

            var success = _jDItinerayService.RemoveJDItineraryCostByCode(list, user.UserName, user.DisplayName);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpGet]
        public Hashtable GetJDItineraryCostList(string jDItineraryCode, int limit = 10, int page = 1)
        {
            var all = _jDItinerayService.GetAllJDItineraryCosts(jDItineraryCode);

            var list = all.Skip((page - 1) * limit).Take(limit);

            var convertList = _mapper.Map<IEnumerable<JDItineraryCostModel>, IEnumerable<JDItineraryCostVModel>>(list);

            var tab = new Hashtable();

            tab["count"] = all.Count();

            tab["data"] = convertList;

            tab["code"] = "0";

            return tab;
        }
    }
}