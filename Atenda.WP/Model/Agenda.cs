using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.WP.Model
{
    [Table(Name = "OrdemServico")]
    public class Agenda
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdAgenda { get; set; }
        [Column]
        public int IdTecnico { get; set; }
        [Column]
        public int IdCliente { get; set; }
        [Column]
        public String TecnicoNome { get; set; }
        [Column]
        public String ClienteNome { get; set; }
        [Column]
        public DateTime Hora { get; set; }
        [Column]
        public DateTime Data { get; set; }
        [Column]
        public String Local { get; set; }
        [Column]
        public String Servico { get; set; }
        [Column]
        public String Observacao { get; set; }

    }
}
