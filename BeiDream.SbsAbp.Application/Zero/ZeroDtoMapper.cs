﻿using Abp.Authorization;
using AutoMapper;
using BeiDream.SbsAbp.Zero.Authorization.Roles;
using BeiDream.SbsAbp.Zero.Authorization.Users;
using BeiDream.SbsAbp.Zero.Common.Dto;
using BeiDream.SbsAbp.Zero.Menus;
using BeiDream.SbsAbp.Zero.Menus.Dto;
using BeiDream.SbsAbp.Zero.MultiTenancy;
using BeiDream.SbsAbp.Zero.Sessions.Dto;
using BeiDream.SbsAbp.Zero.Users.Dto;
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
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());

            configuration.CreateMap<Role, AssignedUserRoleDto>();
            //Tenant
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();

            configuration.CreateMap<Menu, MenuDto>().ReverseMap();

            configuration.CreateMap<Permission, PermissionDto>();
        }
    }
}
