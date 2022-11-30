using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostfix = "Command";

        public string Read(string args)
        {
            string[] commandItems = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandItems[0] + CommandPostfix;
            string[] items = commandItems.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type[] types = assembly.GetTypes();
            Type type = types.FirstOrDefault(x => x.Name == commandName);
            object instance = Activator.CreateInstance(type);

            ICommand command = (ICommand)instance;
            return command.Execute(items);
        }
    }
}
