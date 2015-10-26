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
    public partial class pageCliente : PhoneApplicationPage
    {
        String[] Estado = { "AC","RS","SC","PR","MT","RJ","SP","MP"};

        public Cliente cliente { get; set; }

        public pageCliente()
        {
            InitializeComponent();
            this.Lpk_Estado.ItemsSource = Estado;
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
                    Estado = Convert.ToString(Lpk_Estado.SelectedItem),
                    Pais = Tb_Cidade.Text,
                    CPF_CNPJ = Tb_Cidade.Text  
                };
                ClienteDB.Create(cliente);
        }

        private void Page_Cliente_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Btn_Busca_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Tb_Btn_Cliente_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string uri = string.Format("/Pages/Cliente/pageDetailsCliente.xaml?pIdCliente={0}",  Tb_Nome.Text);
            
            NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }
    }
}