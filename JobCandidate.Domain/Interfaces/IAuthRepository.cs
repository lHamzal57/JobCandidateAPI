using JobCandidate.Domain.Entities;

namespace JobCandidate.Domain
{
    public interface IAuthRepository
    {
        Auth GetByuserNameAsync(string userName);
    }
}
