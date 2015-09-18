using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.WP.Model
{
    [Table(Name = "Usuario")]
    public class Usuario
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdUsuario { get; set; }
        [Column]
        public String Nome { get; set; }
        [Column]
        public String Senha { get; set; }
        [Column]
        public Boolean Adm { get; set; }

    }
}
