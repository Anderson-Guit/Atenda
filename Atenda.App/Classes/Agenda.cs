using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes
{
    [Table(Name="Agenda")]
    public class Agenda
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdAgenda { get; set; }

        [Column(CanBeNull = false)]
        public int IdTecnico { get; set; }

        [Column(CanBeNull = true)]
        public string TecnicoNome { get; set; }

        [Column(CanBeNull = false)]
        public int IdCliente { get; set; }

        [Column(CanBeNull = true)]
        public string ClienteNome { get; set; }

        [Column(CanBeNull = true)]
        public DateTime Hora { get; set; }

        [Column(CanBeNull = false)]
        public DateTime Data { get; set; }

        [Column(CanBeNull = true)]
        public string Servicos { get; set; }

        [Column(CanBeNull = true)]
        public string Local { get; set; }

        [Column(CanBeNull = true)]
        public string Observacoes { get; set; }

        [Column(CanBeNull = true)]
        public string Status { get; set; }
    }
}
