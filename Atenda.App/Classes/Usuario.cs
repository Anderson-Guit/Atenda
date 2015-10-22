using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes
{
     [Table(Name = "Usuario")]
     public class Usuario
     {
          [Column(IsPrimaryKey = true, IsDbGenerated = true)]
          public int IdUsuario { get; set; }

          [Column(CanBeNull = false)]
          public string Nome { get; set; }

          [Column(CanBeNull = false)]
          public string Senha { get; set; }

      }
}
