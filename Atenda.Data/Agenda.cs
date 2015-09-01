using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Atenda.Data
{
    public class Agenda
    {

        public int IdAgenda { get; set; }
        public int IdTecnico { get; set; }
        public int IdCliente { get; set; }

        [Display(Name = "Tecnico", Description = "Nome do tecnico que fará o atendimento.")]
        [Required(ErrorMessage = "Tecnico é obrigatório")]
        public String TecnicoNome { get; set; }

        [Display(Name = "Cliente", Description = "Nome do cliente que agendou o atendimento.")]
        [Required(ErrorMessage = "Cliente é obrigatório")]
        public String ClienteNome { get; set; }

        [Display(Name = "Hora", Description = "Horario do atendimento.")]
        public DateTime Hora { get; set; }

        [Display(Name = "Data", Description = "Dia do atendimento.")]
        public DateTime Data { get; set; }

        [Display(Name = "Local", Description = "Local do atendimento.")]
        public String Local { get; set; }

        [Display(Name = "Serviço", Description = "Serviço a ser realizado.")]
        public String Servico { get; set; }

        [Display(Name = "Observação", Description = "Observação sobre o atendimento.")]
        public String Observacao { get; set; }


        public Agenda()
        {

        }

    }
}
