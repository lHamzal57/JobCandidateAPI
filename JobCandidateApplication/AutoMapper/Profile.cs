using JobCandidate.Domain;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using JobCandidate.Domain.Entities;
using JobCandidate.Application.Models.ViewModel;

namespace JobCandidate
{
    public class CandidateProfile : AutoMapper.Profile
    {
        #region Properties
        public static IApplicationBuilder ApplicationBuilder { get; set; }
        #endregion

        public CandidateProfile()
        {
            CreateMap<Candidate, UpsertCandidateViewModel>().ReverseMap();
        }
    }
}