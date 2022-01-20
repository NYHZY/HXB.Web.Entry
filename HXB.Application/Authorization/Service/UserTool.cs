using HXB.Core.Entities;
using HXB.Tool.Redis;
using HXB.Tool.ToolHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Application.Authorization.Service
{
    public static class UserTool
    {
        public static object LoginData(UserInfo userInfo) {
            string token = Guid.NewGuid().ToString().Replace("-", "");
            userInfo.token = token;
            UserToolHelper.CreateOnlineCert(userInfo);
            return new
            {
                loginname = userInfo.loginname,
                realname = userInfo.realname,
                nickname = userInfo.nickname,
                phone = userInfo.phone,
                age = userInfo.age,
                sex = userInfo.sex,
                token = token
            };
        }
    }
}
