using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Data.Linq.Mapping;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.WP
{
    class AppDataBase : DataContext
    {
        public AppDataBase(string conectionString)
            : base(conectionString)
        { }
        public static string ConectionString
        {
            get
            {
                return "isostore:/Atenda.sdf";
            }
        }
        public Table<Usuario> Usuario;
        public Table<Tecnico> Tecnico;
        public Table<Cliente> Cliente;
        public Table<OrdemServico> OrdemServico;
        public Table<Agenda> Agenda;
        public Table<Produto> Produto;
    }
}
