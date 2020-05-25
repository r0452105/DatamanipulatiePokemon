using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDAL
{
   public partial class Pokemon : IDataErrorInfo
    {
        public int currentHp = 0;

        public string Error => throw new NotImplementedException();

        
        public string ReturnHP()
        {
         
        currentHp = StatPool.CurrentHealth(this);

            return currentHp + "\t/ " + StatPool.CurrentHealth(this);

        }

        public string this[string columnName]
        {
            get
            {
                if (columnName=="PokemonID" && PokedexID < 1)
                {
                    return "pokedexid mag niet onder 0 liggen";
                }
                if (columnName=="CurrentXP" && PokemonExp < 0)
                {
                    return "xp moet een positieve waarde zijn";
                }
                if (columnName=="PokemonLevel" && PokemonLevel > 100 && PokemonLevel < 0)
                {
                    return "Level moet tussen 0 en 100 liggen";
                }
                return "";
            }

        }

        
    }
}
