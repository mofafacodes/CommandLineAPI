using System.Collections.Generic;
using CommandLineAPI.Models;

namespace CommandLineAPI.Data
{
    public interface ICommandLineRepo
    {
        void CreateCommand(CommandLineModel command);
        bool SaveChanges();
        IEnumerable<CommandLineModel> GetAllCommands();
        CommandLineModel GetCommandById(int id);
        void DeleteCommand(CommandLineModel command);
        void UpdateCommand(CommandLineModel command);

    }
}