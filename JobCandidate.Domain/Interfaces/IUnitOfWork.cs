using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICandidateRepository Candidates { get; }
        IAuthRepository Credentials { get; }
        Task<int> CompleteAsync();
    }
}
