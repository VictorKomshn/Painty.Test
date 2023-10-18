using Microsoft.EntityFrameworkCore;
using Painty.Test.Database.Entities;
using Painty.Test.Database.EntityContext;

namespace Painty.Test.Database.Context
{
    public class DataContext : DbContext
    {

        public DbSet<UserEntity> Users { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
