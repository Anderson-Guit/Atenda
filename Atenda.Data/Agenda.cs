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
        [DataType("##:##")]
        public DateTime Hora { get; set; }

        [Display(Name = "Data", Description = "Dia do atendimento.")]
        [DataType("##/##/####")]
        public DateTime Data { get; set; }

        [Display(Name = "Local", Description = "Local do atendimento.")]
        public String Local { get; set; }

        [Display(Name = "Serviço", Description = "Serviço a ser realizado.")]
        public String Servico { get; set; }

        [Display(Name = "Observações", Description = "Observações sobre o atendimento.")]
        public String Observacoes { get; set; }

        [Display(Name = "Status", Description = "Status do atendimento.")]
        public Boolean Status { get; set; }
        
        public Agenda()
        {

        }

    }
}
