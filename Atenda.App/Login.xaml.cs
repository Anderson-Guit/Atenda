using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Atenda.App
{
    public partial class Login : PhoneApplicationPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private void HL_Empresa_Click(object sender, RoutedEventArgs e)
        {

        }

        string Nome;
        string Senha;

        private void Btn_Entrar_Click(object sender, RoutedEventArgs e)
        {

            Nome = "admin";
            Senha = "admin";

            if (Tb_Nome.Text == Nome
                && Pb_Senha.Password == Senha)
            {
                MessageBox.Show("Seja bem vindo!" + Nome);
                NavigationService.Navigate(new Uri("MainPage.xaml", UriKind.Relative));
            }

        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //manda o cliente selecionado para proxima pagina
            if (Nome != null)
            {
                MainPage page = e.Content as MainPage;
                page.pTecnico = Nome;
            }
        }
    }
}