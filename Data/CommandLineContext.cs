using CommandLineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandLineAPI.Data
{
    public class CommandLineContext: DbContext
    {
        public CommandLineContext(DbContextOptions<CommandLineContext> options) : base(options)
        {

        }

        //creating a representation of the command line model
        public DbSet<CommandLineModel> Commands { get; set; }
    }
}