using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Users.Dto
{
    public class GetUserForEditOutput
    {
        public UserEditDto Item { get; set; }

        public List<AssignedUserRoleDto> Roles { get; set; }
    }
}
