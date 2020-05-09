using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace PokemonModels
{
    public class Bulbasaur : PokemonSprite
    {
        public Bulbasaur() : base(){
            target = new Int32Rect(60, 0, target.Width, target.Height);
        }
    }
}
