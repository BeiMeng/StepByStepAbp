using Abp.Application.Services;
using Abp.Authorization;
using BeiDream.SbsAbp.Zero.Common.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Zero.Common
{
    public interface ICommonAppService : IApplicationService
    {
        PermissionDto GetAllPermissionTree();
    }
}
