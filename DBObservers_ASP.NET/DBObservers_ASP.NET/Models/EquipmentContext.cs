using Microsoft.EntityFrameworkCore;

namespace DBObservers_ASP.NET.Models
{
    public sealed class EquipmentContext : DbContext
    {
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }

        public EquipmentContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EquipmentType>()
            //    .HasMany(e => e.Equipments)
            //    .WithOne();

            modelBuilder.Entity<Equipment>()
                .HasOne(e => e.EquipmentType)
                .WithMany(p => p.Equipments)
                .HasForeignKey(k => k.EquipmentTypeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
