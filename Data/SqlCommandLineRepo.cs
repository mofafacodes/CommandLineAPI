using System.Collections.Generic;
using CommandLineAPI.Models;
using System.Linq;
using System;

namespace CommandLineAPI.Data
{
    //implementation class using  a db context
    public class SqlCommandLineRepo : ICommandLineRepo
    {
        private readonly CommandLineContext _context;
        public SqlCommandLineRepo(CommandLineContext context)
        {
            _context = context;
        }

        public void CreateCommand(CommandLineModel command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _context.Commands.Add(command);
        }

        public void DeleteCommand(CommandLineModel command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            _context.Commands.Remove(command);
        }

        public IEnumerable<CommandLineModel> GetAllCommands()
        {
            return _context.Commands.ToList();
        }
        
        public CommandLineModel GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            //operations  will only be replicated in the db of you this save changes
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(CommandLineModel command)
        {
            if(command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
        }
    }
}