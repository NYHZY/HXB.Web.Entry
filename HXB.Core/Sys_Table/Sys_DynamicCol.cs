using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    public class Sys_DynamicCol
    {
        /// <summary>
        /// 字段name（英文）
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 字段名（中文）
        /// </summary>
        public string ColumnText { get; set; }
        /// <summary>
        /// 表格显示
        /// </summary>
        public int TableDisplay { get; set; }
        /// <summary>
        /// 表单显示
        /// </summary>
        public int FormDisplay { get; set; }
        /// <summary>
        /// 是否必填
        /// </summary>
        public int IsRequired { get; set; }
        /// <summary>
        /// 是否只读
        /// </summary>
        public int IsReadonly { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public int ColumnWidth { get; set; }
        /// <summary>
        /// 列编辑框类型
        /// </summary>
        public int ColumnType { get; set; }
        /// <summary>
        /// 数据类型
        /// </summary>
        public int DataType { get; set; }
        /// <summary>
        /// 下拉数组
        /// </summary>
        public string SelectData { get; set; }
        /// <summary>
        /// 公共属性
        /// </summary>
        public string PublicAttribute { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }
        /// <summary>
        /// 字段转换
        /// </summary>
        public string ValueTransform { get; set; }
        /// <summary>
        /// 列
        /// </summary>
        public int ColumnValue { get; set; }
        /// <summary>
        /// 行
        /// </summary>
        public int RowValue { get; set; }
        /// <summary>
        /// 是否绑定
        /// </summary>
        public int IsBind { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Orderby { get; set; }
        /// <summary>
        /// 是否查询
        /// </summary>
        public int IsQuery { get; set; }
        /// <summary>
        /// 表格渲染
        /// </summary>
        public string TabRender { get; set; }
        /// <summary>
        /// 查询类别
        /// </summary>
        public string QueryType { get; set; }
        /// <summary>
        /// 查询扩展
        /// </summary>
        public string QueryExtend { get; set; }
        /// <summary>
        /// 是否为主键
        /// </summary>
        public int PrimaryKey { get; set; }
        /// <summary>
        /// 对齐方式
        /// </summary>
        public int AlignType { get; set; }
        /// <summary>
        /// 显示表达式
        /// </summary>
        public string DisplayExpression { get; set; }
        /// <summary>
        /// 编辑表达式
        /// </summary>
        public string EidtExpression { get; set; }
        
    }
}
