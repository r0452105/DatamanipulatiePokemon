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

        public static List <Pokedex> PokedexEntry()
        {
            using(DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Pokedex
                    .OrderBy(x => x.Id);
                return query.ToList();
            }
        }

        public static List<Pokedex> PokedexEntryAZ()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Pokedex
                    .OrderBy(x => x.PokemonName);
                return query.ToList();
            }
        }

        public static List<Types> Typinglist()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Types
                    .OrderBy(x => x.Id);
                return query.ToList();
            }
        }

    }
}
