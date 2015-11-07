using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes.Dbs
{
    class OrdemServicoDB
    {
        private static dataBase getDataBase()
        {
            dataBase db = new dataBase();
            if (!db.DatabaseExists())
            {
                //cria o banco
                db.CreateDatabase();
            }
            return db;
        }

        // salva um carro
        public static void Create(OrdemServico pOS)
        {
            dataBase db = getDataBase();

            db.OrdemServico.InsertOnSubmit(pOS);

            db.SubmitChanges();
        }

        // salva um carro
        public static void Delete(OrdemServico pOS)
        {
            dataBase db = getDataBase();
            var query = from c in db.Cliente
                        where c.IdCliente == pOS.IdCliente
                        select c;

            db.Cliente.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void Update(OrdemServico pOS)
        {
            dataBase db = getDataBase();

            OrdemServico os = (from oso in db.OrdemServico
                               where oso.IdOS == pOS.IdOS
                               select oso).First(); 

            //trata os campos que serão alterados
            os.IdTecnico = pOS.IdTecnico;
            os.Equipamento = pOS.Equipamento;
            os.Marca = pOS.Marca;
            os.Modelo = pOS.Modelo;
            os.NumeroSerie = pOS.NumeroSerie;
            os.Defeito = pOS.Defeito;
            os.Servico = pOS.Servico;
            os.DataEntrada = pOS.DataEntrada;
            os.DataSaida = pOS.DataSaida;
            os.Local = pOS.Local;
            os.Observacoes = pOS.Observacoes;
            os.Status = pOS.Status;

            db.SubmitChanges();
        }

        public static OrdemServico GetOne(int pId)
        {
            dataBase db = getDataBase();
            var query = from oso in db.OrdemServico
                        where oso.IdOS == pId
                        select oso;
                        
                        

            OrdemServico os = query.ToList()[0];
            return os;
        }

        public static List<OrdemServico> GetAll()
        {
            dataBase db = getDataBase();
            var query = from oso in db.OrdemServico
                        select oso;

            List<OrdemServico> os = new List<OrdemServico>(query.AsEnumerable());
            return os;
        }

    }
}
