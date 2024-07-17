namespace JobCandidate.Application.Models.ViewModel
{
    public class UserLoggedInViewModel
    {
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public long ExpiresIn { get; set; }
        public string UsrerName {  get; set; }
        public string Password {  get; set; }
        public Guid Id { get; set; }        
    }
}
