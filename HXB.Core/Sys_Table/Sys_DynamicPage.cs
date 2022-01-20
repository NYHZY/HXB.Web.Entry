using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    public class Sys_DynamicPage : BaseModel
    {
        public Sys_DynamicPage(){
            this.ColInfo = new List<Sys_DynamicCol>();
            this.ButtonInfo = new List<Sys_DynamicBtn>();
        }
        /// <summary>
        /// 界面名称
        /// </summary>
        public string PageName { get; set; }
        /// <summary>
        /// 是否开启复选框
        /// </summary>
        public int IsCheckbox { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int RowNo { get; set; }
        /// <summary>
        /// 是否可以新增
        /// </summary>
        public int IsAdd { get; set; }
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public int IsEdit { get; set; }
        /// <summary>
        /// 是否可删除
        /// </summary>
        public int IsDel { get; set; }
        /// <summary>
        /// 数据获取sql
        /// </summary>
        public string DataSourceSql { get; set; }
        /// <summary>
        /// 数据源表名
        /// </summary>
        public string DataSourceTable { get; set; }
        /// <summary>
        /// 选择模式，单选or多选
        /// </summary>
        public int SelectMode { get; set; }
        /// <summary>
        /// 数据显示条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public int IsVaild { get; set; }
        /// <summary>
        /// 公共属性
        /// </summary>
        public string PublicAttribute { get; set; }
        /// <summary>
        /// 编辑表达式
        /// </summary>
        public string EditCondition { get; set; }
        /// <summary>
        /// 删除表达式
        /// </summary>
        public string DelCondition { get; set; }
        /// <summary>
        /// 新增表达式
        /// </summary>
        public string AddCondition { get; set; }
        /// <summary>
        /// 数据列配置信息
        /// </summary>
        public List<Sys_DynamicCol> ColInfo { get; set; }
        /// <summary>
        /// 表单按钮情况
        /// </summary>
        public List<Sys_DynamicBtn> ButtonInfo { get; set; }
    }
}
