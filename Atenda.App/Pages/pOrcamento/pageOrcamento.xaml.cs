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
using System.Windows.Input;

namespace Atenda.App.Pages.pOrcamento
{
    public partial class pageOrcamento : PhoneApplicationPage
    {
        public pageOrcamento()
        {
            InitializeComponent();
            TesteConexão();
            Lpk_Cliente.ItemsSource = ClienteDB.GetAll();
            Lpk_Produto.ItemsSource = TecnicoDB.GetAll();
            Lst_Orcamento.ItemsSource = OrcamentoDB.GetAll();
        }

        private void MaskeditNumererico_DuasCasasDecimais(TextBox txt, KeyEventArgs e)
        {
            var numero = Tb_ValorServico.Text;
            //Verifica de a tecla digitada foi algo diferente de números ou BackSpace
            if (e.Key != Key.Back && (e.Key < Key.D0 || e.Key > Key.D9))
            {
                e.Handled = true;
            }
            else
            {
                if (e.Key == Key.Back && numero.Length > 0) //Se digitou BackSpace então retiramos o último número digitado
                    numero = numero.Substring(0, numero.Length - 1);
                else
                    numero += Convert.ToChar(e.PlatformKeyCode).ToString(); //Concatenamos o número digitado aos já existentes

                //Verificações para realizar o maskedit em C#. Nesse caso o formato são números com 2 casas decimais
                if (numero.Length == 0)
                    txt.Text = "";
                else if (numero.Length < 2)
                    txt.Text = "0,0" + numero;
                else if (numero.Length == 2)
                    txt.Text = "0," + numero;
                else
                    txt.Text = numero.Substring(0, numero.Length - 2) + "," + numero.Substring(numero.Length - 2, 2);
            }
        }



        private void Btn_Salvar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void onSelectionChange(object sender, SelectionChangedEventArgs e)
        {

        }

        private static void TesteConexão()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                Consume consume = new Consume();

                consume.GetOrcamentoWebService();
            }
            else
                MessageBox.Show("Sem conexão com o servidor!");
        }

    }
}