using System;
using System.Windows;

namespace PokemonModels
{
    public class PokemonSpriteById : PokemonSprite
    {

        public PokemonSpriteById(int id) : base()
        {
            int baseWidth = 56;

            int baseHeight = 52;
            int xPos = (baseWidth * id) % 896;
            int yPos = ((int)Math.Floor((baseWidth * id) / 896.0) * baseHeight * 2);
            target = new Int32Rect(xPos, yPos, target.Width, target.Height);
        }
    }
}
