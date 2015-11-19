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
using System.IO.IsolatedStorage;

namespace Atenda.App
{
    public partial class Login : PhoneApplicationPage
    {
        public Login()
        {
            InitializeComponent();
        }

        IsolatedStorageSettings iso = IsolatedStorageSettings.ApplicationSettings;

        private void Btn_Entrar_Click(object sender, RoutedEventArgs e)
        {
            Tecnico check = new Tecnico();

            if (Tb_Nome.Text != "" || Pb_Senha.Password != "")
            {
                if (check.CheckUser(Tb_Nome.Text, Pb_Senha.Password))
                {
                    if ((bool)Cb_Lembrar.IsChecked)
                    {
                        
                        if (iso.Contains("login.Usuario"))
                        {
                            iso["login.Usuario"] = Tb_Nome.Text;
                            iso["login.Senha"] = Pb_Senha.Password;
                        }
                        else
                        {
                            iso.Add("login.Usuario", Tb_Nome.Text);
                            iso.Add("login.Senha", Pb_Senha.Password);
                        }
                    }
                    else
                    {
                        if (iso.Contains("login.Usuario"))
                        {
                            iso.Remove("login.Usuario");
                            iso.Remove("login.Senha");
                        }
                    }
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Nome ou senha inválidos!");
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos!");
            }
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
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
    }
}