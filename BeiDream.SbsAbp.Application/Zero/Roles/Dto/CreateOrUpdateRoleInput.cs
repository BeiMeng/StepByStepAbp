using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Roles.Dto
{
    public class CreateOrUpdateRoleInput
    {
        [Required]
        public RoleEditDto Item { get; set; }
        [Required]
        public List<string> GrantedPermissionNames { get; set; }
    }
}
