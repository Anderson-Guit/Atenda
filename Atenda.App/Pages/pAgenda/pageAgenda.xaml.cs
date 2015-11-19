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

namespace Atenda.App.Pages.pAgenda
{
    public partial class pageAgenda : PhoneApplicationPage
    {
        String[] Status = { "", "Aguardando", "Em Execução", "Realizado", "Cancelado", ""};

        public Agenda agenda { get; set; }

        Agenda pAgenda;

        public pageAgenda()
        {
            InitializeComponent();
            this.Lpk_Status.ItemsSource = Status;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Lpk_Cliente.ItemsSource = ClienteDB.GetAll();
            Lpk_Tecnico.ItemsSource = TecnicoDB.GetAll();
            Lst_Agendas.ItemsSource = AgendaDB.GetAll();
        }
        
        private void Btn_Salvar_Click(object sender, RoutedEventArgs e)
        {
            agenda = new Agenda
            {
                IdCliente = Convert.ToInt32(Lpk_Cliente.SelectedItem),
                Data = Convert.ToDateTime(Dp_Data),
                Hora = Convert.ToDateTime(Tp_Hora),
                Servicos = Tb_Servicos.Text,
                Local = Tb_Local.Text,
                Observacoes = Tb_Observacoes.Text,
                IdTecnico = Convert.ToInt32(Lpk_Tecnico.SelectedItem),
                Status = Convert.ToString(Lpk_Status.SelectedItem)
            };
            AgendaDB.Create(agenda);
        }

        private void onSelectionChange(object sender, SelectionChangedEventArgs e)
        {
            pAgenda = (sender as ListBox).SelectedItem as Agenda;
            NavigationService.Navigate(new Uri("/Pages/pAgenda/pageAgendaDetails.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (pAgenda != null)
            {
                pageAgendaDetails page = e.Content as pageAgendaDetails;
                page.agendaDetails = pAgenda;
            }
            Lst_Agendas.SelectionChanged -= onSelectionChange;
        }

        private void Btn_Busca_Click(object sender, RoutedEventArgs e)
        {
            //string nomeSearch;

            //nomeSearch = Tb_Busca.Text;
            //Lst_AgendaSearch.ItemsSource = AgendaDB.GetNome(nomeSearch);
        }
    }
}