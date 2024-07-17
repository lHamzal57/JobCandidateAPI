using JobCandidate.Domain.Entities;

namespace JobCandidate.Domain
{
    public interface ICandidateRepository
    {
        Task<Candidate> GetByEmailAsync(string email);
        Task AddAsync(Candidate candidate);
        Task UpdateAsync(Candidate candidate);
    }
}
