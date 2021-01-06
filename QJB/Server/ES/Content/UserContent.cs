using Nest;
using QJB.Elasticsearch.Base;
using QJB.Server.ES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QJB.Server.ES.Content
{
    public class UserContent : BaseEsContext<User>
    { /// <summary>
      /// 索引名称
      /// </summary>
        public override string IndexName => "itcast";
        public UserContent(IEsClientProvider provider) : base(provider)
        {
        }
        /// <summary>
        /// 获取地址
        /// </summary>
        /// <param name="province"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<User> GetUseres(string province, int pageIndex, int pageSize)
        {
            var client = _EsClientProvider.GetClient(IndexName);
            var musts = new List<Func<QueryContainerDescriptor<User>, QueryContainer>>();
            musts.Add(p => p.Term(m => m.Field(x => x.age).Value(province)));
            var search = new SearchDescriptor<User>();
            // search = search.Index(IndexName).Query(p => p.Bool(m => m.Must(musts))).From((pageIndex - 1) * pageSize).Take(pageSize);
            search = search.Query(p => p.Bool(m => m.Must(musts))).From((pageIndex - 1) * pageSize).Take(pageSize);
            var response = client.Search<User>(search);
            return response.Documents.ToList();
        }
        /// <summary>
        /// 获取所有地址
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUseres()
        {
            var client = _EsClientProvider.GetClient(IndexName);
            var searchDescriptor = new SearchDescriptor<User>();
            // searchDescriptor = searchDescriptor.Index(IndexName).Query(p => p.MatchAll());
            searchDescriptor = searchDescriptor.Query(p => p.MatchAll());
            var response = client.Search<User>(searchDescriptor);
            return response.Documents.ToList();
        }
        /// <summary>
        /// 删除指定城市的数据
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public bool DeleteByQuery(string city)
        {
            var client = _EsClientProvider.GetClient(IndexName);
            var musts = new List<Func<QueryContainerDescriptor<User>, QueryContainer>>();
            musts.Add(p => p.Term(m => m.Field(f => f.age).Value(city)));
            var search = new DeleteByQueryDescriptor<User>().Index(IndexName);
            search = search.Query(p => p.Bool(m => m.Must(musts)));
            var response = client.DeleteByQuery<User>(p => search);
            return response.IsValid;
        }
    }
}
