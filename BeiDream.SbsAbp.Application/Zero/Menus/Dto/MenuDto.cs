using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Menus.Dto
{
    public class MenuDto:EntityDto<Guid?>
    {
        public virtual Guid? ParentId { get; set; }

        /// <summary>
        /// 对应定义的路由Name
        /// </summary>
        [Required]
        public virtual string Name { get; set; }
        /// <summary>
        /// 对应路由path
        /// </summary>
        [StringLength(100)]
        public virtual string Url { get; set; }

        /// <summary>
        /// 显示的名称
        /// </summary>
        [StringLength(50)]
        [Required]
        public virtual string DisplayName { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        [StringLength(200)]
        [Required]
        public virtual string PermissionName { get; set; }

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
