using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Utilities;
using PxMod.Extensions;
using PxMod.Utilities;
using StardewValley;
using StardewValley.TerrainFeatures;

namespace PxMod.Modules
{
    public class InstantGrow
    {
        private readonly StardewLogger _stardewLogger;

        public InstantGrow(StardewLogger stardewLogger)
        {
            _stardewLogger = stardewLogger;
        }
        public void LastDayGrowCheck(int day, Farm farm)
        {
            if (day == 28)
            {
                    Execute(farm);
                    _stardewLogger.Log("It's the last day of the season, so I grew all your crops for you!");
            }
        }

        public void Execute(Farm farm)
        {
            var pairs = farm.terrainFeatures.Pairs;
            var count = 0;

            foreach (var pair in pairs)
            {
                if (pair.Value is HoeDirt cropDirt)
                {
                    if (cropDirt.crop != null)
                    {
                        var crop = cropDirt.crop;
                        crop.growCompletely();
                        count++;

                    }
                    cropDirt.crop?.growCompletely();
                }
            }
            _stardewLogger.Log($"InstantGrow activated. Found {count} crops! Grew them to the max!");
        }
    }
}
