namespace PhoneBook.DAL.EF.Provider
{
    using Microsoft.EntityFrameworkCore;
    using PhoneBook.Domain.Entities;

    public partial class PhoneBookContext : DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneBook>().ToTable("PhoneBook");
            modelBuilder.Entity<Entry>().ToTable("Entry");
        }

        public virtual DbSet<PhoneBook> PhoneBooks { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
    }
}
