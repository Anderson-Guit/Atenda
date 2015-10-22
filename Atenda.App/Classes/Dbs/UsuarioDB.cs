using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace Atenda.App.Classes
{
    class UsuarioDB
    {
        //cria um objeto database. Se for necessário cria o banco de dados
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

        //consulta carros por tipo
        public static List<Usuario> GetAll()
        {
            dataBase db = getDataBase();
            var query = from u in db.Usuario
                        select u;

            List<Usuario> usuarios = new List<Usuario>(query.AsEnumerable());
            return usuarios;
        }

        public static Usuario GetOne(int pId)
        {
            dataBase db = getDataBase();
            var query = from u in db.Usuario
                        where u.IdUsuario == pId
                        select u;



            Usuario usuario = query.ToList()[0];
            return usuario;
        }

    }
}
