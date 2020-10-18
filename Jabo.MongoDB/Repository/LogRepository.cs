using Jabo.MongoDB.Context;
using Jabo.MongoDB.Model;
using Jabo.MongoDB.Model.AppSettings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Jabo.MongoDB.Repository
{
    public class LogRepository : IRepository<LogEventData>
    {
        private readonly MongoContext _context = null;
        public LogRepository(IOptions<DBSettings> settings)
        {
            _context = new MongoContext(settings);
        }

        #region Add 添加一条数据
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <returns></returns>
        public int Add(LogEventData t)
        {
            try
            {
                var client = _context.LogEventDatas;
                client.InsertOne(t);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region AddAsync 异步添加一条数据
        /// <summary>
        /// 异步添加一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <returns></returns>
        public async Task<int> AddAsync(LogEventData t)
        {
            try
            {
                var client = _context.LogEventDatas;
                await client.InsertOneAsync(t);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region InsertMany 批量插入
        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="t">实体集合</param>
        /// <returns></returns>
        public int InsertMany(List<LogEventData> t)
        {
            try
            {
                var client = _context.LogEventDatas;
                client.InsertMany(t);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region InsertManyAsync 异步批量插入
        /// <summary>
        /// 异步批量插入
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="t">实体集合</param>
        /// <returns></returns>
        public async Task<int> InsertManyAsync(List<LogEventData> t)
        {
            try
            {
                var client = _context.LogEventDatas;
                await client.InsertManyAsync(t);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region Update 修改一条数据
        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <returns></returns>
        public UpdateResult Update(LogEventData t, string id)
        {
            try
            {
                var client = _context.LogEventDatas;
                //修改条件
                FilterDefinition<LogEventData> filter = Builders<LogEventData>.Filter.Eq("_id", new ObjectId(id));
                //要修改的字段
                var list = new List<UpdateDefinition<LogEventData>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (item.Name.ToLower() == "id") continue;
                    list.Add(Builders<LogEventData>.Update.Set(item.Name, item.GetValue(t)));
                }
                var updatefilter = Builders<LogEventData>.Update.Combine(list);
                return client.UpdateOne(filter, updatefilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdateAsync 异步修改一条数据
        /// <summary>
        /// 异步修改一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <returns></returns>
        public async Task<UpdateResult> UpdateAsync(LogEventData t, string id)
        {
            try
            {
                var client = _context.LogEventDatas;
                //修改条件
                FilterDefinition<LogEventData> filter = Builders<LogEventData>.Filter.Eq("_id", new ObjectId(id));
                //要修改的字段
                var list = new List<UpdateDefinition<LogEventData>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (item.Name.ToLower() == "id") continue;
                    list.Add(Builders<LogEventData>.Update.Set(item.Name, item.GetValue(t)));
                }
                var updatefilter = Builders<LogEventData>.Update.Combine(list);
                return await client.UpdateOneAsync(filter, updatefilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdateManay 批量修改数据
        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="dic">要修改的字段</param>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">修改条件</param>
        /// <returns></returns>
        public UpdateResult UpdateManay(Dictionary<string, string> dic, FilterDefinition<LogEventData> filter)
        {
            try
            {
                var client = _context.LogEventDatas;
                LogEventData t = new LogEventData();
                //要修改的字段
                var list = new List<UpdateDefinition<LogEventData>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (!dic.ContainsKey(item.Name)) continue;
                    var value = dic[item.Name];
                    list.Add(Builders<LogEventData>.Update.Set(item.Name, value));
                }
                var updatefilter = Builders<LogEventData>.Update.Combine(list);
                return client.UpdateMany(filter, updatefilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdateManayAsync 异步批量修改数据
        /// <summary>
        /// 异步批量修改数据
        /// </summary>
        /// <param name="dic">要修改的字段</param>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">修改条件</param>
        /// <returns></returns>
        public async Task<UpdateResult> UpdateManayAsync(Dictionary<string, string> dic, FilterDefinition<LogEventData> filter)
        {
            try
            {
                var client = _context.LogEventDatas;
                LogEventData t = new LogEventData();
                //要修改的字段
                var list = new List<UpdateDefinition<LogEventData>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (!dic.ContainsKey(item.Name)) continue;
                    var value = dic[item.Name];
                    list.Add(Builders<LogEventData>.Update.Set(item.Name, value));
                }
                var updatefilter = Builders<LogEventData>.Update.Combine(list);
                return await client.UpdateManyAsync(filter, updatefilter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete 删除一条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectId</param>
        /// <returns></returns>
        public DeleteResult Delete(string id)
        {
            try
            {
                var client = _context.LogEventDatas;
                FilterDefinition<LogEventData> filter = Builders<LogEventData>.Filter.Eq("_id", new ObjectId(id));
                return client.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region DeleteAsync 异步删除一条数据
        /// <summary>
        /// 异步删除一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectId</param>
        /// <returns></returns>
        public async Task<DeleteResult> DeleteAsync(string id)
        {
            try
            {
                var client = _context.LogEventDatas;
                //修改条件
                FilterDefinition<LogEventData> filter = Builders<LogEventData>.Filter.Eq("_id", new ObjectId(id));
                return await client.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region DeleteMany 删除多条数据
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">删除的条件</param>
        /// <returns></returns>
        public DeleteResult DeleteMany(FilterDefinition<LogEventData> filter)
        {
            try
            {
                var client = _context.LogEventDatas;
                return client.DeleteMany(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region DeleteManyAsync 异步删除多条数据
        /// <summary>
        /// 异步删除多条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">删除的条件</param>
        /// <returns></returns>
        public async Task<DeleteResult> DeleteManyAsync(FilterDefinition<LogEventData> filter)
        {
            try
            {
                var client = _context.LogEventDatas;
                return await client.DeleteManyAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Count 根据条件获取总数
        /// <summary>
        /// 根据条件获取总数
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public long Count(FilterDefinition<LogEventData> filter)
        {
            try
            {
                var client = _context.LogEventDatas;
                return client.Count(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CountAsync 异步根据条件获取总数
        /// <summary>
        /// 异步根据条件获取总数
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public async Task<long> CountAsync(FilterDefinition<LogEventData> filter)
        {
            try
            {
                var client = _context.LogEventDatas;
                return await client.CountAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindOne 根据id查询一条数据
        /// <summary>
        /// 根据id查询一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectid</param>
        /// <param name="field">要查询的字段，不写时查询全部</param>
        /// <returns></returns>
        public LogEventData FindOne(string id, string[] field = null)
        {
            try
            {
                var client = _context.LogEventDatas;
                FilterDefinition<LogEventData> filter = Builders<LogEventData>.Filter.Eq("_id", new ObjectId(id));
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    return client.Find(filter).FirstOrDefault<LogEventData>();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<LogEventData>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<LogEventData>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<LogEventData>.Projection.Combine(fieldList);
                fieldList.Clear();
                return client.Find(filter).Project<LogEventData>(projection).FirstOrDefault<LogEventData>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindOneAsync 异步根据id查询一条数据
        /// <summary>
        /// 异步根据id查询一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectid</param>
        /// <returns></returns>
        public async Task<LogEventData> FindOneAsync(string id, string[] field = null)
        {
            try
            {
                var client = _context.LogEventDatas;
                FilterDefinition<LogEventData> filter = Builders<LogEventData>.Filter.Eq("_id", new ObjectId(id));
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    return await client.Find(filter).FirstOrDefaultAsync();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<LogEventData>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<LogEventData>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<LogEventData>.Projection.Combine(fieldList);
                fieldList.Clear();
                return await client.Find(filter).Project<LogEventData>(projection).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindList 查询集合
        /// <summary>
        /// 查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public List<LogEventData> FindList(FilterDefinition<LogEventData> filter, string[] field = null, SortDefinition<LogEventData> sort = null)
        {
            try
            {
                var client = _context.LogEventDatas;
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null) return client.Find(filter).ToList();
                    //进行排序
                    return client.Find(filter).Sort(sort).ToList();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<LogEventData>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<LogEventData>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<LogEventData>.Projection.Combine(fieldList);
                fieldList.Clear();
                if (sort == null) return client.Find(filter).Project<LogEventData>(projection).ToList();
                //排序查询
                return client.Find(filter).Sort(sort).Project<LogEventData>(projection).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindListAsync 异步查询集合
        /// <summary>
        /// 异步查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public async Task<List<LogEventData>> FindListAsync(FilterDefinition<LogEventData> filter, string[] field = null, SortDefinition<LogEventData> sort = null)
        {
            try
            {
                var client = _context.LogEventDatas;
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null) return await client.Find(filter).ToListAsync();
                    return await client.Find(filter).Sort(sort).ToListAsync();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<LogEventData>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<LogEventData>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<LogEventData>.Projection.Combine(fieldList);
                fieldList.Clear();
                if (sort == null) return await client.Find(filter).Project<LogEventData>(projection).ToListAsync();
                //排序查询
                return await client.Find(filter).Sort(sort).Project<LogEventData>(projection).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindListByPage 分页查询集合
        /// <summary>
        /// 分页查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="count">总条数</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public List<LogEventData> FindListByPage(FilterDefinition<LogEventData> filter, int pageIndex, int pageSize, out long count, string[] field = null, SortDefinition<LogEventData> sort = null)
        {
            try
            {
                var client = _context.LogEventDatas;
                count = client.Count(filter);
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null) return client.Find(filter).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();
                    //进行排序
                    return client.Find(filter).Sort(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<LogEventData>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<LogEventData>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<LogEventData>.Projection.Combine(fieldList);

                fieldList.Clear();

                //不排序
                if (sort == null) return client.Find(filter).Project<LogEventData>(projection).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();

                //排序查询
                return client.Find(filter).Sort(sort).Project<LogEventData>(projection).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region FindListByPageAsync 异步分页查询集合
        /// <summary>
        /// 异步分页查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public async Task<List<LogEventData>> FindListByPageAsync(FilterDefinition<LogEventData> filter, int pageIndex, int pageSize, string[] field = null, SortDefinition<LogEventData> sort = null)
        {
            try
            {
                var client = _context.LogEventDatas;
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null) return await client.Find(filter).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
                    //进行排序
                    return await client.Find(filter).Sort(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<LogEventData>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<LogEventData>.Projection.Include(field[i].ToString()));
                }
                var projection = Builders<LogEventData>.Projection.Combine(fieldList);
                fieldList.Clear();

                //不排序
                if (sort == null) return await client.Find(filter).Project<LogEventData>(projection).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();

                //排序查询
                return await client.Find(filter).Sort(sort).Project<LogEventData>(projection).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
