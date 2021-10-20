using Microsoft.EntityFrameworkCore;

namespace net6_api.Controllers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<MOCK_DATA> MOCK_DATA { get; set; }
    }
}
