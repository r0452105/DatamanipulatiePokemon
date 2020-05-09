using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace PokemonModels
{
    public abstract class BadgeSprite : SpriteCoordinates
    {
        public BadgeSprite()
        {

            /*Initializatie instructies
        BitmapImage sprite =  new BitmapImage(new Uri("Images/badgesSprites.png", UriKind.Relative));
           imgPokebal.Source = new CroppedBitmap(sprite, badgeclass.target);

   */
            target = new Int32Rect(0, 0, 64, 64);

        }
    }
}
