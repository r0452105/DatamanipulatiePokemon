using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonDAL
{
    public static class DatabaseOperations
    {

        public static Trainer SelectTrainer(int trainerId)
        {

            using (DB_r0739290Entities entities = new DB_r0739290Entities()) 
            {
                var query = entities.Trainer
                            .Include("PlayerInventory")
                            .Include("Pokemon")
                            .Include("PokemonGroup")
                            .Where(x => x.Id == trainerId);
                return query.SingleOrDefault();

            }

                
        }

        public static List<PokemonGroup> SelectParty(int trainerID)
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.PokemonGroup
                            .Include("Pokemon")
                            .Include("Pokemon.Statpool")
                            .Include("Pokemon.Statpool.BaseStats")
                            .Include("Pokemon.Statpool.EVStats")
                            .Include("Pokemon.Statpool.IVStats")
                            .Where(x => x.PlayerId == trainerID )
                            .OrderBy(x => x.Position);

                return query.ToList();

            }

        }

        public static Pokemon SelectPokemonFromParty(PokemonGroup partyPokemon)
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Pokemon
                            
                            .Include("Statpool")
                            .Include("Statpool.BaseStats")
                            .Include("Statpool.EVStats")
                            .Include("Statpool.IVStats")
                            .Include("LearnedMoves")
                            .Include("Pokedex")
                            .Include("Trainer")
                            .Include("LearnedMoves.PokemonMoves")
                            .Include("StatusEffects")
                            .Include("Items")
                            .Include("Ability")
                            .Where(x => x.Id == partyPokemon.PokemonId);
                       

                return query.SingleOrDefault();

            }

        }
    }
}
