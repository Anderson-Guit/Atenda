using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Atenda.App.Classes
{
    class dataBase : DataContext
    {
        //string de conexão, contem o nome do arquivo que é o BD
        public static string DBConnectionString = "Data Source ='isostore:Atenda.sdf'";

        //construtor da classe passando a string de conexão
        public dataBase()
            : base(DBConnectionString)
        { }

        public Table<Cliente> Cliente
        {
            get
            {
                return this.GetTable<Cliente>();
            }
        }

        public Table<Tecnico> Tecnico
        {
            get
            {
                return this.GetTable<Tecnico>();
            }
        }

        public Table<Produto> Produto
        {
            get
            {
                return this.GetTable<Produto>();
            }
        }

        public Table<Orcamento> Orcamento
        {
            get
            {
                return this.GetTable<Orcamento>();
            }
        }

        public Table<Agenda> Agenda
                {
                    get
                    {
                        return this.GetTable<Agenda>();
                    }
                }

        public Table<OrdemServico> OrdemServico
        {
            get
            {
                return this.GetTable<OrdemServico>();
            }
        }

    }
}
