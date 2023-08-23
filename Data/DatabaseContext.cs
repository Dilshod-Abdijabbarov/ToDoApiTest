using Domian.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }
       public DbSet<TaskBase> Tasks { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<AddDueDate> AddDueDates { get; set; }
       public DbSet<AddFile> AddFiles { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<RepeatTime> RepeatTimes { get; set; }
    }
}
