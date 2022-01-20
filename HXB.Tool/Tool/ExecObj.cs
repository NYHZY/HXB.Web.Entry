using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXB.Tool.Tool
{
    public enum ExecObj
    {
        /// <summary>
        /// 新增前
        /// </summary>
        BeforeAdd=1,
        /// <summary>
        /// 新增后
        /// </summary>
        AfterAdd=2,
        /// <summary>
        /// 修改前
        /// </summary>
        BeforeUpdate=3,
        /// <summary>
        /// 修改后
        /// </summary>
        AfterUpdate=4,
        /// <summary>
        /// 删除前
        /// </summary>
        BeforeDelete=5,
        /// <summary>
        /// 删除后
        /// </summary>
        AfterDelete=6,
        /// <summary>
        /// 保存前
        /// </summary>
        BeforeSave=7,
        /// <summary>
        /// 保存后
        /// </summary>
        AfterSave=8,
        /// <summary>
        /// 执行前
        /// </summary>
        BeforeExec=9,
        /// <summary>
        /// 执行后
        /// </summary>
        AfterExec=10
    }
}
