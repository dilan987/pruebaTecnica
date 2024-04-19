using Domain.Entities;
using Domain.ValuesObjects.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace Infrastructure

{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(o =>
            {
                o.HasKey(x => x.Id);
                o.OwnsOne(x => x.Name).Property(x => x.Value).HasColumnName("Name");
                o.OwnsOne(x => x.Email).Property(x => x.Value).HasColumnName("Email");
                o.OwnsOne(x => x.Password).Property(x => x.Value).HasColumnName("Password");
                o.OwnsOne(x => x.Type).Property(x => x.Value).HasColumnName("Type");

            });

            modelBuilder.Entity<Order>(o =>
            {
                o.HasKey(x => x.Id);
                o.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
                o.OwnsOne(x => x.OrderDate).Property(x => x.Value).HasColumnName("OrderDate");
                o.OwnsOne(x => x.Status).Property(x => x.Value).HasColumnName("Status");
                o.Property(e => e.OrderData)
            .HasColumnName("OrderData")
            .IsRequired()
            .HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<ProductOrder>>(v),
                new ValueComparer<List<ProductOrder>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));

            });

            modelBuilder.Entity<Product>(o =>
            {
                o.HasKey(x => x.Id);
                o.OwnsOne(x => x.Name).Property(x => x.Value).HasColumnName("Name");
                o.OwnsOne(x => x.Description).Property(x => x.Value).HasColumnName("Description");
                o.OwnsOne(x => x.Price).Property(x => x.Value).HasColumnName("Price");
                o.OwnsOne(x => x.QuantityAvailable).Property(x => x.Value).HasColumnName("QuantityAvailable");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}