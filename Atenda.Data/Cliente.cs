using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.Data
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        [Display(Name = "Nome", Description = "Informe o Nome do Cliente.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Telefone", Description = "Informe o telefone do Cliente.")]
        [Required(ErrorMessage = "Telefone é obrigatório")]
        [RegularExpression(@"^\d+$", ErrorMessage="Digite apenas numeros")]
        [StringLength(maximumLength:10,MinimumLength=9)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "Endereço", Description = "Informe o Endereço do Cliente.")]
        public string Endereco { get; set; }

        [Display(Name = "Bairro", Description = "Informe o Bairro do Cliente.")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade", Description = "Informe a Cidade do Cliente.")]
        public string Cidade { get; set; }

        [Display(Name = "Estado", Description = "Informe o Estado do Cliente.")]
        public string Estado { get; set; }

        [Display(Name = "País", Description = "Informe o País do Cliente.")]
        public string Pais { get; set; }

        [Display(Name = "CPF/CNPJ", Description = "Informe o CPF (Pessoa Fisica) ou CNPJ (Pessoa Juridica) do Cliente.")]
        public string CPF_CNPJ { get; set; }

        public Cliente()
        {

        }
    }
}
