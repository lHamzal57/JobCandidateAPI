using JobCandidate.Application.Models.ViewModel;
using JobCandidate.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobCandidate.Aplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IPasswordHasherService passwordHasherService,IAuthRepository authRepository, IConfiguration configuration)
        {
            _passwordHasherService = passwordHasherService;
            _authRepository = authRepository;
            _configuration = configuration; 
        }

        public UserLoggedInViewModel Login(LoginViewModel model)
        {
            UserLoggedInViewModel viewModel = new UserLoggedInViewModel();

            var cred = _authRepository.GetByuserNameAsync(model.UserName);

            if (_passwordHasherService.VerifyPassword(cred, cred.Password, model.Password))
            {
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier,cred.Id.ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var SignIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(60),
                    signingCredentials: SignIn
                    );

                viewModel.TokenType = "Bearer";
                viewModel.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
                return viewModel;
            }

            else
                throw new Exception("Invalid Password");


        }
    }
}
