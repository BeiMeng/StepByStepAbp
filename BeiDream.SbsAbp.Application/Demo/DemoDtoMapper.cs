using AutoMapper;
using BeiDream.SbsAbp.Demo.DemoTasks;
using BeiDream.SbsAbp.Demo.DemoTasks.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp
{
    public class DemoDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //DemoTask 
            configuration.CreateMap<DemoTask, DemoTaskEditDto>().ReverseMap();
            configuration.CreateMap<DemoTask, DemoTaskListDto>();
        }
    }
}
