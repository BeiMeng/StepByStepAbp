using Abp.Authorization;
using BeiDream.SbsAbp.Zero.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.Zero.Common
{
    [AbpAuthorize]
    public class CommonAppService : SbsAbpAppServiceBase, ICommonAppService
    {
        /// <summary>
        /// 获取系统权限树
        /// </summary>
        /// <returns></returns>
        public PermissionDto GetAllPermissionTree()
        {
            var permissions = PermissionManager.GetAllPermissions();
            var Permissions = ObjectMapper.Map<List<PermissionDto>>(permissions).OrderBy(p => p.DisplayName).ToList();
            return Permissions.FirstOrDefault(p=>p.ParentName==null);
        }
    }
}
