using System;
using PxMod.Extensions;
using PxMod.Modules;
using PxMod.Utilities;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace PxMod
{
    public class Initialize : Mod
    {
        private IModHelper _entryHelper;

        private LocationHelper _locationHelper;
        private SprinklerEverywhere _sprinklerMod;
        private InstantGrow _instantGrow;
        private StardewLogger _stardewLogger;
        private NumPadCommands _commands;

        public override void Entry(IModHelper helper)
        {
            _entryHelper = helper;
            _locationHelper = new LocationHelper();
            _stardewLogger = new StardewLogger(Log);
            _instantGrow = new InstantGrow(_stardewLogger);
            _sprinklerMod = new SprinklerEverywhere(_stardewLogger);

            CreateCommands();

            helper.Events.GameLoop.DayStarted += (o, e) =>
            {
                if (Context.IsWorldReady)
                {
                    var farm = Game1.getFarm();
                    _instantGrow.LastDayGrowCheck(Game1.dayOfMonth, farm);
                }

            };
        }

        private void CreateMenuItems()
        {
        }

        private void CreateCommands()
        {
            _commands = new NumPadCommands(_entryHelper, _stardewLogger);

            _commands.CreateCommandBinding("PlayerTileLocation", SButton.NumPad9, () =>
            {
                if (HasAuthority())
                {
                    var playerTile = Game1.player.GetPlayerTile();
                    var msg = $"Player Location: {playerTile.X}, {playerTile.Y}";
                    Log(msg);
                }
            });

            _commands.CreateCommandBinding("SprinklerEverywhere", SButton.OemCloseBrackets, () =>
             {
                 if (HasAuthority()) _sprinklerMod.Toggle();
             });

            _commands.CreateCommandBinding("InstantGrow", SButton.OemOpenBrackets, () =>
            {
                if (HasAuthority()) _instantGrow.Execute(Game1.getFarm());
            });
        }

        public bool HasAuthority()
        {
            if (Context.IsWorldReady)
            {
                if (Game1.IsMultiplayer)
                {
                    return Game1.player.IsMainPlayer;
                }
                return true;
            }
            return false;
        }

        public void Log(string message, LogLevel logLevel = LogLevel.Info)
        {
            Monitor.Log(message, logLevel);
        }
    }
}
