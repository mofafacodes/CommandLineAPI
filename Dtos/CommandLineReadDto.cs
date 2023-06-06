using System;
namespace CommandLineAPI.Dtos
{
    
    public class CommandLineReadDto
    {
        public int Id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; }
        //taking out platform dto to implement some form of abstraction
       // public string Platform { get; set; }
    }
}