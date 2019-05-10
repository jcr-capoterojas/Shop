

namespace Shop.Web.Date
{
    using Microsoft.EntityFrameworkCore;
    using Shop.Web.Date.Entities;

    public class DataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)//Para que se conete a la base de datso
        {

        }
    }
}
