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
        public String Nome { get; set; }

        [Display(Name = "Telefone", Description = "Informe o telefone do Cliente.")]
        [Required(ErrorMessage = "Telefone é obrigatório")]
        public String Telefone { get; set; }

        [Display(Name = "Endereço", Description = "Informe o Endereço do Cliente.")]
        [Required(ErrorMessage = "Endereço é obrigatório")]
        public String Endereco { get; set; }

        [Display(Name = "Bairro", Description = "Informe o Bairro do Cliente.")]
        [Required(ErrorMessage = "Bairro é obrigatório")]
        public String Bairro { get; set; }

        [Display(Name = "Cidade", Description = "Informe a Cidade do Cliente.")]
        [Required(ErrorMessage = "Cidade é obrigatório")]
        public String Cidade { get; set; }

        [Display(Name = "Estado", Description = "Informe o Estado do Cliente.")]
        [Required(ErrorMessage = "Estado é obrigatório")]
        public String Estado { get; set; }

        [Display(Name = "País", Description = "Informe o País do Cliente.")]
        [Required(ErrorMessage = "País é obrigatório")]
        public String Pais { get; set; }

        [Display(Name = "Cpf", Description = "Informe o Cpf do Cliente.")]
        [Required(ErrorMessage = "Cpf é obrigatório")]
        public String CPF { get; set; }

        public Cliente()
        {

        }
    }
}
