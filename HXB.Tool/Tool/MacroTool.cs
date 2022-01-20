using HXB.Tool.ToolHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HXB.Tool.Tool
{
    public static class MacroTool
    {
        public static Regex[] requestParamRegex = new Regex[]
       {
            new Regex(@"req\s*\(\s*""([^""]+)\s*""\)",RegexOptions.IgnoreCase),
            new Regex(@"req\s*\(\s*'([^']+)\s*'\)",   RegexOptions.IgnoreCase)
       };
        //不校验关键属性
        public static Regex[] requestParamRegex1 = new Regex[]
       {
            new Regex(@"req1\s*\(\s*""([^""]+)\s*""\)",RegexOptions.IgnoreCase),
            new Regex(@"req1\s*\(\s*'([^']+)\s*'\)",   RegexOptions.IgnoreCase)
       };
        public static string MacroInit(string _src)
        {

            if (string.IsNullOrEmpty(_src)) return "";
            _src = _src.SysDay().SysDate().SysUserId().Request().Request1();
            //  return SysDay().SysDate().Request().Request1().CustomMacro().SysId().SysUserId().Sql().PurTableExp()._source;
            //_src = SysDay(_src);
            //_src = SysDate(_src);
            //_src = Request(_src);
            //_src = Request1(_src);
            //_src = CustomMacro(_src, _conn, _systemid);
            //_src = SysId(_src);
            //_src = SysUserId(_src);
            //_src = Sql(_src, _conn, _systemid);
            //_src = PurTableExp(_src, _conn, _systemid);

            return _src;
        }
        /// <summary>
        /// 日期替换
        /// </summary>
        /// <returns></returns>
        public static string SysDay(this string _src) {
            if ("sysday()".Equals(_src, StringComparison.OrdinalIgnoreCase))
            {
                _src = DateTime.Now.ToString("yyyy-MM-dd");
            }
            return _src;
        }
        /// <summary>
        /// 替换系统时间
        /// </summary>
        /// <returns></returns>
        private static string SysDate(this string _src)
        {
            if (string.IsNullOrEmpty(_src)) return "";
            if ("sysdate()".Equals(_src, StringComparison.OrdinalIgnoreCase))
            {
                _src = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return _src;
        }
        /// <summary>
        /// 替换
        /// </summary>
        /// <returns></returns>
        private static string Request(this string _src)
        {
            if (string.IsNullOrEmpty(_src)) return "";
            if (ToolHelper.HttpContextHelper.Current != null)
            {

                Func<string, string> func = (name) =>
                {
                    var v = ToolHelper.HttpContextHelper.Request(name);
                    SqlFilter2(v);
                    return v;
                };

                foreach (var reg in requestParamRegex)
                {
                    var match = reg.Match(_src);
                    while (match.Success)
                    {
                        var varVal = func(match.Groups[1].Value);
                        _src = _src.Replace(match.Value, varVal);
                        match = reg.Match(_src);
                    }
                }
            }
            return _src;
        }
        private static string Request1(this string _src)
        {
            if (string.IsNullOrEmpty(_src)) return "";
            if (HttpContextHelper.Current == null)
            {

                Func<string, string> func = (name) =>
                {
                    var v = HttpContextHelper.Request(name);
                    SqlFilter1(v);
                    return v;
                };

                foreach (var reg in requestParamRegex1)
                {
                    var match = reg.Match(_src);
                    while (match.Success)
                    {
                        var varVal = func(match.Groups[1].Value);
                        _src = _src.Replace(match.Value, varVal);
                        match = reg.Match(_src);
                    }
                }
            }
            return _src;
        }
        private static void SqlFilter2(string InText)
        {
            if (!string.IsNullOrEmpty(InText) && InText != null)
            {

                string word = "and|exec|insert|select|delete|update|chr|mid|master|or|truncate|char|declare|join|create|in|not";

                foreach (string i in word.Split('|'))
                {
                    if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1))
                    {
                        throw new Exception("[" + InText + "]存在非法字符(" + i + ")");
                    }
                }
            }
        }

        private static void SqlFilter1(string InText)
        {
            if (!string.IsNullOrEmpty(InText) && InText != null)
            {

                string word = "exec|insert|delete|update|chr|mid|master|truncate|char|declare|create";

                foreach (string i in word.Split('|'))
                {
                    if ((InText.ToLower().IndexOf(i + " ") > -1) || (InText.ToLower().IndexOf(" " + i) > -1))
                    {
                        throw new Exception("[" + InText + "]存在非法字符(" + i + ")");
                    }
                }
            }
        }
        /// <summary>
        /// 获取登录用户Id
        /// </summary>
        /// <returns></returns>
        private static string SysUserId(this string _src)
        {
            if (string.IsNullOrEmpty(_src)) return "";
            var patterns = new string[] { @"sysuserid\(\)" };

            foreach (var parttern in patterns)
            {
                Regex reg = new Regex(parttern, RegexOptions.IgnoreCase);
                var match = reg.Match(_src);
                while (!Match.Empty.Equals(match))
                {

                    string value = UserToolHelper.UserInfo.id.ToString();
                    _src = _src.Replace(match.Value, value);
                    match = reg.Match(_src);
                }
            }
            return _src;
        }
    }
}
