using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes.Dbs
{
    class TecnicoDB
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

        public static void Create(Tecnico pTecnico)
        {
            dataBase db = getDataBase();

            db.Tecnico.InsertOnSubmit(pTecnico);

            db.SubmitChanges();
        }

        public static void Delete(Tecnico pTecnico)
        {
            dataBase db = getDataBase();
            var query = from t in db.Tecnico
                        where t.IdTecnico == pTecnico.IdTecnico
                        select t;

            db.Tecnico.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void Update(Tecnico pTecnico)
        {
            dataBase db = getDataBase();

            Tecnico tecnico = (from t in db.Tecnico
                               where t.IdTecnico == pTecnico.IdTecnico
                               select t).First();

            //trata os campos que serão alterados
            tecnico.Nome = pTecnico.Nome;
            tecnico.Telefone = pTecnico.Telefone;
            tecnico.Endereco = pTecnico.Endereco;
            tecnico.Admissao = pTecnico.Admissao;

            db.SubmitChanges();
        }

        public static Tecnico GetOne(int pId)
        {
            dataBase db = getDataBase();
            var query = from t in db.Tecnico
                        where t.IdTecnico == pId
                        select t;



            Tecnico tecnico = query.ToList()[0];
            return tecnico;
        }

        public static List<Tecnico> GetAll()
        {
            dataBase db = getDataBase();
            var query = from c in db.Tecnico
                        select c;

            List<Tecnico> tecnicos = new List<Tecnico>(query.AsEnumerable());
            return tecnicos;
        }

        public static List<Tecnico> GetNome(string nomeSearch)
        {
            dataBase db = getDataBase();
            var query = from t in db.Tecnico
                        where (t.Nome.Contains(nomeSearch))
                        select t;


            List<Tecnico> tecnicos = new List<Tecnico>(query.AsEnumerable());
            return tecnicos;
        }
    }
}
