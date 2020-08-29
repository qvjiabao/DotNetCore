using Jabo.MongoDB.Model;
using Jabo.MongoDB.Model.AppSettings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jabo.MongoDB.Context
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly string _logCollection;
        public MongoContext(IOptions<DBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
            _logCollection = settings.Value.LogCollection;
        }

        public IMongoCollection<LogEventData> LogEventDatas
        {
            get
            {
                return _database.GetCollection<LogEventData>(_logCollection);
            }
        }
    }
}
