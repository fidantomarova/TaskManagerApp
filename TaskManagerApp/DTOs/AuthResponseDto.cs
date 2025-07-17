namespace TaskManagerApp.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool IsSuccess { get; set; }     
        public string Message { get; set; } = null!;
    }
}
