using StardewModdingAPI;

namespace PxMod.Classes
{
    public interface IModCommand
    {
        string CommandTypeName { get; }
        bool Evaluate(SButton buttonPressed);
    }
}