using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Configuration;
namespace StudyProject
{
    public class RedisHelper
    {
        //int Default_Timeout = 600;//默认超时时间（单位秒）
        string address;
        //JsonSerializerSettings jsonConfig = new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore, NullValueHandling = NullValueHandling.Ignore };
        ConnectionMultiplexer connectionMultiplexer;
        IDatabase database;

        class CacheObject<T>
        {
            public int ExpireTime { get; set; }
            public bool ForceOutofDate { get; set; }
            public T Value { get; set; }
        }

        public RedisHelper()
        {
            ConfigurationOptions options = ConfigurationOptions.Parse(ConfigurationManager.AppSettings["RedisServer"]);
            options.ConnectTimeout = 500;
            connectionMultiplexer = ConnectionMultiplexer.Connect(options);
            database = connectionMultiplexer.GetDatabase();

            //this.address = ConfigurationManager.AppSettings["RedisServer"];

            //if (this.address == null || string.IsNullOrWhiteSpace(this.address.ToString()))
            //    throw new ApplicationException("配置文件中未找到RedisServer的有效配置");
            //connectionMultiplexer = ConnectionMultiplexer.Connect(address);

            //database = connectionMultiplexer.GetDatabase();
        }

        public object Get(string key)
        {
            return Get<object>(key);
        }

        public T Get<T>(string key)
        {
            var cacheValue = database.StringGet(key);
            var value = default(T);
            if (!cacheValue.IsNull)
            {
                var cacheObject = JsonConvert.DeserializeObject<CacheObject<T>>(cacheValue);
                if (!cacheObject.ForceOutofDate)
                    database.KeyExpire(key, new TimeSpan(0, 0, cacheObject.ExpireTime));
                value = cacheObject.Value;
            }
            return value;
        }

        /// <summary>
        /// 新增缓存内容
        /// </summary>
        /// <param name="key">缓存键</param>
        /// <param name="data">缓存数据</param>
        /// <param name="timeOut">缓存有效时长，默认600秒</param>
        public bool Insert(string key, object data, int timeOut = 600)
        {
            try
            {
                var jsonData = GetJsonData(data, timeOut, false);
                return database.StringSet(key, jsonData);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime"></param>
        public bool Insert(string key, object data, int cacheTime, int timeOut = 600)
        {
            try
            {
                var timeSpan = TimeSpan.FromSeconds(cacheTime);
                var jsonData = GetJsonData(data, timeOut, true);
                return database.StringSet(key, jsonData, timeSpan);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void Insert(string key, object data, DateTime cacheTime, int timeOut = 600)
        {
            var timeSpan = cacheTime - DateTime.Now;
            var jsonData = GetJsonData(data, timeOut, true);
            database.StringSet(key, jsonData, timeSpan);
        }

        public void Insert<T>(string key, T data, int timeOut = 600)
        {
            var jsonData = GetJsonData<T>(data, timeOut, false);
            database.StringSet(key, jsonData);
        }

        public void Insert<T>(string key, T data, int cacheTime,int timeOut = 600)
        {
            var timeSpan = TimeSpan.FromSeconds(cacheTime);
            var jsonData = GetJsonData<T>(data, timeOut, true);
            database.StringSet(key, jsonData, timeSpan);
        }

        public void Insert<T>(string key, T data, DateTime cacheTime,  int timeOut = 600)
        {
            var timeSpan = cacheTime - DateTime.Now;
            var jsonData = GetJsonData<T>(data, timeOut, true);
            database.StringSet(key, jsonData, timeSpan);
        }

        /// <summary>
        /// 将要保存的数据转换成JSON
        /// </summary>
        /// <param name="data">数据内容</param>
        /// <param name="cacheTime">过期时间</param>
        /// <param name="forceOutOfDate">是否强制失效</param>
        /// <returns></returns>
        private string GetJsonData(object data, int cacheTime, bool forceOutOfDate)
        {
            var cacheObject = new CacheObject<object>() { Value = data, ExpireTime = cacheTime, ForceOutofDate = forceOutOfDate };
            return JsonConvert.SerializeObject(cacheObject);//序列化对象
        }

        /// <summary>
        /// 将要保存的数据转换成JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">数据内容</param>
        /// <param name="cacheTime">过期时间</param>
        /// <param name="forceOutOfDate">是否强制失效</param>
        /// <returns></returns>
        string GetJsonData<T>(T data, int cacheTime, bool forceOutOfDate)
        {
            var cacheObject = new CacheObject<T>() { Value = data, ExpireTime = cacheTime, ForceOutofDate = forceOutOfDate };
            return JsonConvert.SerializeObject(cacheObject);//序列化对象
        }

        /// <summary>
        /// 删除，如键不存在则返回True
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            database.KeyDelete(key, CommandFlags.HighPriority);
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        public bool Exists(string key)
        {
            return database.KeyExists(key);
        }
    }
}