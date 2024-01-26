using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Kino;

namespace Gui
{
    public partial class RepertuarKina : Page
    {
        public RepertuarKina()
        {
            InitializeComponent();
        }

        private void Obrazek_Click(object sender, MouseButtonEventArgs e)
        {
            Image clickedImage = (Image)sender;

            List<MovieInfo> movies = new List<MovieInfo>
            {
                new MovieInfo
                {
                    Title = "Zootopia",
                    ImagePath = "/Images/s-l1200.jpg",
                    Description = "Zwierzogród to jedyne miasto zamieszkiwane wyłącznie przez zwierzęta. Tu możesz zostać kimkolwiek chcesz.\n" +
                    "Jednak ambitna Judy Hops, szybko przekonuje się, że jako pierwszy królik w policji, nie będzie miała łatwego życia.\n" +
                    "Aby udowodnić swoją wartość musi rozwiązać pewną kryminalną zagadkę. Jej partnerem w śledztwie zostaje gadatliwy i szczwany lis Nick Bajer.",
                    Director = " Rich Moore, Byron Howard",
                    Duration = "108 minut",
                    Genre = "komedia kryminalna, przygodowy"

                    
                },
                new MovieInfo
                {
                    Title = "Mulan",
                    ImagePath = "/Images/300px-Mulan.jpg",
                    Description="Mulan opowiada historię nieustraszonej młodej dziewczyny, która w męskim przebraniu wyrusza \n" +
                    "do walki w obronie swojego kraju. Będąc nieodrodną córką wielkiego wojownika, Hua Mulan jest szybka,\n" +
                    "nieustraszona i zdeterminowana. Kiedy cesarz nakazuje, aby jeden mężczyzna z każdej rodziny służył w jego armii, \n" +
                    "Mulan zajmuje miejsce swojego chorego ojca. Jako Hua Jun staje się jednym z największych chińskich wojowników.",
                    Director= "Tony Bancroft, Barry Cook",
                    Duration= "88 minut",
                    Genre = "historyczny, wojenny, komedia, familijny, musical"
                    
                },
                new MovieInfo
                {
                    Title = "Inside Out",
                    ImagePath = "/Images/inside-out.jpg",
                    Description ="Wkrocz do Centrum dowodzenia w głowie 11-letniej Riley i przekonaj się, że tam praca wre w najlepsze. \n" +
                    "W pocie czoła swoje zadania wykonuje pięć emocji pod dowództwem optymistycznej Radości, która zrobi wszystko, by Riley była szczęśliwa.\n" +
                    "Nie jest jednak łatwo zapanować nad emocjami, kiedy współpracownikami są Strach, Złość, Odraza i Smutek!",
                    Director = "Pete Docter",
                    Duration = "94 minuty",
                    Genre= "Animacja, Komedia"
                    
                },
                new MovieInfo
                {
                    Title = "Dumbo",
                    ImagePath = "/Images/91QZvpx-4xL._AC_UF894,1000_QL80_.jpg",
                    Description="Właściciel cyrku Max Medici zatrudnia weterana wojennego Holta Farriera i jego dzieci do opieki nad nowonarodzonym \n" +
                    "słonikiem z bardzo dużymi uszami. Gdy wyśmiewany przez wszystkich Dumbo okazuje się obdarzony umiejętnością latania, cyrk zdobywa widownię,\n" +
                    "sławę, pieniądze i – na swoje nieszczęście – zainteresowanie przedsiębiorcy V.A. Vandevere’a. Tak zaczyna się ta prosta i wzruszająca opowieść \n" +
                    "o inności, z której można uczynić zaletę, o sile rodzinnych więzów, przyjaźni i marzeń oraz o ponadczasowej walce dobra ze złem.",
                    Director="Tim Burton",
                    Duration="64 minuty",
                    Genre="Familijny, Fantasy"
                    
                }
            };

            SpecyfikacjaFilmu movieDetailsPage = new SpecyfikacjaFilmu(movies[MainStackPanel.Children.IndexOf(clickedImage)]);
            NavigationService.Navigate(movieDetailsPage);
        }

        private void Zamknij_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
