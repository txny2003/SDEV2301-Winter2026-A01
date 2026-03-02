using System.ComponentModel.DataAnnotations;

namespace EfCoreBlazorDemo.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = "";

        [Required]
        public DateTime? DueDate { get; set; }

        public bool IsComplete { get; set; }
    }
}
