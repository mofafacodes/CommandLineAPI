using System.Collections.Generic;
using CommandLineAPI.Models;

namespace CommandLineAPI.Data
{
    //implement of interface allows the decoupling of code
    public class MockCommandLineRepo : ICommandLineRepo
    {
        public CommandLineModel GetCommandById(int id)
        {
            var command = new CommandLineModel{ Id = 0, HowTo = "Start the boiler", Line = "Boiler Operation", Platform = "Boiler Room"};
            
            return command;
        }

        public IEnumerable<CommandLineModel> GetAllCommands()
        {
            var allCommands = new List<CommandLineModel>
            {
                new CommandLineModel{ Id = 0, HowTo = "Start the boiler", Line = "Boiler Operation", Platform = "Boiler Room"},
                new CommandLineModel{ Id = 1, HowTo = "Start the engine", Line = "Engine Operation", Platform = "Engine Room"},
                new CommandLineModel{ Id = 2, HowTo = "Start the car", Line = "Car Operation", Platform = "Garage Room"},
                new CommandLineModel{ Id = 3, HowTo = "Start the movie", Line = "Camera Operation", Platform = "Cinema Room"}

            };

            return allCommands;
        }

        public void CreateCommand(CommandLineModel command)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(CommandLineModel command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(CommandLineModel command)
        {
            throw new System.NotImplementedException();
        }
    }
}