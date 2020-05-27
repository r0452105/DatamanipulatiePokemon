using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDAL
{
   public partial class LearnedMoves
    {
        public string ReturnPP()
        {
            return $"{CurrentPP}\t/{PokemonMoves.PP}";
        }
    }
}
