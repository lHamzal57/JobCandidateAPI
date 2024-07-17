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

namespace JobCandidate.UnitTest.Controllers
{
    public class CandidateControllerTest
    {
        private readonly Mock<ICandidateService> _mockCandidateService;
        private readonly CandidateController _controller;
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<CandidateController>> _mockLogger;

        public CandidatesControllerTests()
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
            };

            //Mapping to entity
            var entity = candidateModel.ToAddEntity(this._mapper);

            _mockCandidateService.Setup(service => service.UpsertCandidateAsync(It.IsAny<Candidate>()))
                                 .ReturnsAsync(entity);

            // Act
            var result = await _controller.UpsertCandidate(entity);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            var returnValue = Assert.IsType<UpsertCandidateViewModel>(okResult.Value);
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
               
                LinkedInProfileUrl = "https://www.linkedin.com/in/se-mohamed-hamza/",
            };

            //Mapping to entity
            var entity = candidateModel.ToAddEntity(this._mapper);


            // Act
            var result = await _controller.UpsertCandidate(entity);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, badRequestResult.StatusCode);
        }
    }
}
