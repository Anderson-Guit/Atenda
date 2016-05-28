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
using Atenda.App.Classes.Dbs;
using System.Net.NetworkInformation;

namespace Atenda.App.Pages.pCliente
{
    public partial class pageCliente : PhoneApplicationPage
    {
        String[] Estados = { "", "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO",
                                "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", 
                                "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };

        public Cliente cliente { get; set; }

        Cliente pCliente;

        public pageCliente()
        {
            InitializeComponent();
            //TesteConexão();
            this.Lpk_Estado.ItemsSource = Estados;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Lst_Clientes.ItemsSource = ClienteDB.GetAll();
        }

        private void Btn_Salvar_Click(object sender, RoutedEventArgs e)
        {
            cliente = new Cliente
            {
                Nome = Tb_Nome.Text,
                Telefone = Tb_Telefone.Text,
                Endereco = Tb_Endereco.Text,
                Cidade = Tb_Cidade.Text,
                Bairro = Tb_Bairro.Text,
                Estado = Convert.ToString(Lpk_Estado.SelectedItem),
                CPF_CNPJ = Tb_CPF_CPNJ.Text
            };
            ClienteDB.Create(cliente);
            Tb_Nome.Text = "";
            Tb_Telefone.Text = "";
            Tb_Endereco.Text = "";
            Tb_Cidade.Text = "";
            Tb_Bairro.Text = "";
            Lpk_Estado.ItemsSource = "";
            Tb_CPF_CPNJ.Text = "";

            Lst_Clientes.ItemsSource = ClienteDB.GetAll();
        }

        private void onSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            pCliente = (sender as ListBox).SelectedItem as Cliente;
            NavigationService.Navigate(new Uri("/Pages/pCliente/pageClienteDetails.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (pCliente != null)
            {
                pageClienteDetails page = e.Content as pageClienteDetails;
                page.clienteDetails = pCliente;
            }
            Lst_Clientes.SelectionChanged -= onSelectionChange;
        }

        private void Btn_Busca_Click(object sender, RoutedEventArgs e)
        {
            string nomeSearch;

            nomeSearch = Tb_Busca.Text;
            Lst_Clientes.ItemsSource = ClienteDB.GetNome(nomeSearch);
        }

        private static void TesteConexão()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                Consume consume = new Consume();
                consume.GetClientesWebService();
            }
            else
                MessageBox.Show("Sem conexão com o servidor!");
        }
    }
}