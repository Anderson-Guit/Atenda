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

namespace Atenda.App.Pages.pCliente
{
    public partial class pageDetailsCliente : PhoneApplicationPage
    {
        public Cliente clienteDetails { get; set; }


        public pageDetailsCliente()
        {
            InitializeComponent();
        }

        private void Btn_Editar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Excluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void page_DetailsCliente_Loaded(object sender, RoutedEventArgs e)
        {
            Tb_Nome.Text = clienteDetails.Nome;
            Tb_Telefone.Text = clienteDetails.Telefone;
            Tb_Endereco.Text = clienteDetails.Endereco;
            Tb_Cidade.Text = clienteDetails.Cidade;
            Lpk_Estado.SelectedItem = clienteDetails.Estado;
            Tb_CPF_CPNJ.Text = clienteDetails.CPF_CNPJ;
        }



    }
}