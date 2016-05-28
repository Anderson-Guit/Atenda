using Atenda.App.Classes.Dbs;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes
{
    [Table(Name = "Tecnico")]
    public class Tecnico
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = false, CanBeNull = true)]
        public int IdTecnico { get; set; }

        [Column(CanBeNull = false)]
        public string Nome { get; set; }

        [Column(CanBeNull = true)]
        public string Telefone { get; set; }

        [Column(CanBeNull = true)]
        public string Endereco { get; set; }

        //[Column(CanBeNull = true)]
        //public string Admissao { get; set; }

        [Column(CanBeNull = false)]
        public string Senha { get; set; }

    }
}
