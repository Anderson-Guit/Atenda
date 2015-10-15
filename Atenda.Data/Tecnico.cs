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
        public String Nome { get; set; }

        [Display(Name = "Telefone", Description = "Informe o telefone do Tecnico.")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(##) ####-####")]
        public String Telefone { get; set; }

        [Display(Name = "Endereço", Description = "Informe o Endereço do Tecnico.")]
        public String Endereco { get; set; }

        [Display(Name = "Admissão", Description = "Data de admissão do Tecnico.")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Admissao { get; set; }

        public Tecnico()
        {

        }
    }
}
