using System.Windows;
using System.Windows.Controls;
using Kino;

namespace Gui
{
    public partial class SpecyfikacjaFilmu : Page
    {
        private MovieInfo movieInfo;

        public SpecyfikacjaFilmu (MovieInfo movieInfo)
        {
            InitializeComponent();
            this.movieInfo = movieInfo;
            DataContext = this.movieInfo;
        }

        private void KupBilet_Click(object sender, RoutedEventArgs e)
        {
            Wybor wybor = new Wybor();
            this.NavigationService.Navigate(wybor);
        }

        private void Powrot_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        private void Zamknij_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
