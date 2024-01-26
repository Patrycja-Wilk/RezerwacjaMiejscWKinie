using Kino;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace Gui
{
    public partial class InformacjeORezerwacji : Page
    {
        public InformacjeORezerwacji(RezerwacjaNowa rezerwacja)
        {
            InitializeComponent();
            string gifPath = "Images/HNWT6DgoBc14riaEeLCzGYopkqYBKxpGKqfNWfgr368M9WNvwCmz6pCNJBicw2DEv2YZDok3rZmom6Q9HZUAcqPCX2FEXqNsb85KMxpv67SxvvGS85BfSR6P2FP.gif";

            Uri gifUri = new Uri(gifPath, UriKind.RelativeOrAbsolute);
            ImageBehavior.SetAnimatedSource(GifImage, new BitmapImage(gifUri));

            int liczbaBiletowNormalnych = rezerwacja.LiczbaBiletowNormalnych;
            int liczbaBiletowUlgowych = rezerwacja.LiczbaBiletowUlgowych;
            string informacje = $"Dane klienta:\n{rezerwacja.Klient.Imie} {rezerwacja.Klient.Nazwisko}\n" +
                            $"Telefon: {rezerwacja.Klient.Telefon}\nEmail: {rezerwacja.Klient.Mail}\n" +
                            $"Numer rezerwacji: {rezerwacja.NumerRezerwacji}\n" +
                            $"Liczba biletów normalnych: {liczbaBiletowNormalnych}\n" +
                            $"Liczba biletów ulgowych: {liczbaBiletowUlgowych}\n" +
                            $"Cena: {rezerwacja.Cena} zl\n" +
                            $"Numery miejsc: {rezerwacja.ZarezerwowaneMiejsca}";

            InformacjeTextBlock.Text = informacje;
        }

        private void KoniecBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
            Window.GetWindow(this).Close();
        }
    }
}
