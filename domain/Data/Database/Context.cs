using System.Data.Entity;

namespace cm.backend.domain.Data.Database
{
    public class Context : DbContext
    {
        public Context() : base("MainConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Data.Club> Clubs { get; set; }
    }
}
