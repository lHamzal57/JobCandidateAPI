using AutoMapper;
using JobCandidate.Aplication.Services;
using JobCandidate.Application.Models.ViewModel;
using JobCandidate.Domain.Entities;
using JobCandidate.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace JobCandidate.UnitTest.Services
{
    public class CandidateServiceTest
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CandidateService _candidateService;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<CandidateService>> _mockLogger;

        public CandidateServiceTest()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<CandidateService>>();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new JobCandidate.CandidateProfile());
            });
            _mapper = config.CreateMapper();

            _candidateService = new CandidateService(_mockUnitOfWork.Object, _mapper, _mockLogger.Object);
        }

        [Fact]
        public async Task UpsertCandidateAsync_ShouldAddNewCandidate_WhenCandidateDoesNotExist()
        {
            // Arrange
            var candidateDto = new Candidate
            {
                FirstName = "Mohamed",
                LastName = "Hamza",
                Phone = "123-456-7890",
                Email = "mohamed.hamza@smarttechsys.com",
                BestTimeToCall = new TimeInterval
                {
                    Start = new TimeSpan(9, 0, 0),
                    End = new TimeSpan(17, 0, 0)
                },
                LinkedInProfileUrl = "https://www.linkedin.com/in/se-mohamed-hamza/",
                GitHubProfileUrl = "https://github.com/lHamzal57",
                FreeTextComment = "Looking forward to discussing this opportunity."
            };

            _mockUnitOfWork.Setup(uow => uow.Candidates.GetByEmailAsync(candidateDto.Email))
                           .ReturnsAsync((Candidate)null);

            // Act
            var result = await _candidateService.UpsertCandidateAsync(candidateDto);

            // Assert
            _mockUnitOfWork.Verify(uow => uow.Candidates.AddAsync(It.IsAny<Candidate>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CompleteAsync(), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(candidateDto.Email, result.Email);
        }

        [Fact]
        public async Task UpsertCandidateAsync_ShouldUpdateExistingCandidate_WhenCandidateExists()
        {
            // Arrange
            var candidateDto = new Candidate
            {
                FirstName = "Mohamed",
                LastName = "Hamza",
                Phone = "123-456-7890",
                Email = "mohamed.hamza@smarttechsys.com",
                BestTimeToCall = new TimeInterval
                {
                    Start = new TimeSpan(9, 0, 0),
                    End = new TimeSpan(17, 0, 0)
                },
                LinkedInProfileUrl = "https://www.linkedin.com/in/se-mohamed-hamza/",
                GitHubProfileUrl = "https://github.com/lHamzal57",
                FreeTextComment = "Looking forward to discussing this opportunity."
            };

            var existingCandidate = new Candidate
            {
                FirstName = "Existing",
                LastName = "Candidate",
                Phone = "000-000-0000",
                Email = "mohamed.hamza@smarttechsys.com",
                BestTimeToCall = new TimeInterval
                {
                    Start = new TimeSpan(10, 0, 0),
                    End = new TimeSpan(18, 0, 0)
                }
            };

            _mockUnitOfWork.Setup(uow => uow.Candidates.GetByEmailAsync(candidateDto.Email))
                           .ReturnsAsync(existingCandidate);

            // Act
            var result = await _candidateService.UpsertCandidateAsync(candidateDto);

            // Assert
            _mockUnitOfWork.Verify(uow => uow.Candidates.UpdateAsync(It.IsAny<Candidate>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CompleteAsync(), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(candidateDto.Email, result.Email);
        }
    }
}