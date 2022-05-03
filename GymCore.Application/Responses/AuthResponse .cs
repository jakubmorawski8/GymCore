namespace GymCore.Application.Responses
{
    public class AuthResponse : BaseResponse
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
    }
}
