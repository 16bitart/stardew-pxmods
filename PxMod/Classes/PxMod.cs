using StardewModdingAPI;
using StardewValley;

namespace PxMod.Classes
{
    public abstract class PxMod
    {
        public bool WorldReady => Context.IsWorldReady;
        public abstract void Entry(IModHelper helper);

    }
}
