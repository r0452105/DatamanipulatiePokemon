using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using PokemonModels;

namespace PokemonModels
{
   public class Badge1 : BadgeSprite
   {
        public Badge1() : base() {
            target = new Int32Rect(73, 0, target.Width, target.Height);
        }

   }
}
