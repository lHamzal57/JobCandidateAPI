using System.Security.Claims;
using JobCandidate.Domain;
using JobCandidate.Domain.Entities;
using JobCandidate.Aplication;
using JobCandidate.Application.Models.ViewModel;
using JobCandidate.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace JobCandidate.Aplication.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CandidateService> _logger;

        public CandidateService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CandidateService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Candidate?> UpsertCandidateAsync(Candidate candidateDto)
        {
            _logger.LogInformation("UpsertCandidateAsync called");

            var candidate = _mapper.Map<Candidate>(candidateDto);
            var existingCandidate = await _unitOfWork.Candidates.GetByEmailAsync(candidate.Email);
            if (existingCandidate != null)
            {
                _logger.LogInformation("Updating existing candidate");
                _mapper.Map(candidateDto, existingCandidate);
                await _unitOfWork.Candidates.UpdateAsync(existingCandidate);
                await _unitOfWork.CompleteAsync();
                return _mapper.Map<Candidate>(existingCandidate);
            }
            else
            {
                _logger.LogInformation("Adding new candidate");
                await _unitOfWork.Candidates.AddAsync(candidate);
                await _unitOfWork.CompleteAsync();
                return _mapper.Map<Candidate>(candidate);
            }
        }
    }
}
