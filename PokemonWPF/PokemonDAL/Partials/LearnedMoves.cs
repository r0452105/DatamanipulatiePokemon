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
