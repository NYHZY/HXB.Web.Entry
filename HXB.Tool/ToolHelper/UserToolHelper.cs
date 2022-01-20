using Furion;
using HXB.Core.Entities;
using HXB.Tool.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool.ToolHelper
{
    public static class UserToolHelper
    {
        /// <summary>
        /// 创建在线凭证
        /// </summary>
        public static void CreateOnlineCert(UserInfo userInfo)
        {
            double timeout = 1000 * 60 * double.Parse(App.Configuration["LoginModel:TimeOut"]);
            CsRedisHelper.Set(userInfo.token, userInfo, TimeSpan.FromMilliseconds(timeout), App.Configuration["LoginModel:KeyType"]);
        }
        /// <summary>
        /// 获取用户登录凭证信息
        /// </summary>
        /// <returns></returns>
        public static UserInfo GetOnlineCert()
        {
            UserInfo info = new UserInfo();
            string token = GetToken();
            if (!string.IsNullOrEmpty(token))
            {
                info = GetOnlineCert(token);
            }

            return info;
        }
        /// <summary>
        /// 获取登录凭证Key
        /// </summary>
        /// <returns></returns>
        public static string GetToken()
        {
            string tokenName = App.Configuration["Authorization"];
            if (string.IsNullOrEmpty(tokenName)) throw new Exception("配置文件中Authorization属性未正确配置");

            string token = HttpContextHelper.heder(tokenName);

            return token;
        }
        /// <summary>
        /// 获取用户登录凭证信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static UserInfo GetOnlineCert(string token)
        {
            UserInfo info = new UserInfo();

            if (!string.IsNullOrEmpty(token))
            {
                string keyType = App.Configuration["LoginModel:KeyType"];
                info = CsRedisHelper.Get<UserInfo>(token, keyType);
                //更新token时间
                double timeout = 1000 * 60 * double.Parse(App.Configuration["LoginModel:TimeOut"]);
                CsRedisHelper.Expire(token, TimeSpan.FromMilliseconds(timeout), keyType);
            }

            return info;
        }
        /// <summary>
        /// 获取用户登录凭证
        /// </summary>
        public static UserInfo UserInfo
        {
            get
            {
                return GetOnlineCert();
            }

        }
    }
}
