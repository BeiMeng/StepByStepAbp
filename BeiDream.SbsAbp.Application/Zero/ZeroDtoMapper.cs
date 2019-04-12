using AutoMapper;
using BeiDream.SbsAbp.Zero.Authorization.Users;
using BeiDream.SbsAbp.Zero.Menus;
using BeiDream.SbsAbp.Zero.Menus.Dto;
using BeiDream.SbsAbp.Zero.MultiTenancy;
using BeiDream.SbsAbp.Zero.Sessions.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero
{

    public class ZeroDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //User
            configuration.CreateMap<User, UserLoginInfoDto>();
            //Tenant
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();

            configuration.CreateMap<Menu, MenuDto>().ReverseMap();
        }
    }
}
