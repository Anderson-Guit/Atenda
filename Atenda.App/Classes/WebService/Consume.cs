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


namespace Atenda.App.Classes
{
    class Consume
    {

        //Tecnico
        public void GetTecnicosWebService()
        {
            WebClient webCliente = new WebClient();

            webCliente.DownloadStringCompleted += Tecnicos_DownloadStringCompleted;

            webCliente.DownloadStringAsync(new Uri(@"http://apiatenda.azurewebsites.net/api/tecnico/listar"));
        }
        void Tecnicos_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    JArray jsonArray_Item = JArray.Parse(e.Result);
                    

                    for (int x = 0; jsonArray_Item.Count() > x; x++)
                    {
                        
                        Tecnico tecnico = new Tecnico();

                        tecnico.IdTecnico = jsonArray_Item[x].Value<int>("IdTecnico");
                        tecnico.Nome = jsonArray_Item[x].Value<string>("Nome");
                        tecnico.Telefone = jsonArray_Item[x].Value<string>("Telefone");
                        tecnico.Endereco = jsonArray_Item[x].Value<string>("Endereco");
                        tecnico.Senha = jsonArray_Item[x].Value<string>("Senha");

                        if (Verificacao(tecnico))
                        {
                            TecnicoDB.Refresh(tecnico);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                        "Tecnico",
                        MessageBoxButton.OK);

            }
        }

        //Produto
        public void GetProdutosWebService()
        {
            WebClient webCliente = new WebClient();

            webCliente.DownloadStringCompleted += Produtos_DownloadStringCompleted;


            webCliente.DownloadStringAsync(new Uri(@"http://apiatenda.azurewebsites.net/api/produto"));
        }
        void Produtos_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    JArray jsonArray_Item = JArray.Parse(e.Result);


                    for (int x = 0; jsonArray_Item.Count() > x; x++)
                    {

                        Produto produto = new Produto();

                        produto.IdProduto = jsonArray_Item[x].Value<int>("IdProduto");
                        produto.Nome = jsonArray_Item[x].Value<string>("Nome");
                        produto.Valor = jsonArray_Item[x].Value<decimal>("Valor");
                        produto.Descricao = jsonArray_Item[x].Value<string>("Descricao");
                        produto.QntdEstoque = jsonArray_Item[x].Value<int>("QntdEstoque");

                        if (Verificacao(produto))
                        {
                            ProdutoDB.Create(produto);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                        "Produto",
                        MessageBoxButton.OK);

            }
        }

        //Cliente
        public void GetClientesWebService()
        {
            WebClient webCliente = new WebClient();

            webCliente.DownloadStringCompleted += Clientes_DownloadStringCompleted;

            webCliente.DownloadStringAsync(new Uri(@"http://apiatenda.azurewebsites.net/api/Cliente"));
        }
        void Clientes_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    JArray jsonArray_Item = JArray.Parse(e.Result);


                    for (int x = 0; jsonArray_Item.Count() > x; x++)
                    {

                        Cliente cliente = new Cliente();

                        cliente.IdCliente = jsonArray_Item[x].Value<int>("IdCliente");
                        cliente.Nome = jsonArray_Item[x].Value<string>("Nome");
                        cliente.Telefone = jsonArray_Item[x].Value<string>("Telefone");
                        cliente.Endereco = jsonArray_Item[x].Value<string>("Endereco");
                        cliente.Bairro = jsonArray_Item[x].Value<string>("Bairro");
                        cliente.Cidade = jsonArray_Item[x].Value<string>("Cidade");
                        cliente.Estado = jsonArray_Item[x].Value<string>("Estado");
                        cliente.CPF_CNPJ = jsonArray_Item[x].Value<string>("CPF_CNPJ");

                        if (Verificacao(cliente))
                        {
                            ClienteDB.Create(cliente);
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                        "Cliente",
                        MessageBoxButton.OK);

            }
        }

        //Agenda
        public void GetAgendaWebService()
        {
            WebClient webCliente = new WebClient();

            webCliente.DownloadStringCompleted += Agenda_DownloadStringCompleted;


            webCliente.DownloadStringAsync(new Uri(@"http://apiatenda.azurewebsites.net/api/agenda"));
        }
        void Agenda_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    JArray jsonArray_Item = JArray.Parse(e.Result);


                    for (int x = 0; jsonArray_Item.Count() > x; x++)
                    {

                        Agenda agenda = new Agenda();

                        agenda.IdAgenda = jsonArray_Item[x].Value<int>("IdAgenda");
                        agenda.IdTecnico = jsonArray_Item[x].Value<int>("IdTecnico");
                        agenda.TecnicoNome = jsonArray_Item[x].Value<string>("TecnicoNome");
                        agenda.IdCliente = jsonArray_Item[x].Value<int>("IdCliente");
                        agenda.ClienteNome = jsonArray_Item[x].Value<string>("ClienteNome");
                        agenda.Data = jsonArray_Item[x].Value<DateTime>("Data");
                        agenda.Hora = jsonArray_Item[x].Value<DateTime?>("Hora");
                        agenda.Local = jsonArray_Item[x].Value<string>("Local");
                        agenda.Observacoes = jsonArray_Item[x].Value<string>("Observacoes");
                        agenda.Status = jsonArray_Item[x].Value<string>("Status");

                        if (Verificacao(agenda))
                        {
                            AgendaDB.Create(agenda);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                        "Agenda",
                        MessageBoxButton.OK);

            }
        }

        //Orçamento
        public void GetOrcamentoWebService()
        {
            WebClient webCliente = new WebClient();

            webCliente.DownloadStringCompleted += Orcamento_DownloadStringCompleted;


            webCliente.DownloadStringAsync(new Uri(@"http://apiatenda.azurewebsites.net/api/orcamento"));
        }
        void Orcamento_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    JArray jsonArray_Item = JArray.Parse(e.Result);


                    for (int x = 0; jsonArray_Item.Count() > x; x++)
                    {

                        Orcamento orcamento = new Orcamento();

                        orcamento.IdOrcamento = jsonArray_Item[x].Value<int>("IdOrcamento");
                        orcamento.idCliente = jsonArray_Item[x].Value<int>("idCliente");
                        orcamento.IdProduto = jsonArray_Item[x].Value<int>("IdProduto");
                        orcamento.NomeProduto = jsonArray_Item[x].Value<string>("NomeProduto");
                        orcamento.ValorProduto = jsonArray_Item[x].Value<decimal>("ValorProduto");
                        orcamento.Servico = jsonArray_Item[x].Value<string>("Servico");
                        orcamento.ValorServico = jsonArray_Item[x].Value<decimal>("ValorServico");
                        orcamento.ValorTotal = jsonArray_Item[x].Value<decimal>("ValorTotal");

                        if (Verificacao(orcamento))
                        {
                            OrcamentoDB.Create(orcamento);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                        "Orçamento",
                        MessageBoxButton.OK);

            }
        }

        //OS
        public void GetOSWebService()
        {
            WebClient webCliente = new WebClient();

            webCliente.DownloadStringCompleted += OS_DownloadStringCompleted;


            webCliente.DownloadStringAsync(new Uri(@"http://apiatenda.azurewebsites.net/api/ordemservico"));
        }
        void OS_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    JArray jsonArray_Item = JArray.Parse(e.Result);


                    for (int x = 0; jsonArray_Item.Count() > x; x++)
                    {

                        OrdemServico os = new OrdemServico();

                        os.IdOS = jsonArray_Item[x].Value<int>("IdOS");
                        os.IdCliente = jsonArray_Item[x].Value<int>("IdCliente");
                        os.ClienteNome = jsonArray_Item[x].Value<string>("ClienteNome");
                        os.IdTecnico = jsonArray_Item[x].Value<int>("IdTecnico");
                        os.TecnicoNome = jsonArray_Item[x].Value<string>("TecnicoNome");
                        os.Equipamento = jsonArray_Item[x].Value<string>("Equipamento");
                        os.Marca = jsonArray_Item[x].Value<string>("Marca");
                        os.Modelo = jsonArray_Item[x].Value<string>("Modelo");
                        os.NumeroSerie = jsonArray_Item[x].Value<string>("NumeroSerie");
                        os.Defeito = jsonArray_Item[x].Value<string>("Defeito");
                        os.Servico = jsonArray_Item[x].Value<string>("Servico");
                        os.DataEntrada = jsonArray_Item[x].Value<DateTime>("DataEntrada");
                        os.DataSaida = jsonArray_Item[x].Value<DateTime?>("DataSaida");
                        os.Local = jsonArray_Item[x].Value<string>("Local");
                        os.Observacoes = jsonArray_Item[x].Value<string>("Observacoes");
                        os.Custo = jsonArray_Item[x].Value<decimal?>("Custo");
                        os.Status = jsonArray_Item[x].Value<string>("Status");

                        if (Verificacao(os))
                        {
                            OrdemServicoDB.Create(os);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                        "Ordem de Serviço",
                        MessageBoxButton.OK);

            }
        }


        public bool Verificacao(Tecnico pObjeto)
        {
            Tecnico verf = TecnicoDB.GetOne(pObjeto.IdTecnico);

            if (verf == null)
            {
                //
                return true;
            }
            else
            {
                return false;
            }
                
        }

        public bool Verificacao(Cliente pObjeto)
        {
            var verf = ClienteDB.GetOne(pObjeto.IdCliente);

            if (verf == null)
            {
                //
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Verificacao(Produto pObjeto)
        {
            var verf = ProdutoDB.GetOne(pObjeto.IdProduto);

            if (verf == null)
            {
                //
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Verificacao(Agenda pObjeto)
        {
            var verf = AgendaDB.GetOne(pObjeto.IdAgenda);

            if (verf == null)
            {
                //
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Verificacao(Orcamento pObjeto)
        {
            var verf = OrcamentoDB.GetOne(pObjeto.IdOrcamento);

            if (verf == null)
            {
                //
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool Verificacao(OrdemServico pObjeto)
        {
            var verf = OrdemServicoDB.GetOne(pObjeto.IdOS);

            if (verf == null)
            {
                //
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
