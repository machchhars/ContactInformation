using ContactInformationManagement.Common.Model;
using Microsoft.EntityFrameworkCore;


namespace ContactInformationManagement.DAL
{
    public class ContactInformatonDbContext : DbContext
    {
        public ContactInformatonDbContext(DbContextOptions<ContactInformatonDbContext> options) : base(options)
        {

        }

        public DbSet<ContactDetail> ContactDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactDetail>()
            .HasIndex(p => new { p.Email },"IX_Email").IsUnique();

            modelBuilder.Entity<ContactDetail>()
            .HasIndex(p => new { p.PhoneNumber }, "IX_PhoneNumber").IsUnique();
        }
    }
}
