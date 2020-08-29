using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jabo.Log;
using Jabo.MongoDB.Model;
using Jabo.MongoDB.Model.AppSettings;
using Jabo.MongoDB.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Jabo.Core.Controllers
{
    public class LogController : Controller
    {
        private readonly LogRepository _logRepository;
        IOptions<AppSettings> _appsettings;
        public LogController(IRepository<MongoDB.Model.LogEventData> logRepository, IOptions<AppSettings> appsettings)
        {
            _logRepository = (LogRepository)logRepository;
            _appsettings = appsettings;
        }

        [HttpPost]
        public void Trace(MongoDB.Model.LogEventData value)
        {
            Add(value);
        }

        [HttpPost]
        public void Debug(MongoDB.Model.LogEventData value)
        {
            Add(value);

        }

        [HttpPost]
        public void Info(MongoDB.Model.LogEventData value)
        {
            Add(value);
        }

        [HttpPost]
        public void Warn(MongoDB.Model.LogEventData value)
        {
            Add(value);
        }

        [HttpPost]
        public void Error([FromBody]MongoDB.Model.LogEventData value)
        {
            Add(value);
        }

        [HttpPost]
        public void Fatal(MongoDB.Model.LogEventData value)
        {
            Add(value);
        }

        private async void Add(MongoDB.Model.LogEventData data)
        {
            if (data != null)
            {
                await _logRepository.Add(data);
                //if (!string.IsNullOrEmpty(data.Emails))
                //{
                //    new EmailHelpers(_appsettings).SendMailAsync(data.Emails, "监测邮件", data.ToString());
                //}
            }
        }

        [HttpGet("getlist")]
        public async Task<ResponseModel<IEnumerable<MongoDB.Model.LogEventData>>> GetList([FromQuery] QueryLogModel model)
        {
            ResponseModel<IEnumerable<MongoDB.Model.LogEventData>> resp = new ResponseModel<IEnumerable<MongoDB.Model.LogEventData>>();
            resp.Data = await _logRepository.GetList(model);
            return resp;
        }
    }
}