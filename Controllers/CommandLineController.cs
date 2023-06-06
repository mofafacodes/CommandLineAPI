using System.Collections.Generic;
using AutoMapper;
using CommandLineAPI.Data;
using CommandLineAPI.Dtos;
using CommandLineAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CommandLineAPI.Controllers
{
    //decorating your controller class to get some default behavior out of the box
    [ApiController]
    //class or controller level route to give us a base route to controller methods
    [Route("api/commands")]
    public class CommandLineController : ControllerBase
    {
        // private readonly MockCommandLineRepo _repository = new MockCommandLineRepo();

        private readonly ICommandLineRepo _repository;
        private readonly IMapper _mapper;

        //DependencyInjection of the repository class
        public CommandLineController(ICommandLineRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //decoration each controller method with specific HTTP operations to be performed
        //GET /api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandLineReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            if (commandItems == null){
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<CommandLineReadDto>>(commandItems));
        }

        //GET api/commands/{id}
        //adding name to show it as the URI in the headers
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandLineReadDto> GetCommandById(int id)
        {
            //id is got from binding source set in the request
            var command = _repository.GetCommandById(id);
            if (command == null){
                return NotFound();
            }
            return Ok(_mapper.Map<CommandLineReadDto>(command));

        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandLineReadDto> CreateCommand(CommandLineCreateDto command)
        {
            var commandDto = _mapper.Map<CommandLineModel>(command);
            _repository.CreateCommand(commandDto);
            _repository.SaveChanges();
            //implementation of read dto
            var commandReadDto = _mapper.Map<CommandLineReadDto>(commandDto);
            //passing back the location of where the resource was created
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);

            //return Ok(commandReadDto);
        }

        //PUT api/command{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandLineUpdateDto command)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(command, commandFromRepo);
            _repository.UpdateCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/command/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandLineUpdateDto> patchDoc)
        {
            var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandLineUpdateDto>(commandFromRepo);
            //model state makes sure validations are valid
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandToPatch, commandFromRepo);
            _repository.UpdateCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }


        //DELETE api/command/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
             var commandFromRepo = _repository.GetCommandById(id);
            if (commandFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(commandFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    

    }
}