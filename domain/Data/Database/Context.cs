using System.Data.Entity;

namespace cm.backend.domain.Data.Database
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Data.Club> Clubs { get; set; }
    }
}
