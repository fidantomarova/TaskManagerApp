namespace TaskManagerApp.DTOs
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Pasword { get; set; } = null!;
    }
}
