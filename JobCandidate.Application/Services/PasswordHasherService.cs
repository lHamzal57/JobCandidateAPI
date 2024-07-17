using JobCandidate.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace JobCandidate.Aplication.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private readonly PasswordHasher<Auth> _passwordHasher;

        public PasswordHasherService()
        {
            _passwordHasher = new PasswordHasher<Auth>();
        }

        public string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<Auth>();
            var cred = new Auth(); 
            return passwordHasher.HashPassword(cred, password);
        }

        public bool VerifyPassword(Auth cred, string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(cred, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
