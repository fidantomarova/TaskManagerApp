namespace TaskManagerApp.DTOs
{
    public class AuthResponseDto
    {
        //authentication response DTO
        public string Token { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
