using JobCandidate.Domain;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using JobCandidate.Domain.Entities;
using JobCandidate.Application.Models.ViewModel;
using AutoMapper;

namespace JobCandidate
{
    public class CandidateProfile : Profile
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