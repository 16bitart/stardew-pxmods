using System.Linq;
using System.Threading;
using Microsoft.Build.Utilities;
using PxMod.Constants;
using PxMod.Utilities;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using xTile.Tiles;

namespace PxMod.Modules
{
    public class SprinklerEverywhere
    {
        public bool IsEnabled { get; private set; }
        private StardewLogger _logger;

        public SprinklerEverywhere(StardewLogger logger)
        {
            _logger = logger;
            IsEnabled = false;
        }

        public void Toggle()
        {
            Toggle(!IsEnabled);
        }

        private void Toggle(bool targetState)
        {
            var backLayerMap = Game1.getFarm().Map.GetLayer("Back");
            var backLayerMapTilesList = backLayerMap.Tiles.Array.Cast<Tile>().ToList();
            var noSprinklerTiles = backLayerMapTilesList.Where(tile =>
                tile?.TileIndexProperties != null && tile.TileIndexProperties.ContainsKey(TileProperties.NoSprinklers));

            var count = 0;
            foreach (var tile in noSprinklerTiles)
            {
                count++;
                tile.TileIndexProperties[TileProperties.NoSprinklers] = targetState;
            }

            IsEnabled = targetState;
            var state = IsEnabled ? "Activated" : "Deactivated";
            var message = $"{state} the SprinklerEverywhere command.";
            _logger.Log($"{message} Changed {count} tiles");

        }
    }
}
