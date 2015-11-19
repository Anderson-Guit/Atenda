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
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int IdTecnico { get; set; }

        [Column(CanBeNull = false)]
        public string Nome { get; set; }

        [Column(CanBeNull = false)]
        public string Telefone { get; set; }

        [Column(CanBeNull = true)]
        public string Endereco { get; set; }

        [Column(CanBeNull = false)]
        public DateTime Admissao { get; set; }

        public Boolean CheckUser(string pNome, string pSenha)
        {
            string Nome = "admin";
            string Senha = "admin";

            if (pNome == Nome && pSenha == Senha)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
