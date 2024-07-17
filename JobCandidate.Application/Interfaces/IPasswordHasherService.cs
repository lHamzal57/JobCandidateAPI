using JobCandidate.Domain.Entities;

namespace JobCandidate.Aplication
{
    public interface IPasswordHasherService
    {
        public string HashPassword(string password);
        public bool VerifyPassword(Auth cred, string hashedPassword, string providedPassword);
    }
}
