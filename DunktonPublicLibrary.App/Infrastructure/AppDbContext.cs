
using DunktonPublicLibrary.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DunktonPublicLibrary.App.Infrastructure;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Magazine> Magazines { get; set; }
    public DbSet<VideoCassette> VideoCassettes { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().ToTable(nameof(Role));
        modelBuilder.Entity<Role>().HasKey(r => r.Id).HasName("PK_Role");
        modelBuilder.Entity<Role>().Property(r => r.Name).IsRequired().HasMaxLength(DataConstants.ROLE_NAME_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE);
        modelBuilder.Entity<Role>().Property(r => r.Id).HasConversion(i => i.Value, i => Identifer<Role>.CreateFromData(i));

        modelBuilder.Entity<Genre>().ToTable(nameof(Genre));
        modelBuilder.Entity<Genre>().HasKey(g => g.Id).HasName("PK_Genre");
        modelBuilder.Entity<Genre>().Property(g => g.Name).IsRequired().HasMaxLength(DataConstants.GENRE_NAME_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE);
        modelBuilder.Entity<Genre>().Property(g => g.Id).HasConversion(i => i.Value, i => Identifer<Genre>.CreateFromData(i));

        modelBuilder.Entity<Book>().ToTable(nameof(Book));
        modelBuilder.Entity<Book>().HasKey(b => b.Id).HasName("PK_Book");
        modelBuilder.Entity<Book>().Property(b => b.Id).HasConversion(i => i.Value, i => Identifer<Material>.CreateFromData(i));
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Genre)
            .WithMany(g => g.Materials.Cast<Book>())
            .HasForeignKey(e => e.GenreId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Book_Genre");
        modelBuilder.Entity<Book>()
            .ComplexProperty(b => b.BookInfo).Property(b => b.Author).IsRequired().HasMaxLength(DataConstants.AUTHOR_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.AUTHOR_COLUMN);
        modelBuilder.Entity<Book>()
            .ComplexProperty(b => b.BookInfo).Property(m => m.Description).IsRequired().HasMaxLength(DataConstants.DESCRIPTION_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.DESCRIPTION_COLUMN);
        modelBuilder.Entity<Book>()
            .ComplexProperty(b => b.BookInfo).Property(m => m.PublicationYear).IsRequired().HasMaxLength(DataConstants.PUBLICATION_YEAR_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).IsFixedLength(true).HasColumnName(DataConstants.PUBLICATION_YEAR_COLUMN);

        modelBuilder.Entity<Magazine>().ToTable(nameof(Magazine));
        modelBuilder.Entity<Magazine>().HasKey(m => m.Id).HasName("PK_Magazine");
        modelBuilder.Entity<Magazine>().Property(m => m.Id).HasConversion(i => i.Value, i => Identifer<Material>.CreateFromData(i));
        modelBuilder.Entity<Magazine>()
            .HasOne(b => b.Genre)
            .WithMany(g => g.Materials.Cast<Magazine>())
            .HasForeignKey(e => e.GenreId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Magazine_Genre");
        modelBuilder.Entity<Magazine>()
            .ComplexProperty(m => m.MagazineInfo).Property(m => m.IssueNumber).IsRequired().HasMaxLength(DataConstants.ISSUE_NUMBER_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.ISSUE_NUMBER_COLUMN);
        modelBuilder.Entity<Magazine>()
            .ComplexProperty(m => m.MagazineInfo).Property(m => m.PublicationMonth).IsRequired().HasMaxLength(DataConstants.PUBLICATION_MONTH_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.PUBLICATION_MONTH_COLUMN);
        modelBuilder.Entity<Magazine>()
            .ComplexProperty(m => m.MagazineInfo).Property(m => m.PublicationYear).IsRequired().HasMaxLength(DataConstants.PUBLICATION_YEAR_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).IsFixedLength(true).HasColumnName(DataConstants.PUBLICATION_YEAR_COLUMN);

        modelBuilder.Entity<VideoCassette>().ToTable(nameof(VideoCassette));
        modelBuilder.Entity<VideoCassette>().HasKey(v => v.Id).HasName("PK_VideoCassette");
        modelBuilder.Entity<VideoCassette>().Property(v => v.Id).HasConversion(i => i.Value, i => Identifer<Material>.CreateFromData(i));
        modelBuilder.Entity<VideoCassette>()
            .HasOne(b => b.Genre)
            .WithMany(g => g.Materials.Cast<VideoCassette>())
            .HasForeignKey(e => e.GenreId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_VideoCassette_Genre");
        modelBuilder.Entity<VideoCassette>()
            .ComplexProperty(v => v.VideoCassetteInfo).Property(v => v.Director).IsRequired().HasMaxLength(DataConstants.DIRECTOR_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.DIRECTOR_COLUMN);
        modelBuilder.Entity<VideoCassette>()
            .ComplexProperty(v => v.VideoCassetteInfo).Property(v => v.Rating).IsRequired().HasMaxLength(DataConstants.RATING_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).HasColumnName(DataConstants.RATING_COLUMN);
        modelBuilder.Entity<VideoCassette>()
            .ComplexProperty(v => v.VideoCassetteInfo).Property(v => v.ReleaseYear).IsRequired().HasMaxLength(DataConstants.RELEASE_YEAR_MAX_LENGTH).IsUnicode(DataConstants.IS_UNICODE).IsFixedLength().HasColumnName(DataConstants.RELEASE_YEAR_COLUMN);

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
