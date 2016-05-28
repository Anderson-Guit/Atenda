using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Atenda.Data
{
    public class Orcamento
    {
        [Key]
        public int IdOrcamento { get; set; }

        [Display(Name = "Serviço", Description = "Informe o Serviço do Equipamento.")]
        [DataType(DataType.MultilineText)]
        public string Servico { get; set; }

        [Display(Name = "Valor do serviço", Description = "Valor do serviço.")]
        [DataType(DataType.Currency)]
        public decimal? Valor { get; set; }

        public int? IdProduto { get; set; }

        [Display(Name = "Produto")]
        public string ProdutoNome { get; set; }

        [Display(Name = "Quantidade")]
        public int? ProdutoQntd { get; set; }

        [Display(Name = "Valor do Produto")]
        [DataType(DataType.Currency)]
        public decimal? ProdutoValor { get; set; }

        [Display(Name = "Valor Total", Description = "Valor total do orçamento.")]
        [DataType(DataType.Currency)]
        public decimal? ValorTotal { get; set; }

        public int IdCliente { get; set; }

        [Display(Name = "Cliente")]
        public string ClienteNome { get; set; }
        
        public Orcamento()
        {

        }
    }
}
