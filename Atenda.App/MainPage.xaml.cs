using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Atenda.App
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
           if (MessageBoxResult.OK == MessageBox.Show("Deseja sair da ATENDA?", Title="Atenção", MessageBoxButton.OKCancel))
           {
              base.OnBackKeyPress(e);
           }
           else
              e.Cancel = true;
        }

        private void Btn_Tecnico_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pageTecnico.xaml", UriKind.Relative));
        }

        private void Btn_Cliente_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pageCliente.xaml", UriKind.Relative));
        }

        private void Btn_OS_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Orcamento_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pageOrcamento.xaml", UriKind.Relative));
        }

    }
}