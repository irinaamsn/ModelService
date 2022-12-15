using System;
using System.Collections.Generic;
//using System.Data.Entity;
//using Microsoft.Extensions.Configuration;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace ImitModelBl.Model
{
    public class DataContext : DbContext
    {
        //public DataContext() : base("DbConnection") { }
        public DataContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.db");
        }
        #region 
        //protected readonly IConfiguration Configuration;

        //public DataContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to sql server with connection string from app settings
        //    options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
        //}
        //public DataContext(DbContextOptions<DataContext> options)
        //: base(options)
        //{
        //    Database.EnsureCreated();
        //}
        ////public DataContext() => 

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=helloapp.db");
        //}

        //protected readonly IConfiguration Configuration;

        //public DataContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to mysql with connection string from app settings
        //    var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //}
        //public DataContext()
        //{
        //    Database.EnsureCreated();
        //}
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql(
        //        "server=localhost;port=3306;user=root;password =''; database=ImitModel",
        //        new MySqlServerVersion(new Version(8, 0, 11))
        //    );
        //}
        //protected readonly IConfiguration Configuration;

        //public DataContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        //    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        //}
        #endregion
        public DbSet<Service> Services { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Check> Checks { get; set; }



    }
}
