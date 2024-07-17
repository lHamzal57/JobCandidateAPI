using JobCandidate.Application.Models.ViewModel;
using JobCandidate.Domain.Entities;

namespace JobCandidate.Aplication
{
    public interface ICandidateService
    {
        public Task<Candidate> UpsertCandidateAsync(Candidate candidate);
    }
}
