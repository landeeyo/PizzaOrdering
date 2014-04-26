using Landeeyo.Pizza.Common.Models.AccountControl;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.DataAccessLayer.EntityConfig
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContextConnectionString")
        {
        }

        //public DatabaseContext(string connectionString)
        //    : base(connectionString)
        //{
        //}

        //public DatabaseContext()
        //{
        //    this.Database.Connection.ConnectionString = "Data Source=WIN7NETDEV-PC;Initial Catalog=Pizza;Persist Security Info=True;User ID=sa;Password=sa";
        //}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
