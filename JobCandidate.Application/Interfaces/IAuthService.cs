using JobCandidate.Application.Models.ViewModel;

namespace JobCandidate.Aplication
{
    public interface IAuthService
    {
        UserLoggedInViewModel Login(LoginViewModel model);
    }
}
