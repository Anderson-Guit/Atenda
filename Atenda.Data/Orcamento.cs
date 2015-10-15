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
        public String Servico { get; set; }

        [Display(Name = "Valor", Description = "Valor do serviço.")]
        [DisplayFormat(DataFormatString = "{0,n2}")]
        public Decimal ValorServico { get; set; }

        public int IdProduto { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required]
        public String NomeProduto { get; set; }

        [Display(Name = "Valor do Produto")]
        [DisplayFormat(DataFormatString = "{0,n2}")]
        public Decimal ValorProduto { get; set; }

        [Display(Name = "Valor Total", Description = "Valor total do orçamento.")]
        [DisplayFormat(DataFormatString = "{0,n2}")]
        public Decimal ValorTotal { get; set; }

        public int IdCliente { get; set; }

        [Display(Name = "Produto", Description = "Escolha o produto.")]
        [DisplayFormat(DataFormatString = "{0,n2}")]
        [Required]
        public String NomeCliente { get; set; }
        
        public Orcamento()
        {

        }
    }
}
