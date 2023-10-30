using Microsoft.EntityFrameworkCore;
using TaskVectoDigital.Models;

namespace TaskVectoDigital.AppContext
{

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Image> Images { get; set; }
        public DbSet<Effect> Effects { get; set; }
    }

}
