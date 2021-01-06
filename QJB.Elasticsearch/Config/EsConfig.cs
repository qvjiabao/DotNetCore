using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace QJB.Elasticsearch.Config
{
    public class EsConfig : IOptions<EsConfig>
    {
        public List<string> Urls { get; set; }

        public EsConfig Value => this;
    }
}
