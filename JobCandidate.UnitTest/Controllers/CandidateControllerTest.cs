using AutoMapper;
using JobCandidate.Aplication;
using JobCandidate.Application.Models.ViewModel;
using JobCandidate.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SigmaSoftware.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace JobCandidate.UnitTest.Controllers
{
    public class CandidateControllerTest
    {
        private readonly Mock<ICandidateService> _mockCandidateService;
        private readonly CandidateController _controller;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<CandidateController>> _mockLogger;

        public CandidateControllerTest()
        {
            _mockCandidateService = new Mock<ICandidateService>();
            _mockLogger = new Mock<ILogger<CandidateController>>();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new JobCandidate.CandidateProfile());
            });
            _mapper = config.CreateMapper();

            _controller = new CandidateController(_mockCandidateService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task UpsertCandidate_ShouldReturnOkResult_WhenModelStateIsValid()
        {
            // Arrange
            var candidateModel = new UpsertCandidateViewModel
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

            var entity = _mapper.Map<Candidate>(candidateModel);

            _mockCandidateService.Setup(service => service.UpsertCandidateAsync(It.IsAny<Candidate>()))
                                 .ReturnsAsync(entity);

            // Act
            var result = await _controller.UpsertCandidate(entity);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            var returnValue = Assert.IsType<Candidate>(okResult.Value);
            Assert.Equal(entity.Email, returnValue.Email);
        }

        [Fact]
        public async Task UpsertCandidate_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("FirstName", "Required");

            var candidateModel = new UpsertCandidateViewModel
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

            var entity = _mapper.Map<Candidate>(candidateModel);

            // Act
            var result = await _controller.UpsertCandidate(entity);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }
    }
}
