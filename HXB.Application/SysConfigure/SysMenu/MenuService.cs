using Furion.DatabaseAccessor;
using Furion.DynamicApiController;
using Furion.UnifyResult;
using HXB.Core.ApplicationModel.SysConfigure.SysMenu;
using HXB.EntityFramework.Core.DbContextLocators;
using HXB.Tool.Tool;
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
        public RESTfulres<object> GetMenuList(int systemid)
        {
            var data = new RESTfulres<object>();
            try
            {
                var model = _reposit.SqlQuery<sys_menu>(@"select t.*,(select count(1) from sys_menu a where a.parentid=t.id) leaf from sys_menu t where t.systemid=@systemid and t.parentid is null", new { systemid = systemid});
                data= RESTfulres<object>.Success();
                data.Data = model;
            }
            catch (Exception ex)
            {
                data = RESTfulres<object>.Erro(ex.Message);
            }
            return data;
        }
        public RESTfulres<object> GetMenuList(int systemid,int? menuid) {
            var data= new RESTfulres<object>();
            try
            {
                var model = _reposit.SqlQuery<sys_menu>(@"select t.*,(select count(1) from sys_menu a where a.parentid=t.id) leaf from sys_menu t where t.systemid=@systemid and t.parentid=@menuid", new { systemid = systemid, menuid = menuid });
                data = RESTfulres<object>.Success();
                data.Data = model;
            }
            catch(Exception ex) {
                data = RESTfulres<object>.Erro(ex.Message);
            }
            return data;
        }
    }
}
