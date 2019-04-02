using Abp.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BeiDream.SbsAbp.Demo.DemoTasks;
using BeiDream.SbsAbp.Zero.Authorization.Roles;
using BeiDream.SbsAbp.Zero.Authorization.Users;
using BeiDream.SbsAbp.Zero.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.EntityFrameworkCore
{
    /// <summary>
    /// Add-Migration InitialCreate
    /// Update-Database
    /// </summary>
    public class SbsAbpDbContext : AbpZeroDbContext<Tenant, Role, User, SbsAbpDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<DemoTask> DemoTasks { get; set; }
        public SbsAbpDbContext(DbContextOptions<SbsAbpDbContext> options)
            : base(options)
        {
        }
    }
}
