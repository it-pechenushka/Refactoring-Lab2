using Client.Commands;
using Client.Exceptions;

namespace Client
{
    public static class CommandHandler
    {
        public static Command HandleCommandType(string command)
        {
            return command switch
            {
                "add" => new AddCommand(),
                "list" => new ListCommand(),
                "del" => new DeleteCommand(),
                "search" => new SearchCommand(),
                _ => throw new InvalidCommandParamsException("Invalid command!")
            };
        }
    }
}