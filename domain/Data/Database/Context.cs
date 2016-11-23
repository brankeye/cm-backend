using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace cm.backend.domain.Data.Database
{
    public class Context : DbContext
    {
        public Context() : base("MainConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Data.User> Users { get; set; }

        public DbSet<Data.AttendanceRecord> AttendanceRecords { get; set; }

        public DbSet<Data.CanceledClass> CanceledClasses { get; set; }

        public DbSet<Data.Class> Classes { get; set; }

        public DbSet<Data.Evaluation> Evaluations { get; set; }

        public DbSet<Data.EvaluationSection> EvaluationSections { get; set; }

        public DbSet<Data.Profile> Profiles { get; set; }

        public DbSet<Data.Member> Members { get; set; }

        public DbSet<Data.School> Schools { get; set; }
    }
}
