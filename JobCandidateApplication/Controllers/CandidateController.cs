using JobCandidate.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using JobCandidate.Aplication;
using JobCandidate.Domain.Entities;

namespace SigmaSoftware.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly ILogger _logger;

        public CandidateController(ICandidateService candidateService, ILogger<CandidateController> logger)
        {
            _candidateService = candidateService;
            _logger = logger;
        }

        // POST: api/Candidates
        [HttpPost]
        public async Task<IActionResult> UpsertCandidate(Candidate candidate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (candidate.BestTimeToCall != null && !candidate.BestTimeToCall.IsValid())
                {
                    ModelState.AddModelError("BestTimeToCall", "End time must be after start time.");
                    return BadRequest(ModelState);
                }

                var result = await _candidateService.UpsertCandidateAsync(candidate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Candidate Already Exist")
                    return BadRequest(new { StatusCode = 8, ErrorMessage = "Candidate is Already Exist" });
                throw;
            }
        }

    }
}
