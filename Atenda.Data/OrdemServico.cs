using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.Data
{
    public class OrdemServico
    {
        [Key]
        public int IdOS { get; set; }

        [Key]
        public int IdCliente { get; set; }

        [Display(Name = "Cliente", Description = "Nome do Cliente.")]
        public string ClienteNome { get; set; }

        [Key]
        public int IdTecnico { get; set; }

        [Display(Name = "Tecnico", Description = "Nome do Tecnico.")]
        public string TecnicoNome { get; set; }

        [Display(Name = "Equipamento", Description = "Tipo do Equipamento.")]
        [Required(ErrorMessage = "Equipamento é obrigatório")]
        public string Equipamento { get; set; }

        [Display(Name = "Marca", Description = "Marca do Equipamento.")]
        public string Marca { get; set; }

        [Display(Name = "Modelo", Description = "Informe o Modelo do Equipamento.")]
        public string Modelo { get; set; }

        [Display(Name = "Número de Série", Description = "Informe o Número de Série do Equipamento.")]
        public string NumeroSerie { get; set; }

        [Display(Name = "Defeito", Description = "Informe o Defeito do Equipamento.")]
        [Required(ErrorMessage = "Defeito é obrigatório")]
        [StringLength(300, MinimumLength = 5, ErrorMessage =
           "O Defeito deve ter no mínimo 5 e no máximo 100 caracteres.")]
        [DataType(DataType.MultilineText)]
        public string Defeito { get; set; }

        [Display(Name = "Serviço", Description = "Informe o Serviço executado.")]
        [Required(ErrorMessage = "Serviço é obrigatório")]
        [DataType(DataType.MultilineText)]
        public string Servico { get; set; }

        [Display(Name = "Data de entrada", Description = "Informe a data de entrada do serviço.")]
        [Required(ErrorMessage = "Data de entrada é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataEntrada { get; set; }

        [Display(Name = "Data de saida", Description = "Informe a data de saida do serviço.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataSaida { get; set; }

        [Display(Name = "Local", Description = "Informe o Local do Equipamento.")]
        public string Local { get; set; }

        [Display(Name = "Observações", Description = "Informe as Observações do Equipamento.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage =
           "Se necessário as observações devem ter no mínimo 5 e no máximo 200 caracteres.")]
        [DataType(DataType.MultilineText)]
        public string Observacoes { get; set; }

        [Display(Name = "Produtos", Description = "Adicione os produtos")]
        public List<Produto> IdProduto { get; set; }

        public int? QntdProduto { get; set; }

        [Display(Name = "Custo", Description = "Valor do serviço.")]
        [DataType(DataType.Currency)]
        public decimal? Custo { get; set; }

        [Display(Name = "Status", Description = "Informe o Status do Equipamento.")]
        [Required(ErrorMessage = "Status é obrigatório")]
        public string Status { get; set; }

        public OrdemServico()
        {

        }

        public List<OrdemServico> ListStatus()
        {
            return new List<OrdemServico>
                {
                    new OrdemServico {Status = "Aberta"},
                    new OrdemServico {Status = "Em Execução"},
                    new OrdemServico {Status = "Em Espera"},
                    new OrdemServico {Status = "Pronta"},
                    new OrdemServico {Status = "Recusada"},
                };
        }

        public string Search { get; set; }
        public List<OrdemServico> ListSearch()
        {

            return new List<OrdemServico>
                {
                    new OrdemServico {Search = "Nº OS"},
                    new OrdemServico {Search = "Tecnico"},
                    new OrdemServico {Search = "Cliente"},

                };
        }

    }

}
