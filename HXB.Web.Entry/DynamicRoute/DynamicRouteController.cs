using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HXB.Web.Entry.DynamicRoute
{
    public class DynamicRouteController : Controller
    {
        /// <summary>
        /// 路由转发
        /// </summary>
        /// <returns></returns>
        public ActionResult DriveMethod()
        {
            var actionName = HttpContext.Items["ActionName"].ToString();
            var controllerName = HttpContext.Items["ControllerName"].ToString();
            ActionResult result=null;
            try
            {
                //result = _datadriven.GetAction(controllerName, actionName);
            }
            catch (Exception ex)
            {
                //ex = LoggerHelper.ExceptionHandling(ex);
                return Content(ex.Message);
            }
            return result;
        }
    }
}
