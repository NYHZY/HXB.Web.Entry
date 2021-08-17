using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using HXB.Application.Service;
using HXB.Core.Entities;
using HXB.EntityFramework.Core.DbContextLocators;
using HXB.Tool.Redis;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Application
{
    [DynamicApiController]
    public class TestService
    {
        private readonly ILogger<TestService> _logger;
        /// <summary>
        /// Get方法
        /// </summary>
        /// <returns></returns>
        public TestService(ILogger<TestService>  logger)
        {
            
            _logger = logger;
        }

        public string Get() {
            // 往Redis里面存入数据
            CsRedisHelper.Set("Name:lastname", "Tom");
            // 从Redis里面取数据
            string name = CsRedisHelper.Get<string>("Name");
            _logger.LogError("日志记录");
            return name;
        }
    }
}
