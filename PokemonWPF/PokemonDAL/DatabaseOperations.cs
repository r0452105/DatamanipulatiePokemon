using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                    .Include("Types")
                    .Include("Types1")
                    .Include("Types.Pokedex")
                    .Include("Types.Pokedex1")
                    .OrderBy(x => x.Id);
                return query.ToList();
            }
        }
        public static List<Ability> AbilityList()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Ability
                    .OrderBy(x => x.Id);
                return query.ToList();
            }
        }
        public static int CurrentStatpools()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.StatPool;
                
                return query.ToList().Count();
            }
        }

        public static int RemovePokemonFromGroup(PokemonGroup toRemove)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.Entry(toRemove).State = EntityState.Deleted;

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }


        }

        public static int UpdatePokemon(Pokemon currentPokemon)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.Entry(currentPokemon).State = EntityState.Modified;

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        public static int ChangePosition(PokemonGroup currentPosition)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.Entry(currentPosition).State = EntityState.Modified;

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

        }
        public static int CurrentPokemons()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Pokemon;

                return query.ToList().Max(x => x.Id);
            }
        }

        public static int AddStatCollection(StatCollection newCollection)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.StatCollection.Add(newCollection);

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        public static int AddStatPool(StatPool newPool)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.StatPool.Add(newPool);

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        public static int AddPokemon(Pokemon newPokemon)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.Pokemon.Add(newPokemon);

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        public static int LearnNewMove(LearnedMoves newLearnedMove)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.LearnedMoves.Add(newLearnedMove);

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

        }
        public static int AddToGroup(PokemonGroup newGroup)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.PokemonGroup.Add(newGroup);

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

        }
        public static int CurrentPokemonGroups()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.PokemonGroup;
                return query.ToList().Count();
            }
        }
        public static Pokedex SelectPokemonFromPokedex(Pokedex pokedexpokemon)
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Pokedex
                            .Where(x => x.Id == pokedexpokemon.Id);

                return query.SingleOrDefault();
            }
        }

       
        public static int CurrentLearnedMoves()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.LearnedMoves;

                return query.ToList().Count();
            }
        }
        public static int CurrentStatCollections()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.StatCollection;

                return query.ToList().Count();
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

        public static List<Items> GetDistinctCategory()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Items
                            .OrderBy(x => x.Catagory);

                return query.ToList();
            }
        }

        public static List<PlayerInventory> SelectAllInventory(string category)
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {

                var iQuery = entities.Items
                    .Where(i => i.Catagory.ToString() == category)
                    .Select(i => i.Id).ToList();

                var query = entities.PlayerInventory
                    .Include("Items")
                    .Include("Trainer")
                    .Where(x => iQuery.Contains(x.ItemID.Value));
                return query.ToList();
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
                             .Include("Pokemon.Ability")
                            .Where(x => x.PlayerId == trainerID )
                            .OrderBy(x => x.Position);

                return query.ToList();

            }

        }

        public static PokemonGroup SelectPokemonFromParty(int trainerID, int position)
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.PokemonGroup
                            .Include("Pokemon")
                            .Include("Pokemon.Statpool")
                            .Include("Pokemon.Statpool.BaseStats")
                            .Include("Pokemon.Statpool.EVStats")
                            .Include("Pokemon.Statpool.IVStats")
                            .Where(x => x.PlayerId == trainerID && x.Position == position);
                            

                return query.SingleOrDefault();

            }

        }

        public static List<LearnedMoves> SelectMovesFromPokemon(Pokemon pokemon)
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.LearnedMoves
                    .Include("PokemonMoves")
                     .Include("PokemonMoves.Types")
                     .Where(x => x.PokemonId == pokemon.Id)
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
                            .Include("Pokedex.Types")
                            .Include("Pokedex.Types1")
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
