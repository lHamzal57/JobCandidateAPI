using JobCandidate.Domain.Interfaces;
using JobCandidate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobCandidate.Infrastructure.Data;

namespace JobCandidate.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Candidates = new CandidateRepository(_context);
            Credentials = new AuthRepository(_context);
        }

        public ICandidateRepository Candidates { get; private set; }
        public IAuthRepository Credentials { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
