using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.WP.Model
{
    [Table(Name = "Tecnico")]
    public class Tecnico
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdTecnico { get; set; }
        [Column]
        public String Nome { get; set; }
        [Column]
        public String Telefone { get; set; }
        [Column]
        public String Endereco { get; set; }
        [Column]
        public DateTime Adimicao { get; set; }

    }
}
