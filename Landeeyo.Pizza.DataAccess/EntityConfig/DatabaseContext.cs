using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.Common.Models.Log;
using Landeeyo.Pizza.Common.Models.PizzaManagement;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Landeeyo.Pizza.DataAccessLayer.EntityConfig
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContextConnectionString")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> Pizzas { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
