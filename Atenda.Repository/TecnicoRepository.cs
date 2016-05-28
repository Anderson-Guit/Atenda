using System;
using Atenda.Conn;
using Atenda.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.Repository
{
    public class TecnicoRepository
    {

        public void Create(Tecnico pTecnico)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Tecnico (Nome, Telefone, Endereco, Admissao, Senha)");
            sql.Append("VALUES(@Nome, @Telefone, @Endereco, @Admissao, @Senha)");

            cmd.Parameters.AddWithValue("@Nome", pTecnico.Nome);

            if (!string.IsNullOrEmpty(pTecnico.Telefone))
                cmd.Parameters.Add("@Telefone", SqlString.Null).Value = pTecnico.Telefone;
            else
                cmd.Parameters.Add("@Telefone", SqlString.Null);

            if (!string.IsNullOrEmpty(pTecnico.Endereco))
                cmd.Parameters.Add("@Endereco", SqlString.Null).Value = pTecnico.Endereco;
            else
                cmd.Parameters.Add("@Endereco", SqlString.Null);

            if (pTecnico.Admissao != null)
                cmd.Parameters.Add("@Admissao", SqlString.Null).Value = pTecnico.Admissao;
            else
                cmd.Parameters.Add("@Admissao", SqlString.Null);

            cmd.Parameters.AddWithValue("@Senha", pTecnico.Senha);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Tecnico pTecnico)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Tecnico SET Nome=@Nome, Telefone=@Telefone, Endereco=@Endereco, Admissao=@Admissao, Senha=@Senha ");
            sql.Append("WHERE IdTecnico=" + pTecnico.IdTecnico);

            cmd.Parameters.AddWithValue("@Nome", pTecnico.Nome);

            if (!string.IsNullOrEmpty(pTecnico.Telefone))
                cmd.Parameters.Add("@Telefone", SqlString.Null).Value = pTecnico.Telefone;
            else
                cmd.Parameters.Add("@Telefone", SqlString.Null);

            if (!string.IsNullOrEmpty(pTecnico.Endereco))
                cmd.Parameters.Add("@Endereco", SqlString.Null).Value = pTecnico.Endereco;
            else
                cmd.Parameters.Add("@Endereco", SqlString.Null);

            if (pTecnico.Admissao != null)
                cmd.Parameters.Add("@Admissao", SqlString.Null).Value = pTecnico.Admissao;
            else
                cmd.Parameters.Add("@Admissao", SqlString.Null);

            cmd.Parameters.AddWithValue("@Senha", pTecnico.Senha);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("DELETE FROM Tecnico ");
            sql.Append("WHERE IdTecnico=" + pId);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public static Tecnico GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Tecnico tecnico = new Tecnico();

            sql.Append("SELECT * ");
            sql.Append("FROM Tecnico ");
            sql.Append("WHERE IdTecnico=" + pId);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                tecnico.IdTecnico = (int)dr["IdTecnico"];
                tecnico.Nome = (string)dr["Nome"];
                tecnico.Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (string)dr["Telefone"];
                tecnico.Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (string)dr["Endereco"];
                tecnico.Admissao = dr.IsDBNull(dr.GetOrdinal("Admissao")) ? null : (DateTime?)dr["Admissao"];
                tecnico.Senha = (string)dr["Senha"];
            }
            return tecnico;
        }

        public static List<Tecnico> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Tecnico> tecnico = new List<Tecnico>();

            sql.Append("SELECT * ");
            sql.Append("FROM Tecnico ");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                tecnico.Add(
                    new Tecnico
                    {
                        IdTecnico = (int)dr["IdTecnico"],
                        Nome = (string)dr["Nome"],
                        Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (string)dr["Telefone"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (string)dr["Endereco"],
                        Admissao = dr.IsDBNull(dr.GetOrdinal("Admissao")) ? null : (DateTime?)dr["Admissao"],
                        Senha = (string)dr["Senha"]
                    });
            }
            return tecnico;
        }

        public static List<Tecnico> GetName(String pNome)
        {
            StringBuilder sql = new StringBuilder();
            List<Tecnico> tecnicos = new List<Tecnico>();

            sql.Append("SELECT * ");
            sql.Append("FROM Tecnico ");
            sql.Append("WHERE Nome like '%" + pNome.Trim() + "%'");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                tecnicos.Add(
                    new Tecnico
                    {
                        IdTecnico = (int)dr["IdTecnico"],
                        Nome = (string)dr["Nome"],
                        Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (string)dr["Telefone"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (string)dr["Endereco"],
                        Admissao = dr.IsDBNull(dr.GetOrdinal("Admissao")) ? null : (DateTime?)dr["Admissao"],
                        Senha = (string)dr["Senha"]
                    });
            }

            dr.Close();

            return tecnicos;
        }
        public static Tecnico CheckUser(Login pLogin)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                Tecnico tecnico = new Tecnico();

                sql.Append("SELECT * ");
                sql.Append("FROM Tecnico ");
                sql.Append("WHERE Nome='" + pLogin.Nome + "' and Senha='" + pLogin.Senha + "'");

                SqlDataReader dr = SqlConn.Get(sql.ToString());

                while (dr.Read())
                {
                    tecnico.IdTecnico = (int)dr["IdTecnico"];
                    tecnico.Nome = (string)dr["Nome"];
                    tecnico.Senha = (string)dr["Senha"];
                }
                return tecnico;
            }
            catch (Exception)
            {

                return null;
            }

        }
    }
}
