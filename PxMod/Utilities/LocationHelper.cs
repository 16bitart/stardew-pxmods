using System.Collections.Generic;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Locations;

namespace PxMod.Utilities
{
    public class LocationHelper
    {
        public GameLocation Farm => Get("Farm");

        public IEnumerable<BuildableGameLocation> BuildableLocations()
        {
            foreach (var gameLocation in Locations())
            {
                if (gameLocation is BuildableGameLocation buildableGameLocation)
                {
                    yield return buildableGameLocation;
                }
            }
        }

        public IList<GameLocation> Locations()
        {
            return Context.IsWorldReady ? Game1.locations : null;
        }

        public GameLocation Get(string name)
        {
            return Context.IsWorldReady ? Game1.getLocationFromName(name) : null;
        }
    }
}