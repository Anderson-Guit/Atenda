using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes
{
    [Table(Name="Ordemservico")]
    public class OrdemServico
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false)]
        public int IdOS { get; set; }

        [Column(CanBeNull = false)]
        public int IdTecnico { get; set; }

        [Column(CanBeNull = true)]
        public string TecnicoNome { get; set; }

        [Column(CanBeNull = false)]
        public int IdCliente { get; set; }

        [Column(CanBeNull = true)]
        public string ClienteNome { get; set; }

        [Column(CanBeNull = false)]
        public string Equipamento { get; set; }

        [Column(CanBeNull = true)]
        public string Marca { get; set; }

        [Column(CanBeNull = true)]
        public string Modelo { get; set; }

        [Column(CanBeNull = true)]
        public string NumeroSerie { get; set; }

        [Column(CanBeNull = false)]
        public string Defeito { get; set; }

        [Column(CanBeNull = false)]
        public string Servico { get; set; }

        [Column(CanBeNull = false)]
        public DateTime DataEntrada { get; set; }

        [Column(CanBeNull = true)]
        public DateTime? DataSaida { get; set; }

        [Column(CanBeNull = true)]
        public string Local { get; set; }

        [Column(CanBeNull = true)]
        public string Observacoes { get; set; }

        [Column(CanBeNull = true)]
        public decimal? Custo { get; set; }

        [Column(CanBeNull = true)]
        public int IdProduto { get; set; }

        [Column(CanBeNull = true)]
        public string ProdutoNome { get; set; }
        
        [Column(CanBeNull = false)]
        public string Status { get; set; }
    }
}
