using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes.Dbs
{
    class AgendaDB
    {
        private static dataBase getDataBase()
        {
            dataBase db = new dataBase();
            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }
            return db;
        }

        public static void Create(Agenda pAgenda)
        {
            dataBase db = getDataBase();

            db.Agenda.InsertOnSubmit(pAgenda);

            db.SubmitChanges();
        }

        public static void Delete(Agenda pAgenda)
        {
            dataBase db = getDataBase();
            var query = from a in db.Agenda
                        where a.IdAgenda == pAgenda.IdAgenda
                        select a;

            db.Agenda.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void Update(Agenda pAgenda)
        {
            dataBase db = getDataBase();

            Agenda agenda = (from a in db.Agenda
                              where a.IdAgenda == pAgenda.IdAgenda
                               select a).First();

            //trata os campos que serão alterados
            agenda.IdTecnico = pAgenda.IdTecnico;
            agenda.Data = pAgenda.Data;
            agenda.Hora = pAgenda.Hora;
            agenda.Local = pAgenda.Local;
            agenda.Status = pAgenda.Status;

            db.SubmitChanges();
        }

        public static Agenda GetOne(int pId)
        {
            dataBase db = getDataBase();
            var query = from a in db.Agenda
                        where a.IdAgenda == pId
                        select a;



            Agenda agenda = query.ToList()[0];
            return agenda;
        }

        public static List<Agenda> GetAll()
        {
            dataBase db = getDataBase();
            var query = from a in db.Agenda
                        select a;

            List<Agenda> agendas = new List<Agenda>(query.AsEnumerable());
            return agendas;
        }

        public static List<Agenda> GetAllByTecnico(string TecnicoNome)
        {
            dataBase db = getDataBase();
            var query = from a in db.Agenda
                        where a.TecnicoNome == TecnicoNome
                        select a;

            List<Agenda> agendas = new List<Agenda>(query.AsEnumerable());
            return agendas;
        }

    }
}
