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
    public class Produto
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdProduto { get; set; }
        [Column]
        public String Nome { get; set; }
        [Column]
        public String Descricao { get; set; }
        [Column]
        public Decimal Valor { get; set; }
        [Column]
        public int QntdEstoque { get; set; }

    }
}
