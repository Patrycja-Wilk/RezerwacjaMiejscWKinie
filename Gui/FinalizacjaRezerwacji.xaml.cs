using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Kino;

namespace Gui
{
    public partial class FinalizacjaRezerwacji : Page
    {
        private Klient klient;
        internal Sala Sala;
        public List<Button> wybraneMiejsca;

        private bool imieChanged = false;
        private bool nazwiskoChanged = false;
        private bool telefonChanged = false;
        private bool mailChanged = false;

        public int liczbaBiletowNormalnych = 0;
        public int liczbaBiletowUlgowych = 0;

        public FinalizacjaRezerwacji(int licznik, List<Button> wybraneMiejsca)
        {
            InitializeComponent();

            for (int i = 0; i <= licznik; i++)
            {
                LiczbaBiletowNormalnychComboBox.Items.Add(i);
                LiczbaBiletowUlgowychComboBox.Items.Add(i);
            }

            wybraneMiejsca = wybraneMiejsca.OrderBy(btn => Convert.ToInt32(btn.Content)).ToList();
            this.wybraneMiejsca = wybraneMiejsca;

            TxtBoxWybraneMiejsca.Text = InformacjeOMiejscach();
            ImieTextBox.TextChanged += TextBox_TextChanged;
            NazwiskoTextBox.TextChanged += TextBox_TextChanged;
            TelefonTextBox.TextChanged += TextBox_TextChanged;
            MailTextBox.TextChanged += TextBox_TextChanged;

            LiczbaBiletowNormalnychComboBox.SelectedIndex = wybraneMiejsca.Count;
            LiczbaBiletowUlgowychComboBox.SelectedIndex = 0;
            AktualizujCene();
        }

        public string InformacjeOMiejscach()
        {
            StringBuilder informacje = new StringBuilder();

            foreach (Button miejsce in wybraneMiejsca)
            {
                informacje.Append($"{miejsce.Content} ");
            }

            return informacje.ToString();
        }

        private void LiczbaBiletowNormalnychComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            liczbaBiletowNormalnych = LiczbaBiletowNormalnychComboBox.SelectedIndex;
            int dostepnaLiczbaMiejsc = wybraneMiejsca.Count;
            int liczbaBiletowUlgowych = dostepnaLiczbaMiejsc - liczbaBiletowNormalnych;

            LiczbaBiletowUlgowychComboBox.SelectedIndex = liczbaBiletowUlgowych;

            AktualizujCene();
        }

        private void LiczbaBiletowUlgowychComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            liczbaBiletowUlgowych = LiczbaBiletowUlgowychComboBox.SelectedIndex;
            int dostepnaLiczbaMiejsc = wybraneMiejsca.Count;
            int liczbaBiletowNormalnych = dostepnaLiczbaMiejsc - liczbaBiletowUlgowych;

            LiczbaBiletowNormalnychComboBox.SelectedIndex = liczbaBiletowNormalnych;

            AktualizujCene();
        }

        public void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            if (textBox == ImieTextBox)
            {
                imieChanged = true;
            }
            else if (textBox == NazwiskoTextBox)
            {
                nazwiskoChanged = true;
            }
            else if (textBox == TelefonTextBox)
            {
                telefonChanged = true;
            }
            else if (textBox == MailTextBox)
            {
                mailChanged = true;
            }

            AktualizujCene();
        }

        public decimal AktualizujCene()
        {
            int liczbaBiletow = liczbaBiletowNormalnych + liczbaBiletowUlgowych;
            decimal cena = (liczbaBiletowNormalnych * 20m) + (liczbaBiletowUlgowych * 16m);
            CenaTextBlock.Text = $"{cena} zł";
            return cena;
        }

        private void FinalizujRezerwacje_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz dokonać rezerwacji?", "Potwierdzenie rezerwacji", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (!imieChanged || !nazwiskoChanged || !telefonChanged || !mailChanged)
                {
                    MessageBox.Show("Proszę uzupełnić wszystkie dane klienta.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                string imie = ImieTextBox.Text;
                string nazwisko = NazwiskoTextBox.Text;
                string telefon = TelefonTextBox.Text;
                string mail = MailTextBox.Text;

                try
                {
                    klient = new Klient(imie, nazwisko, telefon, mail);

                    MessageBox.Show("Rezerwacja zakończona pomyślnie!\nDane klienta:\n" + klient.Imie + " " + klient.Nazwisko +
                                    "\nTelefon: " + klient.Telefon + "\nEmail: " + klient.Mail);

                    RezerwacjaNowa nowaRezerwacja = new RezerwacjaNowa(Sala, InformacjeOMiejscach(), AktualizujCene(), klient, false, liczbaBiletowNormalnych, liczbaBiletowUlgowych);

                    InformacjeORezerwacji informacjeORezerwacji = new InformacjeORezerwacji(nowaRezerwacja);
                    this.NavigationService.Navigate(informacjeORezerwacji);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
                Window.GetWindow(this).Close();
            }
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
