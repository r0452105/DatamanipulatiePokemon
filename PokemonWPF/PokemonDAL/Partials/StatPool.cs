using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDAL
{
   public partial class StatPool
    {

        public int CurrentHealth(Pokemon currentPokemon)
        {
            return Convert.ToInt32((((IvStats.HP + 2 * BaseStats.HP + (Math.Abs(Math.Sqrt(Convert.ToDouble(EvStats.HP))) / 4) + 100)) * (int)currentPokemon.PokemonLevel / 100) + (int)currentPokemon.PokemonLevel + 10);

        }

        public int TotalAttack(Pokemon currentPokemon)
        {
            return Convert.ToInt32((((IvStats.Attack + 2 * BaseStats.Attack + (Math.Abs(Math.Sqrt(Convert.ToDouble(EvStats.Attack))) / 4) + 100)) * (int)currentPokemon.PokemonLevel / 100) + 10);

        }
        public int TotalDefense(Pokemon currentPokemon)
        {
            return Convert.ToInt32((((IvStats.Defense + 2 * BaseStats.Defense + (Math.Abs(Math.Sqrt(Convert.ToDouble(EvStats.Defense))) / 4) + 100)) * (int)currentPokemon.PokemonLevel / 100) + 10);
        }
        public int TotalSpAttack(Pokemon currentPokemon)
        {
            return Convert.ToInt32((((IvStats.SpecialAttack + 2 * BaseStats.SpecialAttack + (Math.Abs(Math.Sqrt(Convert.ToDouble(EvStats.SpecialAttack))) / 4) + 100)) * (int)currentPokemon.PokemonLevel / 100) + 10);

        }
        public int TotalSpDefense(Pokemon currentPokemon)
        {
            return Convert.ToInt32((((IvStats.SpecialDefence + 2 * BaseStats.SpecialDefence + (Math.Abs(Math.Sqrt(Convert.ToDouble(EvStats.SpecialDefence))) / 4) + 100)) * (int)currentPokemon.PokemonLevel / 100) + 10);
        }
        public int TotalSpeed(Pokemon currentPokemon)
        {
            return Convert.ToInt32((((IvStats.Speed + 2 * BaseStats.Speed + (Math.Abs(Math.Sqrt(Convert.ToDouble(EvStats.Speed))) / 4) + 100)) * (int)currentPokemon.PokemonLevel / 100) + 10);
        }
    }
}
