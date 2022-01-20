using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool.Tool
{
    public static class CheckHelper
    {
        /// <summary>
        /// 判断一个值是否为空
        /// </summary>
        /// <param name="val">校验值</param>
        /// <returns></returns>
        public static bool IsNull(object val)
        {
            //return val == null || DBNull.Value.Equals(val);
            if (DBNull.Value.Equals(val)) return true;
            if (val == null) return true;

            if (val is string)
            {
                if (string.IsNullOrEmpty(val as string)) return true;
            }
            return false;
        }
        /// <summary>
        /// 判断一个值是否为数字
        /// </summary>
        /// <param name="str">校验值</param>
        /// <returns></returns>
        public static bool IsNumeric(string str)
        {
            decimal d;
            return decimal.TryParse(str, out d);
        }

        /// <summary>
        /// 对象是否是一个数字类型的值
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(this object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }

        public static bool IsNumberType(Type type)
        {
            return type.Equals(typeof(sbyte))
                    || type.Equals(typeof(byte))
                    || type.Equals(typeof(short))
                    || type.Equals(typeof(ushort))
                    || type.Equals(typeof(int))
                    || type.Equals(typeof(uint))
                    || type.Equals(typeof(long))
                    || type.Equals(typeof(ulong))
                    || type.Equals(typeof(float))
                    || type.Equals(typeof(double))
                    || type.Equals(typeof(decimal));
        }

        /// <summary>
        /// 是否日期
        /// </summary>
        /// <param name="str">测试值</param>
        /// <param name="result">返回值</param>
        /// <returns></returns>
        public static bool IsDate(string str, out DateTime result)
        {
            string[] format = new string[] {
                "yyyy-MM-dd",
                "yyyy-MM-dd HH:mm:ss",
                "yyyy/MM/dd",
                "yyyy/MM/dd HH:mm:ss",
                DateTimeFormatInfo.CurrentInfo.ShortDatePattern,
                DateTimeFormatInfo.CurrentInfo.ShortDatePattern + " " + DateTimeFormatInfo.CurrentInfo.ShortTimePattern
            };

            if (DateTime.TryParseExact(str, format, System.Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None, out result)) return true;

            return DateTime.TryParse(str, System.Globalization.CultureInfo.CurrentCulture, DateTimeStyles.None, out result);
        }

        /// <summary>
        /// 是否是可空类型
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        public static bool IsNullAbleType(Type tp)
        {
            return tp.IsGenericType &&
                    tp.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
    }
}
