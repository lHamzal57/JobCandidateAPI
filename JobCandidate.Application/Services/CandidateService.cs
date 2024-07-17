using System.Security.Claims;
using JobCandidate.Domain;
using JobCandidate.Domain.Entities;
using JobCandidate.Aplication;

namespace JobCandidate.Aplication
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;

        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

       
        public async Task<Candidate> UpsertCandidateAsync(Candidate candidate)
        {
            var existingCandidate = await _candidateRepository.GetByEmailAsync(candidate.Email);
            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.Phone = candidate.Phone;
                existingCandidate.BestTimeToCall = candidate.BestTimeToCall;
                existingCandidate.LinkedInProfileUrl = candidate.LinkedInProfileUrl;
                existingCandidate.GitHubProfileUrl = candidate.GitHubProfileUrl;
                existingCandidate.FreeTextComment = candidate.FreeTextComment;

                await _candidateRepository.UpdateAsync(existingCandidate);
                return existingCandidate;
            }
            else
            {
                await _candidateRepository.AddAsync(candidate);
                return candidate;
            }
        }
    }
}
