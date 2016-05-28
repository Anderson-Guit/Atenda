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
        [Key]
        public int IdAgenda { get; set; }

        [Key]
        [Required]
        public int IdTecnico { get; set; }

        [Key]
        [Required]
        public int IdCliente { get; set; }
        
        [Display(Name = "Tecnico", Description = "Nome do tecnico que fará o atendimento.")]
        public string TecnicoNome { get; set; }

        [Display(Name = "Cliente", Description = "Nome do cliente que agendou o atendimento.")]
        public string ClienteNome { get; set; }

        
        [Display(Name = "Hora", Description = "Horario do atendimento.")]
        [DataType(DataType.Time, ErrorMessage = "Hora em formato inválido")]
        public DateTime? Hora { get; set; }

        [Display(Name = "Data", Description = "Dia do atendimento.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Data { get; set; }

        [Display(Name = "Local", Description = "Local do atendimento.")]
        public string Local { get; set; }

        [Display(Name = "Serviço", Description = "Serviço a ser realizado.")]
        [DataType(DataType.MultilineText)]
        public string Servico { get; set; }

        [Display(Name = "Observações", Description = "Observações sobre o atendimento.")]
        [DataType(DataType.MultilineText)]
        public string Observacoes { get; set; }

        [Display(Name = "Status", Description = "Status do atendimento.")]
        [Required]
        public string Status { get; set; }
        
        public Agenda()
        {

        }

        public List<Agenda> ListStatus()
        {
            return new List<Agenda>
                {
                    new Agenda {Status = "Aguardando"},
                    new Agenda {Status = "Em Execução"},
                    new Agenda {Status = "Realizado"},
                    new Agenda {Status = "Cancelado"},
                };
        }

        public string Search { get; set; }
        public List<Agenda> ListSearch()
        {

            return new List<Agenda>
                {
                    new Agenda {Search = "Status"},
                    new Agenda {Search = "Tecnico"},
                    new Agenda {Search = "Cliente"},

                };
        }
    }
}
