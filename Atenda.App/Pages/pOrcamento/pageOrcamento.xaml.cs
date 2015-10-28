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

namespace Atenda.App.Pages.pOrcamento
{
    public partial class pageOrcamento : PhoneApplicationPage
    {
        public pageOrcamento()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Lp_Produto.ItemsSource = ProdutoDB.GetAll();
            Lp_Cliente.ItemsSource = ClienteDB.GetAll();
            base.OnNavigatedTo(e);
        }

        private void Btn_Salvar_Click(object sender, RoutedEventArgs e)
        {
            Produto produto = Lp_Produto.SelectedItem as Produto;
            Cliente cliente = Lp_Cliente.SelectedItem as Cliente;

            var valorProduto = produto.Valor;
            var valorTotal = valorProduto + decimal.Parse(Tb_ValorServico.Text);

            Orcamento orcamento = new Orcamento
            {
                Servico = Tb_Servico.Text,
                ValorServico = decimal.Parse(Tb_ValorServico.Text),
                IdProduto = produto.IdProduto,
                idCliente = cliente.IdCliente,
                ValorTotal = valorTotal
            };
            OrcamentoDB.Create(orcamento);
        }

        private void Btn_Busca_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}