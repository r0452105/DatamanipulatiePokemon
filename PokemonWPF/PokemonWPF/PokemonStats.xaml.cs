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

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokemonStats.xaml
    /// </summary>
    public partial class PokemonStats : Window
    {

        public PokemonPartyCRUD StatPass;
        public PokemonStats()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void btnSetStats_Click(object sender, RoutedEventArgs e)
        {
            string errorMsg = "";
            if (!int.TryParse(txtBaseHealth.Text, out int BaseHealth))
            {
                errorMsg += "Base health missing\n";
            }
            if (!int.TryParse(txtBaseAttack.Text, out int BaseAttack))
            {
                errorMsg += "Base attack missing\n";
            }
            if (!int.TryParse(txtBaseDefense.Text, out int BaseDefence))
            {
                errorMsg += "Base defence missing\n";
            }
            if (!int.TryParse(txtBaseSpAtt.Text, out int BaseSpAttack))
            {
                errorMsg += "Base special attack missing\n";
            }
            if (!int.TryParse(txtBaseSpDef.Text, out int BaseSpDefence))
            {
                errorMsg += "Base special defence missing\n";
            }
            if (!int.TryParse(txtBaseSpeed.Text, out int BaseSpeed))
            {
                errorMsg += "Base speed missing\n";
            }

            if (!int.TryParse(txtEVHealth.Text, out int EVHealth))
            {
                errorMsg += "Base health missing\n";
            }
            if (!int.TryParse(txtEVAttack.Text, out int EVAttack))
            {
                errorMsg += "Base attack missing\n";
            }
            if (!int.TryParse(txtEVDefense.Text, out int EVDefence))
            {
                errorMsg += "Base defence missing\n";
            }
            if (!int.TryParse(txtEVSpAtt.Text, out int EVSpAttack))
            {
                errorMsg += "Base special attack missing\n";
            }
            if (!int.TryParse(txtEVSpDef.Text, out int EVSpDefence))
            {
                errorMsg += "Base special defence missing\n";
            }
            if (!int.TryParse(txtEVSpeed.Text, out int EVSpeed))
            {
                errorMsg += "Base speed missing\n";
            }
            if (string.IsNullOrWhiteSpace(errorMsg))
            {
                StatPass.baseHP = BaseHealth;
                StatPass.baseAtt = BaseAttack;
                StatPass.baseDef = BaseDefence;
                StatPass.baseSpAtt = BaseSpAttack;
                StatPass.baseSpDef = BaseSpDefence;
                StatPass.baseSpeed = BaseSpeed;

                StatPass.EVHP = EVHealth;
                StatPass.EVAtt = EVAttack;
                StatPass.EVDef = EVDefence;
                StatPass.EVSpAtt = EVSpAttack;
                StatPass.EVSpDef = EVSpDefence;
                StatPass.EVSpeed = EVSpeed;

                Close();
            }
            else
            {
                MessageBox.Show(errorMsg);
            }
               
        }
    }
}
