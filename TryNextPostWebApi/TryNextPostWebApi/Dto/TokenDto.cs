namespace TryNextPostWebApi.Dto
{
    public class TokenDto
    {
        public string Token { get; set; } = string.Empty;
        public string? UserName { get; set; }
        public string? Message { get; set; }
    }
}
