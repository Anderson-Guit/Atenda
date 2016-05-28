using Atenda.App.Classes.Dbs;
using Atenda.App.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Atenda.App.Classes.WebService
{
    class Post
    {

        public void ClientePost()
        {

            try
            {
                List<Cliente> listCliente = ClienteDB.GetAll();

                for (int x = 0; listCliente.Count() > x; x++)
                {
                    WebClient webClient = new WebClient();
                    webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                    webClient.Encoding = Encoding.UTF8;

                    webClient.UploadStringAsync(new Uri("http://apiatenda.azurewebsites.net/api/cliente/"), "POST",
                        "&Nome=" + listCliente[x].Nome + 
                        "&Telefone=" + listCliente[x].Telefone + 
                        "&Endereco=" + listCliente[x].Endereco + 
                        "&Bairro=" + listCliente[x].Bairro + 
                        "&Cidade=" + listCliente[x].Cidade + 
                        "&Estado=" + listCliente[x].Estado + 
                        "&CPF_CNPJ=" + listCliente[x].CPF_CNPJ);
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OrcamentoPost()
        {

            try
            {
                List<Orcamento> listOrcamento = OrcamentoDB.GetAll();

                for (int x = 0; listOrcamento.Count() > x; x++)
                {
                    WebClient webClient = new WebClient();
                    webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                    webClient.Encoding = Encoding.UTF8;

                    webClient.UploadStringAsync(new Uri("http://apiatenda.azurewebsites.net/api/agenda/"), "POST", 
                        "&Servico=" + listOrcamento[x].Servico + 
                        "&ValorServico=" + listOrcamento[x].ValorServico + 
                        "&IdProduto=" + listOrcamento[x].IdProduto + 
                        "&QntdProduto=" + listOrcamento[x].QntdProduto + 
                        "&ValorTotal=" + listOrcamento[x].ValorTotal + 
                        "&idCliente=" + listOrcamento[x].idCliente);
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AgendaPost()
        {

            try
            {
                List<Agenda> listAgenda = AgendaDB.GetAll();

                for (int x = 0; listAgenda.Count() > x; x++)
                {
                    WebClient webClient = new WebClient();
                    webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                    webClient.Encoding = Encoding.UTF8;

                    webClient.UploadStringAsync(new Uri("http://apiatenda.azurewebsites.net/api/agenda/"), "POST",
                        "&IdTecnico=" + listAgenda[x].IdTecnico + 
                        "&IdCliente=" + listAgenda[x].IdCliente + 
                        "&Hora=" + listAgenda[x].Hora + 
                        "&Data=" + listAgenda[x].Data + 
                        "&Local=" + listAgenda[x].Local + 
                        "&Servicos=" + listAgenda[x].Servicos + 
                        "&Observacoes=" + listAgenda[x].Observacoes + 
                        "&Status=" + listAgenda[x].Status);
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OSPost()
        {

            try
            {
                List<OrdemServico> listOS = OrdemServicoDB.GetAll();

                for (int x = 0; listOS.Count() > x; x++)
                {
                    WebClient webClient = new WebClient();
                    webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";
                    webClient.Encoding = Encoding.UTF8;

                    webClient.UploadStringAsync(new Uri("http://apiatenda.azurewebsites.net/api/agenda/"), "POST",
                        "&IdCliente=" + listOS[x].IdCliente +
                        "&IdTecnico=" + listOS[x].IdTecnico +
                        "&Equipamento=" + listOS[x].Equipamento +
                        "&Marca=" + listOS[x].Marca +
                        "&Modelo=" + listOS[x].Modelo +
                        "&NumeroSerie=" + listOS[x].NumeroSerie +
                        "&Defeito=" + listOS[x].Defeito +
                        "&Servico=" + listOS[x].Servico +
                        "&DataEntrada=" + Convert.ToString(listOS[x].DataEntrada) +
                        "&DataSaida=" + Convert.ToString(listOS[x].DataSaida) +
                        "&Local=" + listOS[x].Local +
                        "&Observacoes=" + listOS[x].Observacoes +
                        "&Custo=" + listOS[x].Observacoes +
                        "&Status=" + listOS[x].Status);
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


        
