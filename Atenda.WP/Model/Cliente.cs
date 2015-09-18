using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.WP.Model
{
    [Table(Name = "Cliente")]
    class Cliente
    {
  
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdCliente { get; set; }
        [Column]
        public String Nome { get; set; }
        [Column]
        public String Telefone { get; set; }
        [Column]
        public String Endereco { get; set; }
        [Column]
        public String Bairro { get; set; }
        [Column]
        public String Cidade { get; set; }
        [Column]
        public String Estado { get; set; }
        [Column]
        public String Pais { get; set; }
        [Column]
        public String CPF { get; set; }

    }
}
