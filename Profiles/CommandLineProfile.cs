using AutoMapper;
using CommandLineAPI.Dtos;
using CommandLineAPI.Models;

namespace CommandLineAPI.Profiles
{
    public class CommandLineProfile : Profile
    {

        public CommandLineProfile()
        {
       //create map command to map between a source object and a destination object
       //Source -> target
            CreateMap<CommandLineModel, CommandLineReadDto>();
            CreateMap<CommandLineCreateDto, CommandLineModel>();
            CreateMap<CommandLineUpdateDto, CommandLineModel>();
            CreateMap<CommandLineModel, CommandLineUpdateDto>();

        }

    }
}