using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDAL
{
   public partial class Pokemon
    {
        public int currentHp = 0;

        public string ReturnHP()
        {
         
        currentHp = StatPool.CurrentHealth(this);

            return currentHp + "\t/ " + StatPool.CurrentHealth(this);

        }
    }
}
