using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeiDream.SbsAbp.EntityFrameworkCore
{
    public class SbsAbpDbContext : AbpDbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public SbsAbpDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
