using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        

        public static void Refresh(Tecnico pTecnico)
        {
            dataBase db = getDataBase();

            db.Tecnico.InsertOnSubmit(pTecnico);

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

        public static Tecnico GetCheck(string Nome, string Senha)
        {
            dataBase db = getDataBase();
            var query = from t in db.Tecnico
                        where t.Nome == Nome && t.Senha == Senha
                        select t;



            Tecnico tecnico = query.ToList()[0];
            return tecnico;
        }

    }
}
