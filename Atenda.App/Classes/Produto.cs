using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes
{
    [Table(Name="Produto")]
    public class Produto
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdProduto { get; set; }

        [Column(CanBeNull = false)]
        public string Nome { get; set; }

        [Column(CanBeNull = true)]
        public string Descricao { get; set; }

        [Column(CanBeNull = false)]
        public decimal Valor { get; set; }

        [Column(CanBeNull = true)]
        public int QntdEstoque { get; set; }

    }
}
