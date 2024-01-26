using System;
using System.Windows;

namespace Gui
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Repertuar_Click(object sender, RoutedEventArgs e)
        {
           RepertuarKina repertuar = new RepertuarKina();
           MainFrame.NavigationService.Navigate(repertuar);
        }
    }
}  
       