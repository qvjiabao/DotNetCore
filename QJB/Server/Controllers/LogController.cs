using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QJB.MongoDB.Model;
using QJB.MongoDB.Model.AppSettings;
using QJB.MongoDB.Repository;

namespace QJB.Server.Controllers
{
    public class LogController : ControllerBase
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

        private async void Add(QJB.MongoDB.Model.LogEventData data)
        {
            if (data != null)
            {
                 _logRepository.Add(data);
                //if (!string.IsNullOrEmpty(data.Emails))
                //{
                //    new EmailHelpers(_appsettings).SendMailAsync(data.Emails, "监测邮件", data.ToString());
                //}
            }
        }

        [HttpGet("getlist")]
        public async Task<ResponseModel<IEnumerable<LogEventData>>> GetList([FromQuery] QueryLogModel model)
        {
            ResponseModel<IEnumerable<MongoDB.Model.LogEventData>> resp = new ResponseModel<IEnumerable<MongoDB.Model.LogEventData>>();
            //resp.Data = _logRepository.GetList(model);
            return resp;
        }
    }
}