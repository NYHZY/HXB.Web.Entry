using HXB.Core.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool.Tool
{
    public static class DataConvert
    {
        public static JArray DataTableConvertJArry(DataTable dt) {
            JArray jarray = new JArray();
            foreach (DataRow dr in dt.Rows) {
                JObject item = new JObject();
                foreach (DataColumn dc in dt.Columns) {
                    var _val = dr[dc.ColumnName];
                    string colName = dc.ColumnName;
                    //item.Add(colName, new Newtonsoft.Json.Linq.JValue(_val));
                    if (DBNull.Value.Equals(_val))
                    {
                        item.Add(colName, "");
                    }
                    else
                    {
                        if (_val is string)
                        {
                            item.Add(colName, _val.ToString());
                        }
                        else if (_val is DateTime)
                        {
                            item.Add(colName, ((DateTime)_val).ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            item.Add(colName, new Newtonsoft.Json.Linq.JValue(_val));
                        }
                    }
                }
                jarray.Add(item);
            }
            return jarray;
        }
        public static T GetJsonPropValue<T>(string colname,int datatype,JObject jobj) {
            var prop = jobj.Properties().FirstOrDefault(item => item.Name.Equals(colname, StringComparison.OrdinalIgnoreCase));
            if (CheckHelper.IsNull(prop.Value)) return default(T);
            if (prop.Value is Newtonsoft.Json.Linq.JValue)
            {
                var v = (prop.Value as Newtonsoft.Json.Linq.JValue);
                if (CheckHelper.IsNull(v)) return default(T);
                return ChangeType<T>(v.Value);
            }
            else
            {
                return ChangeType<T>(prop.Value);
            }
        }
        /// <summary>
        /// 数据类型监测转换
        /// </summary>
        /// <param name="type">1、字符串 2、数字 3日期</param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ValueDbtype GetDbTypedValue(int type, object value, string field)
        {
            var _value = new ValueDbtype();
            _value.val = CheckHelper.IsNull(value) ? DBNull.Value : value;
            switch (type)
            {

                case 1:
                    _value.dbtype = DbType.Int32;
                    break;
                case 2:
                    _value.dbtype = DbType.DateTime;
                    break;
                default:
                    _value.dbtype = DbType.String;
                    break;
            }
            return _value;
        }
        public static DbType GetDbType(string colname,int datatype) {
            DbType dbType = new DbType();
            switch (datatype) {
                case 1:
                    dbType= DbType.Decimal;
                    break;
                case 2:
                    dbType = DbType.DateTimeOffset;
                    break;
                case 3:
                    dbType = DbType.String;
                    break;
            }
            return dbType;
            
        }
        /// <summary>
        /// 改变数据类型
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="v">原始值</param>
        /// <returns></returns>
        public static T ChangeType<T>(object v)
        {
            if (v == null || DBNull.Value.Equals(v)) return default(T);
            var tp = typeof(T);
            if (CheckHelper.IsNullAbleType(tp))
            {
                var baseType = getBaseType(tp);
                return (T)System.Convert.ChangeType(v, baseType);
            }
            return (T)System.Convert.ChangeType(v, tp);
        }

        public static Type getBaseType(Type tp)
        {
            if (tp.IsGenericType &&
                    tp.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                return tp.GetGenericArguments().First();
            }
            return null;
        }
        /// <summary>
        /// 获取一个类指定的属性值
        /// </summary>
        /// <param name="info">object对象</param>
        /// <param name="field">属性名称</param>
        /// <returns></returns>
        public static object GetPropertyValue(object info, string field)
        {
            if (info == null) return null;
            Type t = info.GetType();
            IEnumerable<System.Reflection.PropertyInfo> property = from pi in t.GetProperties() where pi.Name.ToLower() == field.ToLower() select pi;
            return property.First().GetValue(info, null);
        }
        public static JArray DataTableConvert(DataTable dt) {
            JArray ja = new JArray();
            for (int i = 0; i < dt.Rows.Count; i++) {
                JObject jo = new JObject();
                for (int j=0;j<dt.Columns.Count; j++) {
                    jo.Add(dt.Columns[j].ColumnName, dt.Rows[i][j].ToString());
                }
                ja.Add(jo);
            }
            return ja;
        }
    }
}
