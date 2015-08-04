using System;
using Atenda.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.Repository
{
    public class UsuarioRepository
    {

        public static Usuario GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Usuario usuario = new Usuario();

            sql.Append("SELECT * ");
            sql.Append("FROM Usuario ");
            sql.Append("WHERE IdUsuario=" + pId);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                usuario.IdUsuario = (int)(dr["IdUsuario"]);
                usuario.Nome = (String)dr["Nome"];
                usuario.Senha = (String)dr["Senha"];
                usuario.Adm = Convert.ToBoolean(dr["Adm"]);
            }
            return usuario;
        }

        public static Usuario CheckUser(String Nome, String Senha)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                Usuario usuario = new Usuario();

                sql.Append("SELECT * ");
                sql.Append("FROM Usuario ");
                sql.Append("WHERE Nome='" + Nome + "' and Senha='" + Senha + "'");

                SqlDataReader dr = SqlConn.Get(sql.ToString());

                while (dr.Read())
                {
                    usuario.IdUsuario = (int)dr["IdUsuario"];
                    usuario.Nome = (string)dr["Nome"];
                    usuario.Senha = (string)dr["Senha"];
                }
                return usuario;
            }
            catch (Exception)
            {
                
                return null;
            }
            
        }

    }
}
