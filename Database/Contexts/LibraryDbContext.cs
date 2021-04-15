using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Database.Contexts
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>().ToTable("Books");
            builder.Entity<Book>().HasKey(p => p.Id);
            builder.Entity<Book>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Book>().Property(p => p.Title).IsRequired();
            builder.Entity<Book>().Property(p => p.Edition);
            builder.Entity<Book>().Property(p => p.ISBN);
            builder.Entity<Book>().Property(p => p.SubjectId).IsRequired();
            builder.Entity<Book>().Property(p => p.Year).IsRequired();

            builder.Entity<Author>().ToTable("Authors");
            builder.Entity<Author>().HasKey(p => p.Id);
            builder.Entity<Author>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Author>().Property(p => p.LastName).IsRequired();
            builder.Entity<Author>().Property(p => p.FirstName);
            builder.Entity<Author>().Property(p => p.MiddleName);
            builder.Entity<Author>().HasMany(p => p.Books).WithOne(p => p.Author).HasForeignKey(p => p.AuthorId);

            builder.Entity<Subject>().ToTable("Subjects");
            builder.Entity<Subject>().HasKey(p => p.Id);
            builder.Entity<Subject>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subject>().Property(p => p.ParentSubject).IsRequired();
            builder.Entity<Subject>().Property(p => p.SubjectName).IsRequired();
            builder.Entity<Subject>().HasMany(p => p.Books).WithOne(p => p.Subject).HasForeignKey(p => p.SubjectId);

            builder.Entity<Author>().HasData
            (
                new Author { Id = 1, LastName = "Juster", FirstName = "Norton" }, //Setting ID for in-memory test database
                new Author { Id = 2, LastName = "Adams", FirstName = "Douglas" }
            );

            builder.Entity<Subject>().HasData
            (
                new Subject { Id = 1, ParentSubject = 0, SubjectName = "Fiction" }, //Setting ID for in-memory test database
                new Subject { Id = 2, ParentSubject = 1, SubjectName = "Youth" },
                new Subject { Id = 3, ParentSubject = 1, SubjectName = "Comedy" }
            );

            builder.Entity<Book>().HasData
            (
                new Book { Id = 1, Title = "The Phantom Tollbooth", Year = 1961, AuthorId = 1, SubjectId = 2 }, //Setting ID for in-memory test database
                new Book { Id = 2, Title = "The Hitchhiker's Guide to the Galaxy", Year = 1978, AuthorId = 2, SubjectId = 3 }
            );
        }
    }
}
