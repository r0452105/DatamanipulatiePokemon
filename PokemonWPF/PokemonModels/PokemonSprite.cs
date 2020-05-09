using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;

namespace PokemonModels
{
   public abstract class PokemonSprite : SpriteCoordinates
    {
        public PokemonSprite()
        {

            /*Initializatie instructies
        BitmapImage sprite =  new BitmapImage(new Uri("Images/PokemonSprites.png", UriKind.Relative));
           ImageElement.Source = new CroppedBitmap(sprite, Pokemonname.target);

   */
            target = new Int32Rect(0, 0, 59, 59);
        }
    }
}
