using PokemonDAL;
using System.Linq;
using System.Windows;
namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokemonMoveAdd.xaml
    /// </summary>
    public partial class PokemonMoveAdd : Window
    {

        public Pokemon currentPokemon = new Pokemon();
        public PokemonMoveAdd()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            LearnedMoves moveToAdd = new LearnedMoves();
            PokemonMoves selectedMove = (PokemonMoves)cmbMoveList.SelectedItem;

            moveToAdd.Id = DatabaseOperations.CurrentLearnedMoves() + 1;

            moveToAdd.PokemonId = currentPokemon.Id;
            moveToAdd.MoveId = selectedMove.Id;
            moveToAdd.Position = currentPokemon.LearnedMoves.Count() + 1;
            moveToAdd.CurrentPP = selectedMove.PP;

            if (DatabaseOperations.AddToLearnedMoves(moveToAdd) != 0)
            {
                MessageBox.Show("Move succesfully added");
                Close();
            }
            else
            {
                MessageBox.Show("Move failed to add");
            }

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbMoveList.ItemsSource = DatabaseOperations.AllMovesExceptCurrent(currentPokemon);
            cmbMoveList.SelectedIndex = 0;
            Topmost = true;
        }
    }
}
