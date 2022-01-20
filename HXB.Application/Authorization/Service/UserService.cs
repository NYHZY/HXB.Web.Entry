using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.UnifyResult;
using HXB.Tool.Tool;
using HXB.EntityFramework.Core.DbContextLocators;
using HXB.Tool.Redis;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HXB.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HXB.Application.Authorization.Service
{
    [DynamicApiController]
    public class UserService
    {
        private readonly ISqlRepository<MsSqlDbContextLocator> _reposit;
        private readonly ILogger<UserService> _logger;
        public UserService(ISqlRepository<MsSqlDbContextLocator> reposit, ILogger<UserService> logger) {
            _reposit = reposit;
            _logger = logger;
        }
        [HttpGet]
        public RESTfulres<object> Login(string loginname,string loginpwd)
        {
            var res = new RESTfulres<object>();
            try {
                if (string.IsNullOrEmpty(loginname)) throw new Exception("登录账号不能为空");
                if (string.IsNullOrEmpty(loginpwd)) throw new Exception("登录密码不能为空");
                var model= _reposit.SqlQuery<UserInfo>(@"select * from sys_user where loginname=@loginname", new { loginname = loginname}).FirstOrDefault();
                if (model == null) throw new Exception("该登录账号不存在!");
                if(model.password!= loginpwd) throw new Exception("密码错误!");
                res = RESTfulres<object>.Success("登录成功");
                res.Data = UserTool.LoginData(model);
            } catch(Exception ex) {
                res = RESTfulres<object>.Erro(ex.Message);
                _logger.LogError(ex.Message);
            }
            return res;
        }
    }
    public class loginfo {
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
    }
}
