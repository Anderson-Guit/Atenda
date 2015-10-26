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
            base.OnNavigatedTo(e);
        }

        private void Btn_Salvar_Click(object sender, RoutedEventArgs e)
        {
            Orcamento orcamento = new Orcamento
            {
                IdProduto = 1,
                idCliente = 3
            };
            OrcamentoDB.Create(orcamento);
        }

        private void Btn_Busca_Click(object sender, RoutedEventArgs e)
        {

        }

        //windows phone toolkit
    }
}