﻿using System;
using System.Collections.Generic;
using System.Text;

namespace T03.CommandPattern
{
    internal class ModifyPrice
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;

        public ModifyPrice()
        {
            _commands = new List<ICommand>();
        }
        public void SetCommand(ICommand command) => _command = command;
        public void Invoke()
        {
            _commands.Add(_command);
            _command.ExecuteAction();

        }
    }
}
