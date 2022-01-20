using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Core.Sys_Table
{
    public class Sys_DynamicBtn: BaseModel
    {
        /// <summary>
        /// 按钮名称
        /// </summary>
        public string BtnText { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int RowNo { get; set; }
        /// <summary>
        /// 应用按钮
        /// </summary>
        public int RefBtn { get; set; }
        /// <summary>
        /// 按钮事件
        /// </summary>
        public string BtnEvent { get; set; }
        /// <summary>
        /// 其他属性
        /// </summary>
        public string OtherAttr { get; set; }
        /// <summary>
        /// 渲染表达式
        /// </summary>
        public string RenderExp { get; set; }
        /// <summary>
        /// 渲染方式
        /// </summary>
        public int RenderType { get; set; }
        /// <summary>
        /// 按钮所属类别，表单 or 表格
        /// </summary>
        public int Type { get; set; }
    }
}
