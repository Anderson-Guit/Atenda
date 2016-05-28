using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Atenda.App.Classes.Dbs;
using Atenda.App.Classes;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.Phone.Tasks;

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
            //ProgressbarTecnico.Visibility = Visibility.Collapsed;

        }


        private void Btn_Busca_Click(object sender, RoutedEventArgs e)
        {
            string nomeSearch;

            nomeSearch = Tb_Busca.Text;
            Lst_Tecnicos.ItemsSource = TecnicoDB.GetNome(nomeSearch);
        }

        private void TextBlock_Hold(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void Mi_Discar_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask();

            //string Tecnico = (sender as ListBox).SelectedItem;

            phoneCallTask.PhoneNumber = "190";
            phoneCallTask.DisplayName = "Tecnico";

            phoneCallTask.Show();
        }

    }
}