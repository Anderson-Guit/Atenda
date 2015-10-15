using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atenda.Data;
using Atenda.Conn;
using System.Data.SqlClient;

namespace Atenda.Repository
{
    public class OrdemServicoRepository
    {

        public void Create(OrdemServico pOS)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO OrdemServico (Cliente_IdCliente, Tecnico_IdTecnico, Equipamento, Marca, Modelo, NumeroSerie, Defeito, Servico, Local_, Observacoes, Custo, Status_)");
            sql.Append("VALUES(@Cliente, @Tecnico, @Equipamento, @Marca, @Modelo, @NumeroSerie, @Defeito, @Servico, @Local, @Observacoes, @Custo, @Status)");

            cmd.Parameters.AddWithValue("@Cliente", (pOS.IdCliente));
            cmd.Parameters.AddWithValue("@Tecnico", (pOS.IdTecnico));
            cmd.Parameters.AddWithValue("@Equipamento", (pOS.Equipamento));
            cmd.Parameters.AddWithValue("@Marca", pOS.Marca);
            cmd.Parameters.AddWithValue("@Modelo", pOS.Modelo);
            cmd.Parameters.AddWithValue("@NumeroSerie", pOS.NumeroSerie);
            cmd.Parameters.AddWithValue("@Defeito", pOS.Defeito);
            cmd.Parameters.AddWithValue("@Servico", pOS.Servico);
            cmd.Parameters.AddWithValue("@Local", pOS.Local);
            cmd.Parameters.AddWithValue("@Observacoes", pOS.Observacoes);
            cmd.Parameters.AddWithValue("@Custo", pOS.Custo);
            cmd.Parameters.AddWithValue("@Status", pOS.Status);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(OrdemServico pOS)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE OrdemServico SET Equipamento=@Equipamento, Marca=@Marca, Modelo=@Modelo, NumeroSerie=@NumeroSerie, Defeito=@Defeito, Servico=@Servico, Local_=@Local, Observacoes=@Observacoes, Custo=@Custo, Status_=@Status");
            sql.Append(" WHERE IdOS=" + pOS.IdOS);

            cmd.Parameters.AddWithValue("@Equipamento", (pOS.Equipamento));
            cmd.Parameters.AddWithValue("@Marca", pOS.Marca);
            cmd.Parameters.AddWithValue("@Modelo", pOS.Modelo);
            cmd.Parameters.AddWithValue("@NumeroSerie", pOS.NumeroSerie);
            cmd.Parameters.AddWithValue("@Defeito", pOS.Defeito);
            cmd.Parameters.AddWithValue("@Servico", pOS.Servico);
            cmd.Parameters.AddWithValue("@Local", pOS.Local);
            cmd.Parameters.AddWithValue("@Observacoes", pOS.Observacoes);
            cmd.Parameters.AddWithValue("@Custo", pOS.Custo);
            cmd.Parameters.AddWithValue("@Status", pOS.Status);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("DELETE FROM OrdemServico ");
            sql.Append("WHERE IdOS=" + pId);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public static OrdemServico GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            OrdemServico os = new OrdemServico();

            sql.Append("select os.IdOS, os.Cliente, cl.Nome, os.Tecnico, tc.Nome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.Local_, os.Observacoes, os.Custo, os.Status_");
            sql.Append(" from OrdemServico as os");
            sql.Append(" inner join Cliente as cl on cl.IdCliente=os.Cliente");
            sql.Append(" inner join Tecnico as tc on tc.IdTecnico=os.Tecnico");
            sql.Append(" where os.IdOS = " + pId );

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.IdOS = Convert.ToInt32(dr["IdOS"]);
                os.IdCliente = Convert.ToInt32(dr["Cliente_IdCliente"]);
                os.ClienteNome = dr.IsDBNull(dr.GetOrdinal("Cliente")) ? "" : (String)dr["Cliente"];
                os.IdTecnico = Convert.ToInt32(dr["Tecnico_IdTecnico"]);
                os.TecnicoNome = dr.IsDBNull(dr.GetOrdinal("Tecnico")) ? "" : (String)dr["Tecnico"];
                os.Equipamento = dr.IsDBNull(dr.GetOrdinal("Equipamento")) ? "" : (String)dr["Equipamento"];
                os.Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (String)dr["Marca"];
                os.Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (String)dr["Modelo"];
                os.NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (String)dr["NumeroSerie"];
                os.Defeito = dr.IsDBNull(dr.GetOrdinal("Defeito")) ? "" : (String)dr["Defeito"];
                os.Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (String)dr["Servico"];
                os.Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (String)dr["Local_"];
                os.Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (String)dr["Observacoes"];
                os.Custo = (Decimal)dr["Custo"];
                os.Status = dr.IsDBNull(dr.GetOrdinal("Status_")) ? "" : (String)dr["Status_"];
            }
            return os;
        }

        public static OrdemServico GetSearchByCliente(String pTecnicoNome)
        {
            StringBuilder sql = new StringBuilder();
            OrdemServico os = new OrdemServico();

            sql.Append("select os.IdOS, os.Cliente, cl.Nome, os.Tecnico, tc.Nome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.Local_, os.Observacoes, os.Custo, os.Status_");
            sql.Append(" from OrdemServico as os");
            sql.Append(" inner join Cliente as cl on cl.IdCliente=os.Cliente");
            sql.Append(" inner join Tecnico as tc on tc.IdTecnico=os.Tecnico");
            sql.Append(" where os.Cliente = cl.IdCliente");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.IdOS = Convert.ToInt32(dr["IdOS"]);
                os.IdCliente = Convert.ToInt32(dr["Cliente_IdCliente"]);
                os.ClienteNome = dr.IsDBNull(dr.GetOrdinal("Cliente")) ? "" : (String)dr["Cliente"];
                os.IdTecnico = Convert.ToInt32(dr["Tecnico_IdTecnico"]);
                os.TecnicoNome = dr.IsDBNull(dr.GetOrdinal("Tecnico")) ? "" : (String)dr["Tecnico"];
                os.Equipamento = dr.IsDBNull(dr.GetOrdinal("Equipamento")) ? "" : (String)dr["Equipamento"];
                os.Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (String)dr["Marca"];
                os.Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (String)dr["Modelo"];
                os.NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (String)dr["NumeroSerie"];
                os.Defeito = dr.IsDBNull(dr.GetOrdinal("Defeito")) ? "" : (String)dr["Defeito"];
                os.Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (String)dr["Servico"];
                os.Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (String)dr["Local_"];
                os.Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (String)dr["Observacoes"];
                os.Custo = (Decimal)dr["Custo"];
                os.Status = dr.IsDBNull(dr.GetOrdinal("Status_")) ? "" : (String)dr["Status_"];
            }
            return os;
        }

        public static OrdemServico GetSearchByTecnico(String pTecnicoNome)
        {
            StringBuilder sql = new StringBuilder();
            OrdemServico os = new OrdemServico();

            sql.Append("select os.IdOS, os.Cliente, cl.Nome, os.Tecnico, tc.Nome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.Local_, os.Observacoes, os.Custo, os.Status_");
            sql.Append(" from OrdemServico as os");
            sql.Append(" inner join Cliente as cl on cl.IdCliente=os.Cliente");
            sql.Append(" inner join Tecnico as tc on tc.IdTecnico=os.Tecnico");
            sql.Append(" where os.Tecnico = tc.IdTecnico");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.IdOS = Convert.ToInt32(dr["IdOS"]);
                os.IdCliente = Convert.ToInt32(dr["Cliente_IdCliente"]);
                os.IdTecnico = Convert.ToInt32(dr["Tecnico_IdTecnico"]);
                os.Equipamento = dr.IsDBNull(dr.GetOrdinal("Equipamento")) ? "" : (String)dr["Equipamento"];
                os.Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (String)dr["Marca"];
                os.Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (String)dr["Modelo"];
                os.NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (String)dr["NumeroSerie"];
                os.Defeito = dr.IsDBNull(dr.GetOrdinal("Defeito")) ? "" : (String)dr["Defeito"];
                os.Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (String)dr["Servico"];
                os.Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (String)dr["Local_"];
                os.Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (String)dr["Observacoes"];
                os.Custo = (Decimal)dr["Custo"];
                os.Status = dr.IsDBNull(dr.GetOrdinal("Status_")) ? "" : (String)dr["Status_"];
            }
            return os;
        }

        public static List<OrdemServico> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<OrdemServico> os = new List<OrdemServico>();

            sql.Append("select os.IdOS, os.Cliente, cl.Nome, os.Tecnico, tc.Nome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.Local_, os.Observacoes, os.Custo, os.Status_");
            sql.Append(" from OrdemServico as os");
            sql.Append(" inner join Cliente as cl on cl.IdCliente=os.Cliente");
            sql.Append(" inner join Tecnico as tc on tc.IdTecnico=os.Tecnico");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.Add(
                    new OrdemServico
                    {
                        IdOS = Convert.ToInt32(dr["IdOS"]),
                        IdCliente = Convert.ToInt32(dr["Cliente_IdCliente"]),
                        IdTecnico = Convert.ToInt32(dr["Tecnico_IdTecnico"]),
                        Equipamento = dr.IsDBNull(dr.GetOrdinal("Equipamento")) ? "" : (String)dr["Equipamento"],
                        Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (String)dr["Marca"],
                        Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (String)dr["Modelo"],
                        NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (String)dr["NumeroSerie"],
                        Defeito = dr.IsDBNull(dr.GetOrdinal("Defeito")) ? "" : (String)dr["Defeito"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (String)dr["Servico"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (String)dr["Local_"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (String)dr["Observacoes"],
                        Custo = (Decimal)dr["Custo"],
                        Status = dr.IsDBNull(dr.GetOrdinal("Status_")) ? "" : (String)dr["Status_"]
                    });
            }
            return os;
        }

    }
}
