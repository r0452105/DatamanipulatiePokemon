using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace PokemonModels
{
   public class PokemonSpriteById : PokemonSprite
    {

        public PokemonSpriteById(int id) : base()
        {
            int baseWidth = 56;
            int xPos = (baseWidth * id) % 896;
            int yPos = ((int)Math.Floor((baseWidth * id) / 896.0 ) * baseWidth * 2);
            target = new Int32Rect(xPos, yPos, target.Width, target.Height);
        }
    }
}
