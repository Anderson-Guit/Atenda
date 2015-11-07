using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Atenda.App.Classes;

namespace Atenda.App
{
    public partial class MainPage : PhoneApplicationPage
    {
        public string pTecnico { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void Btn_Cliente_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pCliente/pageCliente.xaml", UriKind.Relative));
        }

        private void Btn_OS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Orcamento_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Produto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Agenda_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pAgenda/pageAgenda.xaml", UriKind.Relative));
        }

        private void Btn_Tecnico_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}