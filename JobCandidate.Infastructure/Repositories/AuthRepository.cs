using JobCandidate.Domain.Entities;
using JobCandidate.Infrastructure.Data;
using JobCandidate.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using System;


namespace JobCandidate.Infrastructure.Repositories
{
    public class AuthRepository  : IAuthRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Auth GetByuserNameAsync(string userName)
        {
            return _context.credentials
                        .FirstOrDefault(x => x.Username == userName) ?? throw new Exception("invalid Username");
        }
    }
}
