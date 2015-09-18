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
    public class OrdemServico
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdOS { get; set; }
        [Column]
        public int IdCliente { get; set; }
        [Column]
        public String ClienteNome { get; set; }
        [Column]
        public int IdTecnico { get; set; }
        [Column]
        public String TecnicoNome { get; set; }
        [Column]
        public String Equipamento { get; set; }
        [Column]
        public String Marca { get; set; }
        [Column]
        public String Modelo { get; set; }
        [Column]
        public String NumeroSerie { get; set; }
        [Column]
        public String Defeito { get; set; }
        [Column]
        public String Servico { get; set; }
        [Column]
        public String Local { get; set; }
        [Column]
        public String Observacoes { get; set; }
        [Column]
        public String Status { get; set; }

    }
}
