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

namespace Atenda.App.Pages.pTecnico
{
    public partial class pageListTecnicos : PhoneApplicationPage
    {
        public pageListTecnicos()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Lst_Tecnicos.ItemsSource = TecnicoDB.GetAll();
        }

        private void onSelectionChange(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_Busca_Click(object sender, RoutedEventArgs e)
        {
            string nomeSearch;

            nomeSearch = Tb_Busca.Text;
            Lst_Tecnicos.ItemsSource = TecnicoDB.GetNome(nomeSearch);
        }
    }
}