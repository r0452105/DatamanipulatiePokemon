namespace PokemonDAL
{
    public partial class PokemonGroup
    {

        public override string ToString()
        {
            return Pokemon.Nickname + "\tLvl " + Pokemon.PokemonLevel;
        }
    }
}
