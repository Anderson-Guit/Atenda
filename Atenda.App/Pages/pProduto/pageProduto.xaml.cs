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

namespace Atenda.App.Pages.pProduto
{
    public partial class pageProduto : PhoneApplicationPage
    {
        public Produto produto { get; set; }

        public pageProduto()
        {
            InitializeComponent();
        }

        private void Btn_Salvar_Click(object sender, RoutedEventArgs e)
        {
            produto = new Produto
            {
                Nome = Tb_Nome.Text,
                Descricao = Tb_Descricao.Text,
                Valor = Convert.ToDecimal(Tb_Valor.Text),
                QntdEstoque = Convert.ToInt32(Tb_Qntd.Text)

            };
            ProdutoDB.Create(produto);
        }
    }
}