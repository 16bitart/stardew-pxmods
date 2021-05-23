using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StardewValley;
using StardewValley.TerrainFeatures;

namespace PxMod.Extensions
{
    public static class FarmExtensions
    {
        public static int CountReadyCrops(this Farm farm)
        {
            var pairs = farm.terrainFeatures.Pairs;
            var count = 0;

            foreach (var pair in pairs)
            {
                if (pair.Value is HoeDirt cropDirt)
                {

                    if (cropDirt.crop.fullyGrown)
                    {
                        count++;
                    }
                }
            }

            return count;

        }
    }
}
