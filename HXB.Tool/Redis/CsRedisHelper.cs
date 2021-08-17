using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool.Redis
{
    public static class CsRedisHelper
    {
        /// <summary>
        /// 设置 key 并保存对象（如果 key 已存在，则覆盖值）
        /// </summary>
        /// <param name="redisKey">名称</param>
        /// <param name="redisValue">值</param>
        /// <param name="keyType">分类,前缀</param>
        public static void Set(string redisKey, object redisValue, string keyType = null)
        {
            string temp = AddKeyType(redisKey, keyType);
            RedisHelper.Set(temp, redisValue);
        }
        /// <summary>
        /// 设置 key 并保存对象（如果 key 已存在，则覆盖值）
        /// </summary>
        /// <param name="redisKey">名称</param>
        /// <param name="redisValue">值</param>
        /// <param name="expiry">过期时间</param>
        /// <param name="keyType">分类,前缀</param>
        public static void Set(string redisKey, object redisValue, TimeSpan expiry, string keyType = null)
        {
            string temp = AddKeyType(redisKey, keyType);
            RedisHelper.Set(temp, redisValue, expiry);
        }
        /// <summary>
        /// 删除Key
        /// </summary>
        /// <param name="redisKey"></param>
        /// <param name="keyType"></param>
        public static void Del(string redisKey, string keyType = null)
        {
            string temp = AddKeyType(redisKey, keyType);
            RedisHelper.Del(temp);
        }
        /// <summary>
        /// 校验 Key 是否存在
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public static bool Exists(string redisKey, string keyType = null)
        {
            string temp = AddKeyType(redisKey, keyType);
            return RedisHelper.Exists(temp);
        }

        /// <summary>
        /// 设置过期时间
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public static void Expire(string redisKey, TimeSpan expiry, string keyType = null)
        {
            string temp = AddKeyType(redisKey, keyType);
            RedisHelper.Expire(temp, expiry);
        }

        /// <summary>
        /// 获取一个对象
        /// </summary>
        /// <param name="redisKey"></param>
        /// <returns></returns>
        public static T Get<T>(string redisKey, string keyType = null)
        {
            string temp = AddKeyType(redisKey, keyType);
            return RedisHelper.Get<T>(temp);
        }

        /// <summary>
        /// 删除同一类型下的key
        /// </summary>
        /// <param name="pattorn"></param>
        public static void DelKeys(string pattorn)
        {
            RedisHelper.Del(RedisHelper.Keys(pattorn));
        }
        /// <summary>
        /// 添加 Key 的前缀
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string AddKeyType(string key, string keyType)
        {
            if (!string.IsNullOrEmpty(keyType))
            {
                key = keyType + ":" + key;
            }
            return key;
        }

    }
}
