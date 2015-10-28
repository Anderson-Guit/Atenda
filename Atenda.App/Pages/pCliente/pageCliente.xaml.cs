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

        Cliente pCliente;

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
                    CPF_CNPJ = Tb_Cidade.Text  
                };
                ClienteDB.Create(cliente);
                Tb_Nome.Text = null;
                Tb_Telefone.Text = null;
                Tb_Endereco.Text = null;
                Tb_Cidade.Text = null;
                Tb_CPF_CPNJ.Text = null;
        }

        private void Btn_Busca_Click(object sender, RoutedEventArgs e)
        {

        }

        private void onSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            //seleciona um cliente da lista
            pCliente = (sender as ListBox).SelectedItem as Cliente;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //manda o cliente selecionado para proxima pagina
            if (pCliente != null)
            {
                pageDetailsCliente page = e.Content as pageDetailsCliente;
                page.clienteDetails = pCliente;
            }

            //elimina o evento do listbox para quando voltar pra essa page ela não voltar pra outra pagina.
            Lst_Clientes.SelectionChanged -= onSelectionChange;
        }

        private void Abtn_Abrir_Click(object sender, EventArgs e)
        {
            //seleciona um cliente da lista
            pCliente = (sender as ListBox).SelectedItem as Cliente;
        }

    }
}