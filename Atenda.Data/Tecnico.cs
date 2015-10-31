using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Atenda.Data
{
    public class Tecnico
    {

        public int IdTecnico { get; set; }

        [Display(Name = "Nome", Description = "Informe o Nome do Tecnico.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Telefone", Description = "Informe o telefone do Tecnico.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Digite apenas numeros")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "Endereço", Description = "Informe o Endereço do Tecnico.")]
        public string Endereco { get; set; }

        [Display(Name = "Admissão", Description = "Data de admissão do Tecnico.")]
        [DataType(DataType.Date)]
        public DateTime Admissao { get; set; }

        [Display(Name = "Senha", Description = "Informe a senha do Tecnico")]
        [DataType(DataType.Password)]
        [Required]
        public string Senha { get; set; }

        [Display(Name = "Corfirme a Senha", Description = "Repita a senha")]
        [Compare("Senha", ErrorMessage = "A senha esta diferente!")]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; }

        public Tecnico()
        {

        }
    }
    public class Login
    {
        [Display(Name = "Nome", Description = "Informe o Nome do Usuario.")]
        [Required(ErrorMessage = "Digite o Nome de Usuario!")]
        public string Nome { get; set; }

        [Display(Name = "Senha", Description = "Informe a Senha do Usuário.")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Digite a Senha!")]
        public string Senha { get; set; }
    }
}
