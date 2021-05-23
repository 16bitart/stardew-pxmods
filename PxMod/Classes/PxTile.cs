using System;
using PxMod.Constants;
using xTile.ObjectModel;
using xTile.Tiles;

namespace PxMod.Classes
{
    public class PxTile
    {
        private Tile _tile;
        public IPropertyCollection Properties => _tile.Properties;
        public IPropertyCollection TileIndexProperties => _tile.TileIndexProperties;

        public PxTile(Tile tile)
        {
            _tile = tile;
        }

        public void ChangeProperty(TileProperty property, bool value) 
        {
            switch (property)
            {
                case TileProperty.NoSprinklers:
                    _tile.TileIndexProperties[TileProperties.NoSprinklers] = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(property), property, null);
            }
        }
    }
}
