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

namespace Atenda.App.Pages.pCliente
{
    public partial class pageClienteDetails : PhoneApplicationPage
    {
        String[] Estados = { "", "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO",
                                "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", 
                                "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };

        public Cliente clienteDetails { get; set; }

        public pageClienteDetails()
        {
            InitializeComponent();
            this.Lpk_Estado.ItemsSource = Estados;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            Tb_Nome.Text = clienteDetails.Nome;
            Tb_Telefone.Text = clienteDetails.Telefone;
            Tb_Endereco.Text = clienteDetails.Endereco;
            Tb_Cidade.Text = clienteDetails.Cidade;
            Lpk_Estado.SelectedItem = clienteDetails.Estado;
            Tb_Bairro.Text = clienteDetails.Bairro;
            Tb_CPF_CPNJ.Text = clienteDetails.CPF_CNPJ;

            base.OnNavigatedTo(e);
        }

        private void Btn_Editar_Click(object sender, RoutedEventArgs e)
        {
            clienteDetails = new Cliente
            
            {
                IdCliente = clienteDetails.IdCliente,
                Nome = Tb_Nome.Text,
                Telefone = Tb_Telefone.Text,
                Endereco = Tb_Endereco.Text,
                Cidade = Tb_Cidade.Text,
                Bairro = Tb_Bairro.Text,
                Estado = Convert.ToString(Lpk_Estado.SelectedItem),
                CPF_CNPJ = Tb_CPF_CPNJ.Text
            };
            ClienteDB.Update(clienteDetails);
        }

        private void Btn_Excluir_Click(object sender, RoutedEventArgs e)
        {
            ClienteDB.Delete(clienteDetails.IdCliente);
            NavigationService.Navigate(new Uri("/Pages/pCliente/pageCliente.xaml", UriKind.Relative));
        }
    }
}