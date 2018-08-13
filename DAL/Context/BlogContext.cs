using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL.Context
{
    public class BlogContext: DbContext
    {

        public BlogContext() : base("BlogContext") { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }  
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }     
        public DbSet<Page> Pages { get; set; }       
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
            
            
            
            
            
            
            
            
            
            
            //  modelBuilder.Entity<User>()
            //.HasMany(r => r.Rooms)
            //.WithRequired(h => h.Hotel)
            //.HasForeignKey(h => h.HotelId)
            //.WillCascadeOnDelete();
            //modelBuilder.Ignore<Comments>();
            //modelBuilder.Entity<Comments>().ToTable("User");
            //base.OnModelCreating(modelBuilder);
        }


    }
}







//protected override void OnModelCreating(DbModelBuilder modelBuilder)
//{
//   // modelBuilder.Entity<Post>().ToTable("Posts");
//    base.OnModelCreating(modelBuilder);
//    // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
//}