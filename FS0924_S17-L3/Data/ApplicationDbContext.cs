using FS0924_S17_L3.Models;
using Microsoft.EntityFrameworkCore;

namespace FS0924_S17_L3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Lending> Lendings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // relazione uno a molti genere-libri
            modelBuilder.Entity<Book>().HasOne(g => g.Genre).WithMany(b => b.Books);

            modelBuilder.Entity<Genre>().HasMany(b => b.Books).WithOne(g => g.Genre);

            // relazione uno a molti prestito-libri
            modelBuilder.Entity<Lending>().HasOne(b => b.Book).WithMany(l => l.Lendings);

            modelBuilder.Entity<Book>().HasMany(l => l.Lendings).WithOne(b => b.Book);

            // relazione uno a molti prestito-utenti
            modelBuilder.Entity<Lending>().HasOne(u => u.User).WithMany(l => l.Lendings);

            modelBuilder.Entity<User>().HasMany(l => l.Lendings).WithOne(u => u.User);

            // default value per user IsAdmin
            modelBuilder.Entity<User>().Property(u => u.IsAdmin).HasDefaultValueSql("0");

            // default value per lending Active
            modelBuilder.Entity<Lending>().Property(l => l.Active).HasDefaultValueSql("1");
        }
    }
}
