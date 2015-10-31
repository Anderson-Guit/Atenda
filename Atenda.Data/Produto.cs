using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.Data
{
    public class Produto
    {
        public int IdProduto { get; set; }

        [Display(Name = "Nome", Description = "Informe o Nome do Poduto.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Descrição", Description = "Informe a Descrição do Poduto.")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Display(Name = "Valor", Description = "Informe o Valor do Produto.")]
        [Required(ErrorMessage = "Valor é obrigatório")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Display(Name = "Quantidade em Estoque", Description = "Informe a Quantidade de Produtos em Estoque.")]
        public int QntdEstoque { get; set; }

        public Produto()
        {

        }
    }
}
