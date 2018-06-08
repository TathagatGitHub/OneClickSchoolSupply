using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace OneClickSchoolSupply.Models
{
    public class SchoolKitContext: DbContext
    {
        public SchoolKitContext() : base("DefaultConnection") 
        {
            Database.SetInitializer<SchoolKitContext>(new DropCreateDatabaseIfModelChanges<SchoolKitContext>());

            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseIfModelChanges<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new DropCreateDatabaseAlways<SchoolDBContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }
         public DbSet<SchoolKit> SchoolKits {get;set;}
         public DbSet<KitItem> KitItems { get; set; }
         public DbSet<Cart> Carts { get; set; }
         public DbSet<Order> Orders { get; set; }
         public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}