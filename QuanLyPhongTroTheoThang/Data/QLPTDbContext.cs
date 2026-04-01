using System.Configuration;
using Microsoft.EntityFrameworkCore;
using QuanLyPhongTroTheoThang.Data;

public class QLPTDbContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            ConfigurationManager.ConnectionStrings["QLPTConnection"].ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Room>()
            .Property(p => p.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Contract>()
            .Property(p => p.Deposit)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Bill>()
            .Property(p => p.Total)
            .HasPrecision(18, 2);

        // ===== RELATION =====

        // Room - Contract (1-n)
        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Room)
            .WithMany(r => r.Contracts)
            .HasForeignKey(c => c.RoomID)
            .OnDelete(DeleteBehavior.Restrict);

        // Tenant - Contract (1-n)
        modelBuilder.Entity<Contract>()
            .HasOne(c => c.Tenant)
            .WithMany(t => t.Contracts)
            .HasForeignKey(c => c.TenantID)
            .OnDelete(DeleteBehavior.Restrict);

        // Contract - Bill (1-n) 
        modelBuilder.Entity<Bill>()
            .HasOne(b => b.Contract)
            .WithMany(c => c.Bills)
            .HasForeignKey(b => b.ContractID)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Bill>()
            .Property(p => p.RoomPrice)
            .HasPrecision(18, 2);
    }
}