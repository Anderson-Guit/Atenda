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
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage =
            "Números e caracteres especiais não são permitidos no nome.")]
        public string Nome { get; set; }

        [Display(Name = "Telefone", Description = "Informe o telefone do Cliente.")]
        [Required(ErrorMessage = "Telefone é obrigatório")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite apenas numeros")]
        [StringLength(maximumLength: 11, MinimumLength = 8)]
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

        [Display(Name = "CPF/CNPJ", Description = "Informe o CPF (Pessoa Fisica) ou CNPJ (Pessoa Juridica) do Cliente.")]
        public string CPF_CNPJ { get; set; }

        public Cliente()
        {

        }

        public List<Cliente> ListaEstados()
        {
            return new List<Cliente>
                {
                    new Cliente {Estado = "AC"},
                    new Cliente {Estado = "AL"},
                    new Cliente {Estado = "AP"},
                    new Cliente {Estado = "AM"},
                    new Cliente {Estado = "BA"},
                    new Cliente {Estado = "CE"},
                    new Cliente {Estado = "DF"},
                    new Cliente {Estado = "ES"},
                    new Cliente {Estado = "GO"},
                    new Cliente {Estado = "MA"},
                    new Cliente {Estado = "MT"},
                    new Cliente {Estado = "MS"},
                    new Cliente {Estado = "MG"},
                    new Cliente {Estado = "PA"},
                    new Cliente {Estado = "PB"},
                    new Cliente {Estado = "PR"},
                    new Cliente {Estado = "PE"},
                    new Cliente {Estado = "PI"},
                    new Cliente {Estado = "RJ"},
                    new Cliente {Estado = "RN"},
                    new Cliente {Estado = "RS"},
                    new Cliente {Estado = "RO"},
                    new Cliente {Estado = "RR"},
                    new Cliente {Estado = "SC"},
                    new Cliente {Estado = "SP"},
                    new Cliente {Estado = "SE"},
                    new Cliente {Estado = "TO"},
                };
        }
    }
}