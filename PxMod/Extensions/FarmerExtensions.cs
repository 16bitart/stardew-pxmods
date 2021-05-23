using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using StardewValley;

namespace PxMod.Extensions
{
    public static class FarmerExtensions
    {
        public static Vector2 GetPlayerTile(this Farmer player)
        {
            Vector2 vector2 = player?.Position ?? Vector2.Zero;
            return new Vector2((int)(vector2.X / 64.0), (int)(vector2.Y / 64.0));
        }
    }
}
