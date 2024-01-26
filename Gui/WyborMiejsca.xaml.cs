using Kino;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Gui
{
    public partial class WyborMiejsca : Page
    {
        private Sala sala;
        public static int Licznik = 0;

        public List<Button> WybraneMiejsca { get; private set; }
        public Sala Sala { get => sala; set => sala = value; } 

        public WyborMiejsca(Sala sala)
        {
            InitializeComponent();
            Licznik = 0;
            WybraneMiejsca = new List<Button>();
          
            Zliczanie.Text = Licznik.ToString();
            PrzygotujPrzyciski();
            this.Sala = sala;
        }

        private void PrzygotujPrzyciski()
        {
            for (int i = 1; i <= 50; i++)
            {
                Button przycisk = FindName($"Przycisk{i}") as Button;

                if (przycisk != null)
                {
                    przycisk.Click += WyborMiejsca_Przyciski;
                }
            }
        }

        public void WyborMiejsca_Przyciski(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == null) return;

            SolidColorBrush buttonBackground = clickedButton.Background as SolidColorBrush;

            if (buttonBackground == null) return;

            if (buttonBackground.Color == Colors.DarkGray)
            {
                clickedButton.Background = new SolidColorBrush(Colors.Green);
                Licznik++;
                Zliczanie.Text = Licznik.ToString();
                WybraneMiejsca.Add(clickedButton);
                Sala?.ListaPrzyciskow.Add(clickedButton.Name);
            }
            else if (buttonBackground.Color == Colors.Green)
            {
                clickedButton.Background = new SolidColorBrush(Colors.DarkGray);
                Licznik--;
                Zliczanie.Text = Licznik.ToString();
                WybraneMiejsca.Remove(clickedButton);
                Sala?.ListaPrzyciskow.Remove(clickedButton.Name);
            }
        }

        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            if (Licznik == 0)
            {
                MessageBox.Show("Musisz wybrać przynajmniej jedno miejsce", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            FinalizacjaRezerwacji danekupujacego = new FinalizacjaRezerwacji(Licznik, WybraneMiejsca);
            danekupujacego.Sala = Sala;
            this.NavigationService.Navigate(danekupujacego);
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

