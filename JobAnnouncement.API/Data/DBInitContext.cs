using Microsoft.EntityFrameworkCore;

namespace JobAnnouncement.API.Data
{
    public class DBInitContext : DbContext
    {
        public DBInitContext(DbContextOptions<DBInitContext> options) : base(options)
        {
        }
    }
}
