using System;
using System.Collections.Generic;
using PxMod.Classes;
using StardewModdingAPI;

namespace PxMod.Utilities
{
    public class NumPadCommands 
    {
        private IModHelper _helper;
        private StardewLogger _logger;
        private List<IModCommand> _commands;

        public NumPadCommands(IModHelper helper, StardewLogger logger)
        {
            _helper = helper;
            _logger = logger;
            _commands = new List<IModCommand>();
        }

        public void CreateCommandBinding(string name, SButton keybind, Action action)
        {
            var command = new ModCommand(name, action, keybind);
            _commands.Add(command);
            _helper.Events.Input.ButtonPressed += (o, e) => { command.Evaluate(e.Button); };
            _logger.Log($"{keybind} was bound to {command.CommandTypeName}");
        }
    }
}
