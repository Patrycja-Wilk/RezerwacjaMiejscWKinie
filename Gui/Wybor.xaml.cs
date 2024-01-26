using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Kino;

namespace Gui
{
    public partial class Wybor : Page
    {

        public Wybor()
        {
            InitializeComponent();

            BtnDalej.Visibility = Visibility.Collapsed;

            FilmListBox.SelectionMode = SelectionMode.Single;

            FilmListBox.SelectionChanged += FilmListBox_SelectionChanged;
            DzienTygodniaComboBox.SelectionChanged += DzienTygodniaComboBox_SelectionChanged;

            GodzinaComboBox.SelectionChanged += GodzinaComboBox_SelectionChanged;
        }

        private void FilmListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DzienTygodniaLabel.Visibility = Visibility.Visible;
            DzienTygodniaComboBox.Visibility = Visibility.Visible;

            DzienTygodniaComboBox.SelectedIndex = -1;

            GodzinaLabel.Visibility = Visibility.Collapsed;
            GodzinaComboBox.Visibility = Visibility.Collapsed;

            BtnDalej.Visibility = Visibility.Collapsed;

        }

        private void DzienTygodniaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GodzinaLabel.Visibility = Visibility.Visible;
            GodzinaComboBox.Visibility = Visibility.Visible;

            string wybranyDzien = ((ComboBoxItem)DzienTygodniaComboBox.SelectedItem).Content.ToString();

            UstawGodzinyDlaDniaTygodnia(wybranyDzien);
        }

        private void GodzinaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GodzinaComboBox.SelectedIndex != -1)
            {
                BtnDalej.Visibility = Visibility.Visible;
            }
            else
            {
                BtnDalej.Visibility = Visibility.Collapsed;
            }
        }

        private void UstawGodzinyDlaDniaTygodnia(string dzienTygodnia)
        {
            switch (dzienTygodnia)
            {
                case "Poniedziałek":
                    UstawGodzinyComboBox("10:00", "15:00", "20:00");
                    break;

                case "Wtorek":
                    UstawGodzinyComboBox("09:00", "16:00", "21:00");
                    break;

                case "Środa":
                    UstawGodzinyComboBox("15:00", "18:00", "22:00");
                    break;

                case "Czwartek":
                    UstawGodzinyComboBox("13:00", "17:00", "21:00");
                    break;

                case "Piątek":
                    UstawGodzinyComboBox("10:00", "14:00", "18:00");
                    break;

                default:
                    break;
            }

            BtnDalej.Visibility = Visibility.Collapsed;
        }

        private void UstawGodzinyComboBox(params string[] godziny)
        {
            GodzinaComboBox.Items.Clear();
            foreach (var godzina in godziny)
            {
                GodzinaComboBox.Items.Add(godzina);
            }
        }

        private void Dalej_Click(object sender, RoutedEventArgs e)
        {
            Sala sala = new Sala();
            WyborMiejsca wybor = new WyborMiejsca(sala);
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

