using System.Windows;

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
            target = new Int32Rect(0, 0, 56, 56);
        }
    }
}
