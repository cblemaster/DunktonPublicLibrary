
using DunktonPublicLibrary.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DunktonPublicLibrary.App.Infrastructure;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().ToTable(nameof(Role));
        modelBuilder.Entity<Role>().HasKey(r => r.Id).HasName("PK_Role");
        modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(DataConstants.ROLE_NAME_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE);
        modelBuilder.Entity<Role>().Property(r => r.Id).HasConversion(i => i.Value, i => Identifer<Role>.CreateFromData(i));

        modelBuilder.Entity<Account>().ToTable(nameof(Account));
        modelBuilder.Entity<Account>().HasKey(a => a.Id).HasName("PK_Account");
        modelBuilder.Entity<Account>().Property(a => a.Id).HasConversion(i => i.Value, i => Identifer<Account>.CreateFromData(i));
        modelBuilder.Entity<Account>()
            .HasOne(a => a.Role)
            .WithMany(r => r.Accounts)
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Account_Role");
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Credentials).Property(c => c.Username).IsRequired().HasMaxLength(DataConstants.USERNAME_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.USERNAME_COLUMN);
        modelBuilder.Entity<Account>()
            .Ignore(a => a.Token);
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Credentials).Property(c => c.PasswordHash).IsRequired().HasMaxLength(DataConstants.PASSWORD_HASH_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.PASSWORD_HASH_COLUMN);
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Credentials).Property(c => c.PasswordSalt).IsRequired().HasMaxLength(DataConstants.PASSWORD_SALT_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.PASSWORD_SALT_COLUMN);
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Names).Property(c => c.FirstName).IsRequired().HasMaxLength(DataConstants.FIRST_NAME_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.FIRST_NAME_COLUMN);
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Names).Property(c => c.LastName).IsRequired().HasMaxLength(DataConstants.LAST_NAME_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.LAST_NAME_COLUMN);
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Dates).Property(c => c.CreateDate).IsRequired().HasColumnName(DataConstants.CREATE_DATE_COLUMN);
        modelBuilder.Entity<Account>()
            .ComplexProperty(a => a.Dates).Property(c => c.UpdateDate).HasColumnName(DataConstants.UPDATE_DATE_COLUMN);
        //modelBuilder.Entity<Account>()
        //    .HasIndex(a => a.Credentials.Username).IsUnique();  // TODO: Is this even possible in ef core?
    }
}
