using System.ComponentModel.DataAnnotations;

namespace CommandLineAPI.Dtos
{
    public class CommandLineUpdateDto
    {
        //adding annotations to handle update errors on the dto level
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}