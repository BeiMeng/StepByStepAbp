using Abp.EntityFrameworkCore;
using BeiDream.SbsAbp.Demo.DemoTasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.EntityFrameworkCore
{
    public class SbsAbpDbContext : AbpDbContext
    {
        public DbSet<DemoTask> DemoTasks { get; set; }
        public SbsAbpDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
