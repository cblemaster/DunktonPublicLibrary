
using DunktonPublicLibrary.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DunktonPublicLibrary.App.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().ToTable(nameof(Role));
        modelBuilder.Entity<Role>().HasKey(r => r.Id).HasName("PK_Role");
        modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(30).IsUnicode(false);
        modelBuilder.Entity<Role>().Property(r => r.Id).HasConversion(i => i.Value, i => Identifer<Role>.CreateFromData(i));

        modelBuilder.Entity<Account>().ToTable(nameof(Account));
        modelBuilder.Entity<Account>().HasKey(a => a.Id).HasName("PK_Account");
        modelBuilder.Entity<Account>().Property(a => a.Id).HasConversion(i => i.Value, i => Identifer<Account>.CreateFromData(i));
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Role)
            .WithMany(a => a.Accounts)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Account_Role");
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Credentials).Property(c => c.Username).IsRequired().HasMaxLength(16).IsUnicode(false).HasColumnName("Username");
        modelBuilder.Entity<Account>()
            .Ignore(a => a.Token);
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Credentials).Property(c => c.PasswordHash).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("PasswordHash");
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Credentials).Property(c => c.PasswordSalt).IsRequired().HasMaxLength(255).IsUnicode(false).HasColumnName("PasswordSalt");
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Names).Property(c => c.FirstName).IsRequired().HasMaxLength(50).IsUnicode(false).HasColumnName("FirstName");
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Names).Property(c => c.LastName).IsRequired().HasMaxLength(50).IsUnicode(false).HasColumnName("LastName");
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Dates).Property(c => c.CreateDate).IsRequired().HasColumnName("CreateDate");
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Dates).Property(c => c.UpdateDate).HasColumnName("UpdateDate");
        //modelBuilder.Entity<Account>()
        //    .HasIndex(a => a.Credentials.Username).IsUnique();  // TODO: Is this even possible in ef core?
    }
}
