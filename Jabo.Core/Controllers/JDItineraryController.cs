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
     
    public class JDItineraryController : BaseController
    {
        private readonly IJDItineraryService _jDItinerayService;
        private readonly IMapper _mapper;

        public JDItineraryController(IMapper mapper, IJDItineraryService jDItinerayService)
        {
            _jDItinerayService = jDItinerayService;
            _mapper = mapper;
        }

        public IActionResult JDItineraryList()
        {
            return View();
        }

        public IActionResult JDItineraryView()
        {
            return View();
        }
        public IActionResult JDItinerarySave()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<string> GetDeparture()
        {
            var all = _jDItinerayService.GetAllJDItinerarys().Select(s => s.Departure).Distinct();

            return all;
        }

        [HttpGet]
        public JsonHttpActionResult GetTerminal(string departure)
        {
            var j = new JsonHttpActionResult();

            if (string.IsNullOrEmpty(departure)) return j.SetData(new List<JDItineraryVModel>()).SucceedMessage();

            var all = _jDItinerayService.GetTerminalByDeparture(departure);

            var convertList = _mapper.Map<IEnumerable<JDItineraryModel>, IEnumerable<JDItineraryVModel>>(all);

            return j.SetData(convertList).SucceedMessage();

        }

        [HttpGet]
        public JDItineraryVModel GetJDItineraryByCode(string jDItineraryCode)
        {
            var user = _jDItinerayService.GetJDItineraryByCode(jDItineraryCode);

            var vmodel = _mapper.Map<JDItineraryVModel>(user);

            return vmodel;
        }

        [HttpPost]
        public JsonHttpActionResult SaveJDItineraryInfo(JDItineraryModel model)
        {
            var j = new JsonHttpActionResult();
            var success = true;
            if (string.IsNullOrWhiteSpace(model.JDItineraryCode))
            {
                //检查用户账号是否存在
                var checkJDItineraryName = _jDItinerayService.ExistxJDItinerary(model.Departure, model.Terminal);
                if (checkJDItineraryName)
                    return j.ErrorMessage("行程已存在");
                model.CreateDate = DateTime.Now;
                model.CreateUserName = UserInfo.UserName;
                model.CreateDisplayName = UserInfo.DisplayName;
                model.IsDeleted = false;
            }
            else
            {
                //检查用户账号是否存在
                var checkJDItineraryName = _jDItinerayService.ExistxJDItinerary(model.Departure, model.Terminal, model.JDItineraryCode);
                if (checkJDItineraryName)
                    return j.ErrorMessage("行程已存在");
                model.ModifyDate = DateTime.Now;
                model.ModifyUserName = UserInfo.UserName;
                model.ModifyDisplayName = UserInfo.DisplayName;
            }

            success = _jDItinerayService.SaveJDItinerary(model);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpPost]
        public JsonHttpActionResult RemoveJDItineraryByCode(IEnumerable<JDItineraryModel> list)
        {
            var j = new JsonHttpActionResult();

            if (list.Count() == 0)
            {
                return j.ErrorMessage("请选择要删除的行程");
            }

            var user = UserInfo;

            var success = _jDItinerayService.RemoveJDItineraryByCode(list, user.UserName, user.DisplayName);

            j.SetData(success);

            return success ? j.SucceedMessage() : j.ErrorMessage();
        }

        [HttpGet]
        public Hashtable GetJDItineraryList(string departure, string terminal, int limit = 10, int page = 1)
        {
            var all = _jDItinerayService.GetAllJDItinerarys(departure, terminal);

            var list = all.Skip((page - 1) * limit).Take(limit);

            var convertList = _mapper.Map<IEnumerable<JDItineraryModel>, IEnumerable<JDItineraryVModel>>(list);

            var tab = new Hashtable();

            tab["count"] = all.Count();

            tab["data"] = convertList;

            tab["code"] = "0";

            return tab;
        }
    }
}