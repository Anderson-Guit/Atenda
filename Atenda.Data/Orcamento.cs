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
        [Required(ErrorMessage = "Serviço é obrigatório")]
        [DataType(DataType.MultilineText)]
        public string Servico { get; set; }

        [Display(Name = "Valor do serviço", Description = "Valor do serviço.")]
        [DataType(DataType.Currency)]
        public decimal ValorServico { get; set; }

        public int IdProduto { get; set; }

        [Display(Name = "Produto")]
        public string NomeProduto { get; set; }

        [Display(Name = "Valor do Produto")]
        [DataType(DataType.Currency)]
        public decimal ValorProduto { get; set; }

        [Display(Name = "Valor Total", Description = "Valor total do orçamento.")]
        [DataType(DataType.Currency)]
        public decimal ValorTotal { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Display(Name = "Cliente")]
        public string NomeCliente { get; set; }
        
        public Orcamento()
        {

        }
    }
}
