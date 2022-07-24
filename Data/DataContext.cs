using Microsoft.EntityFrameworkCore;
using MVC_Web_Api.models;

namespace MVC_Web_Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<models.Product> Products { get; set; }
 
        //public  DbSet<models.Auth>Auths { get; set; }
        public DbSet<models.driver> Drivers { get; set; }
        //public  DbSet<models.Auth>Auths { get; set; }
        public DbSet<MVC_Web_Api.models.Orders>? Orders { get; set; }
        //public  DbSet<models.Auth>Auths { get; set; }
        public DbSet<MVC_Web_Api.models.Auth>? Auth { get; set; }
        //public  DbSet<models.Auth>Auths { get; set; }
        public DbSet<MVC_Web_Api.models.OrderList>? OrderList { get; set; }
        //public DbSet <models.vehicle> Vehicles { get; set; }
        //public DbSet<models.Orders> Orders { get; set; }
    }
}
