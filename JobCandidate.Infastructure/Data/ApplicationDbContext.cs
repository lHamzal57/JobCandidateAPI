using Microsoft.EntityFrameworkCore;
using JobCandidate.Domain.Entities;
using System.Security.Claims;

namespace JobCandidate.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


           
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Candidate>()
                .OwnsOne(c => c.BestTimeToCall);
        }

     

    }
}
