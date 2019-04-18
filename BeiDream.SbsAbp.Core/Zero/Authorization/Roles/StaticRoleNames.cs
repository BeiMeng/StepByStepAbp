using System;
using System.Collections.Generic;
using System.Text;

namespace BeiDream.SbsAbp.Zero.Authorization.Roles
{
    public static class StaticRoleNames
    {
        public static class Host
        {
            //租主管理员角色(系统初始化,拥护全部权限,且不可被删除)
            public const string Admin = "Admin";
        }

        public static class Tenants
        {
            //租户管理员角色(系统初始化,拥护全部权限,且不可被删除)
            public const string Admin = "Admin";

            //租户默认角色(系统初始化,拥护默认的相关权限,且不可被删除）
            public const string User = "User";
        }
    }
}
