using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeiDream.SbsAbp.Demo.DemoTasks.Dto
{
    public class CreateOrUpdateDemoTaskInput
    {
        [Required]
        public DemoTaskEditDto Item { get; set; }
    }
}
