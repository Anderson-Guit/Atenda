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
using Atenda.App.Classes;

namespace Atenda.App.Pages.pProduto
{
    public partial class pageProdutos : PhoneApplicationPage
    {
        public pageProdutos()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Lst_Produtos.ItemsSource = ProdutoDB.GetAll();
        }

        private void onSelectionChange(object sender, SelectionChangedEventArgs e)
        {
             
        }

        private void Btn_Busca_Click(object sender, RoutedEventArgs e)
        {
            string nomeSearch;

            nomeSearch = Tb_Busca.Text;
            Lst_Produtos.ItemsSource = ProdutoDB.GetNome(nomeSearch);
        }
    }
}