using System.Windows;

namespace PokemonModels
{
    public class Badge1 : BadgeSprite
    {
        public Badge1() : base()
        {
            target = new Int32Rect(73, 0, target.Width, target.Height);
        }

    }
}
