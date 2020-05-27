using PokemonDAL;
using PokemonModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace PokemonWPF
{
    /// <summary>
    /// Interaction logic for PokéBadgesWindow.xaml
    /// </summary>
    public partial class PokéBadgesWindow : Window
    {
        public Trainer trainerBadges;
        public PokéBadgesWindow()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Image[] images = { img0, img1, img2, img3, img4, img5, img6, img7 };
                //BitmapImage sprite1 = new BitmapImage(new Uri("Images/badgessprites.png", UriKind.Relative));
                //imgbadges.Source = sprite1;//  new CroppedBitmap(sprite1, badge1.target);
                BitmapImage sprite1 = new BitmapImage(new Uri("Images/badgessprites.png", UriKind.Relative));
                for (int i = 0; i <= 8; i++)
                {
                    int count = i;
                    int x = i * 68; int y = 0;
                    int w = 64; int h = 72;
                    if (i == 7) { x = x - 2; }
                    Badge1 bg1 = new Badge1(x, y, w, h);
                    images[i].Source = new CroppedBitmap(sprite1, bg1.target);
                }
            }
            catch { }
        }

    }

    public class Badge1 : BadgeSprite
    {
        public Badge1(int x, int y, int width, int height) //: base()
        {
            target = new Int32Rect(x, y, width, height);
        }

    }
}
