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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Atenda.App.Classes.Dbs;
using System.Net.NetworkInformation;

namespace Atenda.App
{
    public partial class MainPage : PhoneApplicationPage
    {
        public List<Agenda> pAgenda { get; set; }
        public string pTecnico { get; set; }

        public MainPage()
        {
            InitializeComponent();
            TesteConexão();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString["nomeParametro"] != null) 
            {
                string tecniconome = Convert.ToString(NavigationContext.QueryString["nomeParametro"]);
                UsuarioLogado_Nome.Text = tecniconome;
                Lst_Agenda.ItemsSource = AgendaDB.GetAllByTecnico(tecniconome);
                base.OnNavigatedTo(e);
            }
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
            NavigationService.Navigate(new Uri("/Pages/pProduto/pageProdutos.xaml", UriKind.Relative));
        }

        private void Btn_Agenda_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pAgenda/pageAgenda.xaml", UriKind.Relative));
        }

        private void Btn_Tecnico_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/pTecnico/pageListTecnicos.xaml", UriKind.Relative));
        }

        private static void TesteConexão()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                Consume consume = new Consume();
                consume.GetAgendaWebService();
            }
            else
                MessageBox.Show("Sem conexão com o servidor!");
        }
    }
}