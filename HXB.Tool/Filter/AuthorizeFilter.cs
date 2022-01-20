using Furion;
using HXB.Tool.Tool;
using HXB.Tool.ToolHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HXB.Tool.Filter
{
    public class AuthorizeFilter : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try{
                //返回结果
                RESTfulres<string> result = new RESTfulres<string>();
                ContentResult cResult = new ContentResult();
                bool flag = true;
                //获取请求携带的token
                string token= HttpContextHelper.heder(App.Configuration["Authorization"]);
                //获取请求对应的Action路径
                string querypath = context.ActionDescriptor.DisplayName.Substring(0, context.ActionDescriptor.DisplayName.IndexOf("(")).Trim().ToLower();
                flag = NoLoginAction(querypath);
                if (flag) {
                    if (!string.IsNullOrEmpty(token))
                    {
                        if (UserToolHelper.GetOnlineCert(token) == null) {
                            result.ResMsg = "登录超时，请重新登陆!";
                            result.Errors = "err-0001";
                            result.Extras = token;
                            cResult.Content = JsonConvert.SerializeObject(result);
                            cResult.StatusCode = 401;
                            context.Result = cResult;
                        } 
                    }
                    else {
                        result.ResMsg = "请登录!";
                        result.Extras = token;
                        result.Errors = "err-0001";
                        cResult.Content = JsonConvert.SerializeObject(result);

                        cResult.StatusCode = 401;
                        context.Result = cResult;
                    }
                }
            }
            catch(Exception ex) {
                ContentResult cResult = new ContentResult();
                cResult.Content = ex.Message;
                cResult.StatusCode = 500;
                context.Result = cResult;
            }
            await base.OnActionExecutionAsync(context, next);
        }
        public bool NoLoginAction(string querypath)
        {
            List<string> action = new List<string>();
            XDocument doc = XDocument.Load("CfgXml/NoLoginAction.xml");
            foreach (XElement nsNode in doc.Element("root").Elements().ToList())
            {
                if (nsNode.Attribute("value").Value.ToLower() == querypath) {
                    return false;
                }
            }
            return true;
        }
    }
}
