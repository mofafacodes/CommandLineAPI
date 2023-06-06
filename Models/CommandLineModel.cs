using System;
using System.ComponentModel.DataAnnotations;

namespace CommandLineAPI.Models
{
    
    public class CommandLineModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}