using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Users.Dto
{
    public class CreateOrUpdateUserInput
    {
        [Required]
        public UserEditDto Item { get; set; }

        [Required]
        public string[] AssignedRoleNames { get; set; }

        public bool SetRandomPassword { get; set; }

    }
}
