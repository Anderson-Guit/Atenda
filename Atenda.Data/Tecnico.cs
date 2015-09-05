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
        [Required(ErrorMessage = "Telefone é obrigatório")]
        public String Telefone { get; set; }

        [Display(Name = "Endereço", Description = "Informe o Endereço do Tecnico.")]
        [Required(ErrorMessage = "Endereço é obrigatório")]
        public String Endereco { get; set; }

        [Display(Name = "Adimição", Description = "Data de adimição do Tecnico.")]
        public DateTime Adimicao { get; set; }

        public Tecnico()
        {

        }
    }
}
