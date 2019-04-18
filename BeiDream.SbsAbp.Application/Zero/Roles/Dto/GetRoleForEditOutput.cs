using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto item { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}
