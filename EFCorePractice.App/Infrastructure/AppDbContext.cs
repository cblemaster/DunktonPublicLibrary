
using EFCorePractice.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCorePractice.App.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().ToTable(nameof(Role));
        modelBuilder.Entity<Role>().HasKey(r => r.Id).HasName("PK_Role");
        modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(30).IsUnicode(false);
        
        modelBuilder.Entity<Account>().ToTable(nameof(Account));
        modelBuilder.Entity<Account>().HasKey(a => a.Id).HasName("PK_Account");
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Role)
            .WithMany(a => a.Accounts)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Account_Role");
        modelBuilder.Entity<Account>()
            .Ignore(a => a.Token);
        modelBuilder.Entity<Account>()
            .Property(a => a.Username).IsRequired().HasMaxLength(16).IsUnicode(false);
        modelBuilder.Entity<Account>()
            .Property(a => a.PasswordHash).IsRequired().HasMaxLength(255).IsUnicode(false);
        modelBuilder.Entity<Account>()
            .Property(a => a.PasswordSalt).IsRequired().HasMaxLength(255).IsUnicode(false);
        modelBuilder.Entity<Account>()
            .Property(a => a.FirstName).IsRequired().HasMaxLength(50).IsUnicode(false);
        modelBuilder.Entity<Account>()
            .Property(a => a.LastName).IsRequired().HasMaxLength(50).IsUnicode(false);
        modelBuilder.Entity<Account>()
            .HasIndex(a => a.Username).IsUnique();
    }
}
