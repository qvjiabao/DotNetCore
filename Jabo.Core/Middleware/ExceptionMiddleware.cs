using Jabo.Core.Result;
using Jabo.MongoDB.Model;
using Jabo.MongoDB.Model.AppSettings;
using Jabo.MongoDB.Repository;
using Jabo.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Jabo.Core.Middleware
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IOptions<DBSettings> settings)
        {
            LogRepository _repository = new LogRepository(settings);
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var enable = AppConfigurtaion.Configuration["MongoDBSettings:Enable"];

                        if (enable == "True")
                        {
                            await _repository.Add(new LogEventData
                            {
                                Message = contextFeature.Error.ToString(),
                                Date = DateTime.Now,
                                Level = "Fatal",
                                LogSource = "LogWebApi"
                            });
                        }

                        var j = new JsonHttpActionResult();

                        j.ErrorMessage(contextFeature.Error.Message);

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(j));
                    }
                });
            });
        }
    }
}
