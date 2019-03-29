using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeiDream.SbsAbp.Demo.DemoTasks.Dto
{
    public class DemoTaskEditDto: EntityDto<Guid?>
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        /// <summary>
        /// 任务数量
        /// </summary>
        [Range(1, int.MaxValue)]
        public int Count { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublish { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishTime { get; set; }
    }
}
