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

            sql.Append("INSERT INTO Tecnico (Nome, Telefone, Endereco, Adimicao)");
            sql.Append("VALUES(@Nome, @Telefone, @Endereco, @Adimicao)");

            cmd.Parameters.AddWithValue("@Nome", pTecnico.Nome);
            cmd.Parameters.AddWithValue("@Telefone", pTecnico.Telefone);
            cmd.Parameters.AddWithValue("@Endereco", pTecnico.Endereco);
            cmd.Parameters.AddWithValue("@Adimicao", pTecnico.Adimicao);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Tecnico pTecnico)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Tecnico SET Nome=@Nome, Telefone=@Telefone, Endereco=@Endereco, Adimicao=@Adimicao");
            sql.Append("WHERE IdTecnico=" + pTecnico.IdTecnico);

            cmd.Parameters.AddWithValue("@Nome", pTecnico.Nome);
            cmd.Parameters.AddWithValue("@Telefone", pTecnico.Telefone);
            cmd.Parameters.AddWithValue("@Endereco", pTecnico.Endereco);
            cmd.Parameters.AddWithValue("@Adimicao", pTecnico.Adimicao);

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
                tecnico.IdTecnico = Convert.ToInt32(dr["IdUsuario"]);
                tecnico.Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"];
                tecnico.Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (String)dr["Telefone"];
                tecnico.Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (String)dr["Endereco"];
                tecnico.Adimicao = (DateTime)dr["Adimicao"];
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
                        IdTecnico = Convert.ToInt32(dr["IdUsuario"]),
                        Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"],
                        Telefone = dr.IsDBNull(dr.GetOrdinal("Senha")) ? "" : (String)dr["Senha"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (String)dr["Endereco"],
                        Adimicao = (DateTime)dr["Adimicao"]
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

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                tecnico.Add(
                    new Tecnico
                    {
                        IdTecnico = (int)dr["IdTecnico"],
                        Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"],
                        Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (String)dr["Telefone"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (String)dr["Endereco"],
                        Adimicao = (DateTime)dr["Adimicao"]                       
                    });
            }

            dr.Close();

            return tecnico;
        }

    }
}
