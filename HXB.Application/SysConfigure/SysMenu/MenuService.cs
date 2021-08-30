using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.UnifyResult;
using HXB.Core.ApplicationModel.SysConfigure.SysMenu;
using HXB.EntityFramework.Core.DbContextLocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Application.SysConfigure.SysMenu
{
    [DynamicApiController]
    public class MenuService
    {
        private readonly ISqlRepository<MsSqlDbContextLocator> _reposit;
        public MenuService(ISqlRepository<MsSqlDbContextLocator> reposit)
        {
            _reposit = reposit;
        }
        public RESTfulResult<object> GetMenuList(int systemid)
        {
            var data = new RESTfulResult<object>();
            try
            {
                var model = _reposit.SqlQuery<sys_menu>(@"select t.*,(select count(1) from sys_menu a where a.parentid=t.id) leaf from sys_menu t where t.systemid=@systemid and t.parentid is null", new { systemid = systemid});
                data.Data = model;
                data.StatusCode = 200;
                data.Succeeded = true;
            }
            catch (Exception ex)
            {
                data.Errors = ex.Message;
            }
            return data;
        }
        public RESTfulResult<object> GetMenuList(int systemid,int? menuid) {
            var data= new RESTfulResult<object>();
            try
            {
                var model = _reposit.SqlQuery<sys_menu>(@"select t.*,(select count(1) from sys_menu a where a.parentid=t.id) leaf from sys_menu t where t.systemid=@systemid and t.parentid=@menuid", new { systemid = systemid, menuid = menuid });
                data.Data = model;
                data.StatusCode = 200;
                data.Succeeded = true;
            }
            catch(Exception ex) {
                data.Errors = ex.Message;
            }
            return data;
        }
    }
}
