using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
namespace Atenda.WP
{
    public partial class Login : PhoneApplicationPage
    {
        // Constructor
        public Login()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;

        private void Btn_Entrar_Click(object sender, RoutedEventArgs e)
        {
            #region Autopreenchimento e Validação

            Usuario usuario = new Usuario();
            String Nome = Tb_Nome.Text;
            String Senha = Pb_Senha.Password;


            if (usuario.Entrar(Nome, Senha))
            {

                //Cria um objeto da classe IsolatedStorageSettings para armazenamento das chaves

                if ((bool)Cb_Lembrar.IsChecked)
                {
                    //É necessário perguntar se a chave já existe para evitar que se crie chaves duplicadas, o que fatalmente irá provocar erros
                    if (iso.Contains("login.Usuario")) //Apenas atualiza os valores das chaves
                    {
                        iso["login.Usuario"] = Tb_Nome.Text;
                        iso["login.Senha"] = Pb_Senha.Password;
                    }
                    else //Cria novas chaves
                    {
                        iso.Add("login.Usuario", Tb_Nome.Text);
                        iso.Add("login.Senha", Pb_Senha.Password);
                    }
                    iso.Save(); //Necessário para armazenar os valores das chaves
                }
                else
                {
                    //Caso o usuário não queira mais armazenar suas credenciais, podemos remover as chaves
                    if (iso.Contains("login.Usuario"))
                    {
                        iso.Remove("login.Usuario");
                        iso.Remove("login.Senha");
                    }
                }
                //Direciona o usuário para uma página qualquer, caso ele acerte o login
                NavigationService.Navigate(new Uri("/Pages/MainPage.xaml", UriKind.Relative));
            }
            else
            {
                if (Tb_Nome.Text == "" || Pb_Senha.Password == "")
                {
                    MessageBox.Show("Preencha todos os campos!");
                }
                else
                {
                    MessageBox.Show("Usuário ou senha incorreta!");
                    Tb_Nome.Text = "";
                    Pb_Senha.Password = "";
                }
            }
            #endregion

        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            //Metodo para carregar Nome e Senha do usuário automaticamente
            string usuario, senha;
            IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;
            if (iso.TryGetValue<string>("login.Usuario", out usuario))
                Tb_Nome.Text = usuario;
            if (iso.TryGetValue<string>("login.Senha", out senha))
            {
                Pb_Senha.Password = senha;
                Cb_Lembrar.IsChecked = true;
            }
        }

        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Metodo de tratamento do botão Voltar do Bar
            MessageBoxResult result =
                MessageBox.Show("Deseja sair?", "Atenção", MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}