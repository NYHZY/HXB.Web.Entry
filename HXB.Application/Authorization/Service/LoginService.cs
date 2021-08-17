using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.UnifyResult;
using HXB.Application.Authorization.Model;
using HXB.EntityFramework.Core.DbContextLocators;
using HXB.Tool.Redis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Application.Authorization.Service
{
    [DynamicApiController]
    public class LoginService
    {
        private readonly ISqlRepository<MsSqlDbContextLocator> _reposit;
        public LoginService(ISqlRepository<MsSqlDbContextLocator> reposit) {
            _reposit = reposit;
        }
        [HttpGet]
        public RESTfulResult<object> Login(string loginname,string loginpwd)
        {
            var cc = new RESTfulResult<object>();
            try {
                var model= _reposit.SqlQuery<UserInfo>(@"select * from sys_user where loginname=@loginname and password=@password", new { loginname = loginname, password = loginpwd }).FirstOrDefault();
                string token = Guid.NewGuid().ToString().Replace("-","");
                CsRedisHelper.Set(token, model, "login");
                cc.StatusCode = 200;
                cc.Succeeded = true;
                cc.Data = new { model= model,token=token };
            } catch(Exception ex) {
                cc.Succeeded = false;
            }
            return cc;
        }
    }
    public class loginfo {
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
    }
}
