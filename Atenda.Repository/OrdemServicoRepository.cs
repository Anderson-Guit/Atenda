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

            sql.Append("INSERT INTO OrdemServico (IdCliente, IdTecnico, Equipamento, Marca, Modelo, NumeroSerie, Defeito, Servico, DataEntrada, DataSaida, Local_, Observacoes, Custo, Status_) ");
            sql.Append("VALUES(@Cliente, @Tecnico, @Equipamento, @Marca, @Modelo, @NumeroSerie, @Defeito, @Servico, @DataEntrada, @DataSaida, @Local, @Observacoes, @Custo, @Status)");

            cmd.Parameters.AddWithValue("@Cliente", (pOS.IdCliente));
            cmd.Parameters.AddWithValue("@Tecnico", (pOS.IdTecnico));
            cmd.Parameters.AddWithValue("@Equipamento", (pOS.Equipamento));
            cmd.Parameters.AddWithValue("@Marca", pOS.Marca);
            cmd.Parameters.AddWithValue("@Modelo", pOS.Modelo);
            cmd.Parameters.AddWithValue("@NumeroSerie", pOS.NumeroSerie);
            cmd.Parameters.AddWithValue("@Defeito", pOS.Defeito);
            cmd.Parameters.AddWithValue("@Servico", pOS.Servico);
            cmd.Parameters.AddWithValue("@DataEntrada", pOS.DataEntrada);
            cmd.Parameters.AddWithValue("@DataSaida", pOS.DataSaida);
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

            sql.Append("UPDATE OrdemServico SET Equipamento=@Equipamento, Marca=@Marca, Modelo=@Modelo, NumeroSerie=@NumeroSerie, Defeito=@Defeito, Servico=@Servico, DataEntrada=@DataEntrada, DataSaida=@DataSaida, Local_=@Local, Observacoes=@Observacoes, Custo=@Custo, Status_=@Status");
            sql.Append(" WHERE IdOS=" + pOS.IdOS);

            cmd.Parameters.AddWithValue("@Equipamento", (pOS.Equipamento));
            cmd.Parameters.AddWithValue("@Marca", pOS.Marca);
            cmd.Parameters.AddWithValue("@Modelo", pOS.Modelo);
            cmd.Parameters.AddWithValue("@NumeroSerie", pOS.NumeroSerie);
            cmd.Parameters.AddWithValue("@Defeito", pOS.Defeito);
            cmd.Parameters.AddWithValue("@Servico", pOS.Servico);
            cmd.Parameters.AddWithValue("@DataEntrada", pOS.DataEntrada);
            cmd.Parameters.AddWithValue("@DataSaida", pOS.DataSaida);
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

            sql.Append("select os.IdOS, os.IdCliente, cl.Nome as clientenome, os.IdTecnico, tc.Nome as tecniconome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.DataEntrada, os.DataSaida, os.Local_, os.Observacoes, os.Custo, os.Status_");
            sql.Append(" from OrdemServico as os");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on os.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on os.IdTecnico = tc.IdTecnico");
            sql.Append(" WHERE os.IdOS = " + pId);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.IdOS = (int)dr["IdOS"];
                os.IdCliente = (int)dr["IdCliente"];
                os.ClienteNome = dr.IsDBNull(dr.GetOrdinal("clientenome")) ? "" : (string)dr["clientenome"];
                os.IdTecnico = (int)dr["IdTecnico"];
                os.TecnicoNome = dr.IsDBNull(dr.GetOrdinal("tecniconome")) ? "" : (string)dr["tecniconome"];
                os.Equipamento = dr.IsDBNull(dr.GetOrdinal("Equipamento")) ? "" : (string)dr["Equipamento"];
                os.Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (string)dr["Marca"];
                os.Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (string)dr["Modelo"];
                os.NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (string)dr["NumeroSerie"];
                os.Defeito = dr.IsDBNull(dr.GetOrdinal("Defeito")) ? "" : (string)dr["Defeito"];
                os.Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"];
                os.DataEntrada = (DateTime)dr["DataEntrada"];
                os.DataSaida = (DateTime)dr["DataSaida"];
                os.Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"];
                os.Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"];
                os.Custo = (decimal)dr["Custo"];
                os.Status = dr.IsDBNull(dr.GetOrdinal("Status_")) ? "" : (string)dr["Status_"];
            }
            return os;
        }

        public static OrdemServico GetClienteNome(String pClienteNome)
        {
            StringBuilder sql = new StringBuilder();
            OrdemServico os = new OrdemServico();

            sql.Append("select os.IdOS, os.IdCliente, cl.Nome as clientenome, os.IdTecnico, tc.Nome as tecniconome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.DataEntrada, os.DataSaida, os.Local_, os.Observacoes, os.Custo, os.Status_");
            sql.Append(" from OrdemServico as os");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on os.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on os.IdTecnico = tc.IdTecnico");
            sql.Append(" WHERE clientenome = " + pClienteNome);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.IdOS = (int)dr["IdOS"];
                os.IdCliente = (int)dr["IdCliente"];
                os.ClienteNome = dr.IsDBNull(dr.GetOrdinal("clientenome")) ? "" : (string)dr["clientenome"];
                os.IdTecnico = (int)dr["IdTecnico"];
                os.TecnicoNome = dr.IsDBNull(dr.GetOrdinal("tecniconome")) ? "" : (string)dr["tecniconome"];
                os.Equipamento = dr.IsDBNull(dr.GetOrdinal("Equipamento")) ? "" : (string)dr["Equipamento"];
                os.Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (string)dr["Marca"];
                os.Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (string)dr["Modelo"];
                os.NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (string)dr["NumeroSerie"];
                os.Defeito = dr.IsDBNull(dr.GetOrdinal("Defeito")) ? "" : (string)dr["Defeito"];
                os.Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"];
                os.DataEntrada = (DateTime)dr["DataEntrada"];
                os.DataSaida = (DateTime)dr["DataSaida"];
                os.Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"];
                os.Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"];
                os.Custo = (decimal)dr["Custo"];
                os.Status = dr.IsDBNull(dr.GetOrdinal("Status_")) ? "" : (string)dr["Status_"];
            }
            return os;
        }

        public static List<OrdemServico> GetTecnicoNome(String pTecnicoNome)
        {
            StringBuilder sql = new StringBuilder();
            List<OrdemServico> os = new List<OrdemServico>();

            sql.Append("select os.IdOS, os.IdCliente, cl.Nome as clientenome, os.IdTecnico, tc.Nome as tecniconome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.DataEntrada, os.DataSaida, os.Local_, os.Observacoes, os.Custo, os.Status_");
            sql.Append(" from OrdemServico as os");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on os.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on os.IdTecnico = tc.IdTecnico");
            sql.Append(" WHERE tc.Nome Like '%" + pTecnicoNome.Trim() + "%'");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.Add(
                    new OrdemServico
                    {
                        IdOS = (int)dr["IdOS"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = dr.IsDBNull(dr.GetOrdinal("clientenome")) ? "" : (string)dr["clientenome"],
                        IdTecnico = (int)dr["IdTecnico"],
                        TecnicoNome = dr.IsDBNull(dr.GetOrdinal("tecniconome")) ? "" : (string)dr["tecniconome"],
                        Equipamento = dr.IsDBNull(dr.GetOrdinal("Equipamento")) ? "" : (string)dr["Equipamento"],
                        Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (string)dr["Marca"],
                        Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (string)dr["Modelo"],
                        NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (string)dr["NumeroSerie"],
                        Defeito = dr.IsDBNull(dr.GetOrdinal("Defeito")) ? "" : (string)dr["Defeito"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"],
                        DataEntrada = (DateTime)dr["DataEntrada"],
                        DataSaida = (DateTime)dr["DataSaida"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Custo = (decimal)dr["Custo"],
                        Status = dr.IsDBNull(dr.GetOrdinal("Status_")) ? "" : (string)dr["Status_"]
                    });
            }
            return os;
        }

        public static List<OrdemServico> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<OrdemServico> os = new List<OrdemServico>();

            sql.Append("select os.IdOS, os.IdCliente, cl.Nome as clientenome, os.IdTecnico, tc.Nome as tecniconome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.DataEntrada, os.DataSaida, os.Local_, os.Observacoes, os.Custo, os.Status_");
            sql.Append(" from OrdemServico as os");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on os.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on os.IdTecnico = tc.IdTecnico");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.Add(
                    new OrdemServico
                    {
                        IdOS = (int)dr["IdOS"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = dr.IsDBNull(dr.GetOrdinal("clientenome")) ? "" : (string)dr["clientenome"],
                        IdTecnico = (int)dr["IdTecnico"],
                        TecnicoNome = dr.IsDBNull(dr.GetOrdinal("tecniconome")) ? "" : (string)dr["tecniconome"],
                        Equipamento = dr.IsDBNull(dr.GetOrdinal("Equipamento")) ? "" : (string)dr["Equipamento"],
                        Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (string)dr["Marca"],
                        Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (string)dr["Modelo"],
                        NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (string)dr["NumeroSerie"],
                        Defeito = dr.IsDBNull(dr.GetOrdinal("Defeito")) ? "" : (string)dr["Defeito"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"],
                        DataEntrada = (DateTime)dr["DataEntrada"],
                        DataSaida = (DateTime)dr["DataSaida"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Custo = (decimal)dr["Custo"],
                        Status = dr.IsDBNull(dr.GetOrdinal("Status_")) ? "" : (string)dr["Status_"]
                    });
            }
            return os;
        }

    }
}