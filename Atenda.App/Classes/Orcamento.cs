using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes
{
    [Table(Name="Orcamento")]
    public class Orcamento
    {

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdOrcamento { get; set; }

        [Column(CanBeNull = false)]
        public string Servico { get; set; }

        [Column(CanBeNull = false)]
        public decimal ValorServico { get; set; }

        [Column(IsPrimaryKey = false)]
        public int IdProduto { get; set; }

        [Column(CanBeNull = true)]
        public string NomeProduto { get; set; }

        [Column(CanBeNull = true)]
        public decimal ValorProduto { get; set; }

        [Column(CanBeNull = true)]
        public decimal ValorTotal { get; set; }

    }
}
