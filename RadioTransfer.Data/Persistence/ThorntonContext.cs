using SQLjobScheduler;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
//using SQLiteSample.Entities;
using Thornton.Data;

namespace SQLiteSample.Persistence
{
    public class ThorntonContext : DbContext
    {
        //public DbSet<Artist> Artists { get; set; }

        //public DbSet<Album> Albums { get; set; }

        //public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<TaskExecutionLog> TaskExecutionLogs { get; set; }
        public DbSet<SQLschedule> SQLschedules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Chinook Database does not pluralize table names
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();

        }
    }
}
