using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace GraphQLTest
{
    public class DBContext : DbContext
    {

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        [Description("Collection of companies")]
        public virtual DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
