using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PokemonDAL;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokemonPartyCRUD.xaml
    /// </summary>
    public partial class PokemonPartyCRUD : Window
    {
       public Trainer currentTrainer;
       public Pokemon CurrentPkm;
       public List<Pokedex> pokedexList ;

        public LearnedMoves DefaultMoves1 = new LearnedMoves();
        public LearnedMoves DefaultMoves2 = new LearnedMoves();

        public int baseHP;
            public int baseAtt;
            public int baseDef;
            public int baseSpAtt;
            public int baseSpDef;
            public int baseSpeed;

        public int EVHP;
        public int EVAtt;
        public int EVDef;
        public int EVSpAtt;
        public int EVSpDef;
        public int EVSpeed;

        public PokemonPartyCRUD()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string error = Validate();
            if (! string.IsNullOrWhiteSpace(error))
            {
                MessageBox.Show(error);
            }
            else
            {
                PokemonStats statWindow = new PokemonStats();
                statWindow.StatPass = this;
                statWindow.ShowDialog();

                //Initialize statPool
                StatPool statPool = new StatPool();
                statPool.Id = DatabaseOperations.CurrentStatpools() + 1;


                //Initialize stat collections
                StatCollection BaseStats = new StatCollection();
                StatCollection EVStats = new StatCollection();
                StatCollection IVStats = new StatCollection();
                StatCollection EVRewardStats = new StatCollection();

                //Assign Values
                BaseStats.Id = DatabaseOperations.CurrentStatCollections() + 1; 
                BaseStats.HP = baseHP;
                BaseStats.Attack = baseAtt;
                BaseStats.Defense = baseDef;
                BaseStats.SpecialAttack = baseSpAtt;
                BaseStats.SpecialDefence = baseSpDef;
                BaseStats.Speed = baseSpeed;

                EVStats.Id = DatabaseOperations.CurrentStatCollections() + 2;
                EVStats.HP = 0;
                EVStats.Attack = 0;
                EVStats.Defense = 0;
                EVStats.SpecialAttack = 0;
                EVStats.SpecialDefence = 0;
                EVStats.Speed = 0;

                Random rnd = new Random();
                IVStats.Id = DatabaseOperations.CurrentStatCollections() + 3;
                IVStats.HP = rnd.Next(1, 32);
                IVStats.Attack = rnd.Next(1, 32);
                IVStats.Defense = rnd.Next(1, 32);
                IVStats.SpecialAttack = rnd.Next(1, 32);
                IVStats.SpecialDefence = rnd.Next(1, 32);
                IVStats.Speed = rnd.Next(1, 32);              
               
                EVRewardStats.Id = DatabaseOperations.CurrentStatCollections() + 4;
                EVRewardStats.HP = EVHP;
                EVRewardStats.Attack = EVAtt;
                EVRewardStats.Defense = EVDef;
                EVRewardStats.SpecialAttack = EVSpAtt;
                EVRewardStats.SpecialDefence = EVSpDef;
                EVRewardStats.Speed = EVSpeed;


                //Bind with statpool
                statPool.BaseStatId = BaseStats.Id;
                statPool.EVStatId= EVStats.Id;
                statPool.IVStatId = IVStats.Id;
                statPool.EffortValueYield = EVRewardStats.Id;

                statPool.Nature = "Timid";

                

               


            }
           
        }

        private string Validate()
        {
            string errormsg = "";
            if (! int.TryParse(txtLvl.Text, out int fieldvalue))
            {
                errormsg += "Level moet numeriek zijn";
                if (fieldvalue < 1 || fieldvalue > 100)
                {
                    errormsg += "Level moet tussen 1 en 100 liggen";
                }
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errormsg += "Nickname mag niet leeg zijn";
            }
          

            return errormsg;

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pokedexList = DatabaseOperations.PokedexEntry();
            cmbPokemon.ItemsSource = pokedexList;
            cmbPokemon.SelectionChanged += new SelectionChangedEventHandler(cmbPokemon_SelectionChanged);

          

        }
        
        private void LoadDefaultMoves(int pokemonID)
        {
            DefaultMoves1.Id = DatabaseOperations.CurrentLearnedMoves() + 1;
            DefaultMoves2.Id = DatabaseOperations.CurrentLearnedMoves() + 2;
            DefaultMoves1.CurrentPP = 30;
            DefaultMoves1.MoveId = 42;
            DefaultMoves1.Position = 1;
            DefaultMoves2.CurrentPP = 30;
            DefaultMoves2.MoveId = 10;
            DefaultMoves2.Position = 2;
            DefaultMoves1.PokemonId = pokemonID;
            DefaultMoves2.PokemonId = pokemonID;

        }
        private void cmbPokemon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            
                txtName.Text = pokedexList[cmbPokemon.SelectedIndex].PokemonName;
            
        
        }
    }
}
