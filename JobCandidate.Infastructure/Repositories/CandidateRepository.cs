using JobCandidate.Domain.Entities;
using JobCandidate.Infrastructure.Data;
using JobCandidate.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using System;

namespace JobCandidate.Infrastructure.Repositories
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidateRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Candidate> GetByEmailAsync(string email)
        {
            if (_context.Candidates == null)
            {
                throw new InvalidOperationException("Candidates DbSet is not available.");
            }

            return await _context.Candidates
                                 .Include(c => c.BestTimeToCall)
                                 .FirstOrDefaultAsync(c => c.Email == email) ?? throw new Exception("invalid Email"); ;
        }

        public async Task AddAsync(Candidate candidate)
        {
            await _context.Candidates.AddAsync(candidate);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Candidate candidate)
        {
            _context.Candidates.Update(candidate);
            await _context.SaveChangesAsync();
        }

               

       
        
     
        

        
    }
}
