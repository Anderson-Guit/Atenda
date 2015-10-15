using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.Data
{
    public class OrdemServico
    {
        [Key]
        public int IdOS { get; set; }

        [Key]
        public int IdCliente { get; set; }

        [Display(Name = "Cliente", Description = "Nome do Cliente.")]
        public String ClienteNome { get; set; }

        [Key]
        public int IdTecnico { get; set; }

        [Display(Name = "Tecnico", Description = "Nome do Tecnico.")]
        public String TecnicoNome { get; set; }

        [Display(Name = "Equipamento", Description = "Tipo do Equipamento.")]
        public String Equipamento { get; set; }

        [Display(Name = "Marca", Description = "Marca do Equipamento.")]
        [Required(ErrorMessage = "Marca é obrigatório")]
        public String Marca { get; set; }

        [Display(Name = "Modelo", Description = "Informe o Modelo do Equipamento.")]
        [Required(ErrorMessage = "Modelo é obrigatório")]
        public String Modelo { get; set; }

        [Display(Name = "Número de Série", Description = "Informe o Número de Série do Equipamento.")]
        public String NumeroSerie { get; set; }

        [Display(Name = "Defeito", Description = "Informe o Defeito do Equipamento.")]
        [Required(ErrorMessage = "Defeito é obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage =
           "O Defeito deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public String Defeito { get; set; }

        [Display(Name = "Serviço", Description = "Informe o Serviço do Equipamento.")]
        [Required(ErrorMessage = "Serviço é obrigatório")]
        public String Servico { get; set; }

        [Display(Name = "Data", Description = "Informe a data do serviço.")]
        [Required(ErrorMessage = "Data é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [Display(Name = "Local", Description = "Informe o Local do Equipamento.")]
        [Required(ErrorMessage = "Local é obrigatório")]
        public String Local { get; set; }

        [Display(Name = "Observações", Description = "Informe as Observações do Equipamento.")]
        [StringLength(200, MinimumLength = 5, ErrorMessage =
           "Se necessário as observações devem ter no mínimo 5 e no máximo 200 caracteres.")]
        public String Observacoes { get; set; }

        [Display(Name = "Custo", Description = "Valor do serviço.")]
        [DisplayFormat(DataFormatString = "{0,n2}")]
        public Decimal Custo { get; set; }

        [Display(Name = "Status", Description = "Informe o Status do Equipamento.")]
        [Required(ErrorMessage = "Status é obrigatório")]
        public String Status { get; set; }

        public OrdemServico()
        {

        }

    }

}
