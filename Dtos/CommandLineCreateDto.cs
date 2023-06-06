using System.ComponentModel.DataAnnotations;

namespace CommandLineAPI.Dtos
{
    public class CommandLineCreateDto
    {
        //adding annotations to handle creation errors on the dto level
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}