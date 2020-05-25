using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PokemonDAL
{
    public static class DatabaseOperations
    {


        public static void ErrorLogging(Exception ex)
        {
            string strPath = @"Log.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Error: " + ex.GetType().Name);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }

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
        public static List<PokemonMoves> AllMoves()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.PokemonMoves
                    .OrderBy(x => x.Id);
                return query.ToList();
            }
        }

        public static List<PokemonMoves> AllMovesExceptCurrent(Pokemon pokemon)
        {
           
            
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var iQuery = entities.LearnedMoves
                    .Where(x => x.PokemonId == pokemon.Id)
                    .Select(i => i.MoveId).ToList(); ;
                  
                var query = entities.PokemonMoves
                    .Where(x => ! iQuery.Contains(x.Id ))
                    .OrderBy(x => x.Id);
                return query.ToList();
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

        public static int AddPokedexEntry(Pokedex newPokedex)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.Pokedex.Add(newPokedex);

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
                return 0;
            }

        }

        public static int DeletePokedexEntry(Pokedex oldPokedex)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.Entry(oldPokedex).State=EntityState.Deleted;
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
                return 0;
            }

        }

        public static int UpdatePokedexEntry(Pokedex oldPokedex)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.Entry(oldPokedex).State = EntityState.Modified;

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
                return 0;
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

      
        public static int RemoveItemFromList(List<PlayerInventory> lstInventory)
        {
            throw new NotImplementedException();
        }

        public static List<Trainer> TrainerList()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Trainer
                    .Include("PokemonGroup")
                    .OrderBy(x => x.Id);
                return query.ToList();
            }
        }
        public static int CurrentStatpools()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.StatPool;
                
                return query.ToList().Max(x => x.Id); ;
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
                ErrorLogging(ex);
                return 0;
            }


        }

        public static int RemoveItemFromList(PlayerInventory toRemove)
        {
            try
            {
                using(DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.Entry(toRemove).State = EntityState.Deleted;
                    
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
                return 0;
            }

            
        }
        public static int RemoveMove(LearnedMoves toRemove)
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
                ErrorLogging(ex);
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
                ErrorLogging(ex);
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
                ErrorLogging(ex);
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
                ErrorLogging(ex);
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
                ErrorLogging(ex);
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
                ErrorLogging(ex);
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
                ErrorLogging(ex);
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
                ErrorLogging(ex);
                return 0;
            }

        }

        public static int AddToLearnedMoves(LearnedMoves newMove)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.LearnedMoves.Add(newMove);

                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
                return 0;
            }

        }
        public static int CurrentPokemonGroups()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.PokemonGroup;
                return query.ToList().Max(x => x.Id);
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

                return query.ToList().Max(x => x.Id); 
            }
        }
        public static int CurrentStatCollections()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.StatCollection;

                return query.ToList().Max(x => x.Id); ;
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

        


        public static List<PlayerInventory> GetItems(int trainerId)
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Items
                    .Select(i => i.Id).ToList();
                var iquery = entities.PlayerInventory
                    .Include("Items")
                    .Include("Trainer")
                    .Where(x => query.Contains(x.ItemID.Value));
                return iquery.ToList();
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

        public static List<Pokemon> PokemonList()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.Pokemon;

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

        public static int AddItem(PlayerInventory item)
        {
            try
            {
                using (DB_r0739290Entities entities = new DB_r0739290Entities())
                {
                    entities.PlayerInventory.Add(item);
                    return entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                ErrorLogging(ex);
                return 0;
             
            }
        }

        public static int CurrentPlayerItems()
        {
            using (DB_r0739290Entities entities = new DB_r0739290Entities())
            {
                var query = entities.PlayerInventory;

                return query.ToList().Max(x => x.id);
            }
        }



    }
}
