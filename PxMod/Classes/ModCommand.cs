using System;
using StardewModdingAPI;

namespace PxMod.Classes
{
    public class ModCommand : IModCommand
    {
        protected readonly SButton _keybind;
        protected readonly Action _execute;
        public string CommandTypeName { get; }

        public ModCommand(string commandName, Action command, SButton keybind)
        {
            CommandTypeName = commandName;
            _execute = command;
            _keybind = keybind;
        }
        public bool Evaluate(SButton buttonPressed)
        {
            if (buttonPressed == _keybind)
            {
                _execute?.Invoke();
                return true;
            }

            return false;
        }
    }
}