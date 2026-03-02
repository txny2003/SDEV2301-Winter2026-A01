using System.ComponentModel.DataAnnotations;

namespace EfCoreBlazorDemo.Models
{
    public class Poll
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string City { get; set; } = "";

        [Required]
        public string? Candidate { get; set; }

        [Range(0, 100)]
        public int ConfidenceLevel { get; set; }
    }
}
