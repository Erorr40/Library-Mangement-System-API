using Microsoft.EntityFrameworkCore;

namespace Library_Mangement_System.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LibraryMangementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);
            modelBuilder.Entity<Member>()
                .HasMany(m => m.BorrowRecords)
                .WithMany(b => b.Members);
            modelBuilder.Entity<Book>()
                .HasMany(b => b.BorrowRecords)
                .WithMany(e => e.Books);
            

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Science Fiction" },
                new Category { Id = 2, Name = "Fantasy" },
                new Category { Id = 3, Name = "Mystery" },
                new Category { Id = 4, Name = "Romance" },
                new Category { Id = 5, Name = "Non-Fiction" }
            );
            modelBuilder.Entity<BorrowRecord>().HasData(
                new BorrowRecord { Id = 1, BorrowDate = DateTime.Now },
                new BorrowRecord { Id = 2, BorrowDate = DateTime.Now.AddDays(-5), ReturnDate = DateTime.Now.AddDays(-1) }
            );
            modelBuilder.Entity<Member>().HasData(
                new Member
                {
                    Id = 1,
                    FullName = "Ahmed Ali",
                    Email = "ahmed.ali@mail.com"
                }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "book1",
                    Author = "Abo ali",
                    PublicationYear = 1965,
                    Price = 9.99m,
                    AvailableCopies = 5,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "The Book",
                    Author = "The Father of Book",
                    PublicationYear = 1937,
                    Price = 7,
                    AvailableCopies = 3,
                    CategoryId = 2
                }
            );

        }
    }
}
