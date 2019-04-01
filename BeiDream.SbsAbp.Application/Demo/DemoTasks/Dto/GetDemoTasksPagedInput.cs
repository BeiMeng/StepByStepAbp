using Abp.Runtime.Validation;
using BeiDream.SbsAbp.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Demo.DemoTasks.Dto
{
    public class GetDemoTasksPagedInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Name { get; set; }
        public bool IsPublish { get; set; }
        public string Sorting { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "CreationTime";
            }
        }
    }
}
