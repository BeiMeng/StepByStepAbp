using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using BeiDream.SbsAbp.Zero.Authorization.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Authorization.Users
{
    public class UserClaimsPrincipalFactory : AbpUserClaimsPrincipalFactory<User, Role>
    {
        public UserClaimsPrincipalFactory(
            UserManager userManager,
            RoleManager roleManager,
            IOptions<IdentityOptions> optionsAccessor) 
            : base(userManager, 
                  roleManager, 
                  optionsAccessor)
        {
        }
    }
}
