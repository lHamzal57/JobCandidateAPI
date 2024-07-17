
using JobCandidate.Application.Models.ViewModel;
using JobCandidate.Domain.Entities;

namespace JobCandidate
{
    public static class Extensions
    {
        #region Candidate
        public static Candidate ToAddEntity(this UpsertCandidateViewModel model, AutoMapper.IMapper mapper)
        {
            var result = mapper.Map<UpsertCandidateViewModel, Candidate>(model);
            return result;
        }
        public static UpsertCandidateViewModel ToAddModel(this Candidate entity, AutoMapper.IMapper mapper)
        {
            var result = mapper.Map<Candidate, UpsertCandidateViewModel>(entity);
            return result;
        }
        #endregion

       
    }
}
