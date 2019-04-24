using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.GeneralTree;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Menus
{
    public class Menu : FullAuditedEntity<Guid>, IGeneralTree<Menu, Guid>
    {
        /// <summary>
        /// 对应定义的路由Name
        /// </summary>
        [StringLength(100)]
        public virtual string Name { get; set; }

        public virtual string FullName { get; set; }

        public virtual string Code { get; set; }

        public virtual int Level { get; set; }

        public virtual Menu Parent { get; set; }

        public virtual Guid? ParentId { get; set; }

        public virtual ICollection<Menu> Children { get; set; }

        /// <summary>
        /// 对应路由path
        /// </summary>
        [StringLength(100)]
        public virtual string Url { get; set; }

        /// <summary>
        /// 显示的名称
        /// </summary>
        [StringLength(50)]
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// 图标样式
        /// </summary>
        [StringLength(100)]
        public virtual string IconClass { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Order { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        [StringLength(200)]
        public virtual string PermissionName { get; set; }

        /// <summary>
        /// 样式为分组的标识(Url为null时可配置)
        /// </summary>
        public virtual bool Group { get; set; }

        /// <summary>
        /// 是否为默认显示页(Url不为null时可设置，同时其所有上级均与其保持同步)
        /// </summary>
        public virtual bool Default { get; set; }

        /// <summary>
        /// 是否是首页标识
        /// </summary>
        public virtual bool IsHome { get; set; }
        /// <summary>
        /// tab页签显示时配置页签是否显示关闭按钮
        /// </summary>
        public virtual bool NotClose { get; set; }

    }
}
