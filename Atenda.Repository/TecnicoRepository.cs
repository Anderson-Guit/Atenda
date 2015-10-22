using System;
using Atenda.Conn;
using Atenda.Data;
using System.Data.SqlClient;
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

            sql.Append("INSERT INTO Tecnico (Nome, Telefone, Endereco, Admissao)");
            sql.Append("VALUES(@Nome, @Telefone, @Endereco, @Admissao)");

            cmd.Parameters.AddWithValue("@Nome", pTecnico.Nome);
            cmd.Parameters.AddWithValue("@Telefone", pTecnico.Telefone);
            cmd.Parameters.AddWithValue("@Endereco", pTecnico.Endereco);
            cmd.Parameters.AddWithValue("@Admissao", pTecnico.Admissao);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Tecnico pTecnico)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Tecnico SET Nome=@Nome, Telefone=@Telefone, Endereco=@Endereco, Admissao=@Admissao ");
            sql.Append("WHERE IdTecnico=" + pTecnico.IdTecnico);

            cmd.Parameters.AddWithValue("@Nome", pTecnico.Nome);
            cmd.Parameters.AddWithValue("@Telefone", pTecnico.Telefone);
            cmd.Parameters.AddWithValue("@Endereco", pTecnico.Endereco);
            cmd.Parameters.AddWithValue("@Admissao", pTecnico.Admissao);

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
                tecnico.Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (string)dr["Nome"];
                tecnico.Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (string)dr["Telefone"];
                tecnico.Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (string)dr["Endereco"];
                tecnico.Admissao = (DateTime)dr["Admissao"];
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
                        Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (string)dr["Nome"],
                        Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (string)dr["Telefone"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (string)dr["Endereco"],
                        Admissao = (DateTime)dr["Admissao"]
                    });
            }
            return tecnico;
        }

        public static List<Tecnico> GetBySearch(String Nome)
        {
            StringBuilder sql = new StringBuilder();
            List<Tecnico> tecnico = new List<Tecnico>();

            sql.Append("SELECT * ");
            sql.Append("FROM Tecnico ");
            sql.Append("WHERE Nome =" + Nome);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                tecnico.Add(
                    new Tecnico
                    {
                        IdTecnico = (int)dr["IdTecnico"],
                        Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (string)dr["Nome"],
                        Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (string)dr["Telefone"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (string)dr["Endereco"],
                        Admissao = (DateTime)dr["Admissao"]                       
                    });
            }

            dr.Close();

            return tecnico;
        }

    }
}
