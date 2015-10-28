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

namespace Atenda.App.Pages.pTecnico
{
    public partial class pageTecnico : PhoneApplicationPage
    {
        public Tecnico tecnico { get; set; }

        public pageTecnico()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Lst_Tecnicos.ItemsSource = TecnicoDB.GetAll();
        }

        private void Btn_Salvar_Click(object sender, RoutedEventArgs e)
        {
                tecnico = new Tecnico
                {
                    Nome = Tb_Nome.Text,
                    Telefone = Tb_Telefone.Text,
                    Endereco = Tb_Endereco.Text,
                    Admissao = Convert.ToDateTime(Dp_Admissao)
                };
                TecnicoDB.Create(tecnico);
        }

        private void Btn_Busca_Click(object sender, RoutedEventArgs e)
        {
            //tecnico = new Tecnico
            //{
            //    IdTecnico = Tb_IdTecnico;
            //};
            //TecnicoDB.GetOne(tecnico);
        }

        private void Page_Tecnico_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Tb_Btn_Cliente_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

    }
}