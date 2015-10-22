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
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Display(Name = "Endereço", Description = "Informe o Endereço do Tecnico.")]
        public string Endereco { get; set; }

        [Display(Name = "Admissão", Description = "Data de admissão do Tecnico.")]
        [DataType(DataType.Date)]
        public DateTime Admissao { get; set; }

        public Tecnico()
        {

        }
    }
}
