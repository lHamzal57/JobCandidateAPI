using Microsoft.EntityFrameworkCore;
using JobCandidate.Domain.Entities;
using System.Security.Claims;
using JobCandidate.Aplication;

namespace JobCandidate.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        private readonly IPasswordHasherService _passwordHasherService;

        public ApplicationDbContext(DbContextOptions options,
            IPasswordHasherService passwordHasherService)
            : base(options)
        {
            _passwordHasherService = passwordHasherService;
        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Auth> credentials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Seed data
            var credentialId = Guid.NewGuid();


            modelBuilder.Entity<Auth>().HasData(
                new Auth
                {
                    Id = credentialId,
                    Username = "admin",
                    Password = _passwordHasherService.HashPassword("123456") // Note: Passwords should be hashed in a real application
                }
            );


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Candidate>()
                .OwnsOne(c => c.BestTimeToCall);
        }

     

    }
}
