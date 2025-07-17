namespace TaskManagerApp.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; } 
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
