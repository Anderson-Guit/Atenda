using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Atenda.App.Classes.Dbs;

namespace Atenda.App
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Btn_Tecnico_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pTecnico/pageTecnico.xaml", UriKind.Relative));
        }

        private void Btn_Cliente_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pCliente/pageCliente.xaml", UriKind.Relative));
        }

        private void Btn_OS_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pOS/pageOS.xaml", UriKind.Relative));
        }

        private void Btn_Orcamento_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pOrcamento/pageOrcamento.xaml", UriKind.Relative));
        }

        private void Btn_Produto_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pProduto/pageProduto.xaml", UriKind.Relative));
        }

        private void Btn_Agenda_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pAgenda/pageAgenda.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBoxResult.OK == MessageBox.Show("Deseja sair da ATENDA?", Title = "Atenção", MessageBoxButton.OKCancel))
            {
                base.OnBackKeyPress(e);
            }
            else
                e.Cancel = true;
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Lst_Clientes.ItemsSource = AgendaDB.GetAll();
        }
    }
}