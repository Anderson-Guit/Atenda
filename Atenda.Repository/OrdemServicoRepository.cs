using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atenda.Data;
using Atenda.Conn;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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

            if (!string.IsNullOrEmpty(pOS.Marca))
                cmd.Parameters.Add("@Marca", SqlString.Null).Value = pOS.Marca;
            else
                cmd.Parameters.Add("@Marca", SqlString.Null);

            if (!string.IsNullOrEmpty(pOS.Modelo))
                cmd.Parameters.Add("@Modelo", SqlString.Null).Value = pOS.Modelo;
            else
                cmd.Parameters.Add("@Modelo", SqlString.Null);

            if (!string.IsNullOrEmpty(pOS.NumeroSerie))
                cmd.Parameters.Add("@NumeroSerie", SqlString.Null).Value = pOS.NumeroSerie;
            else
                cmd.Parameters.Add("@NumeroSerie", SqlString.Null);

            cmd.Parameters.AddWithValue("@Defeito", pOS.Defeito);

            cmd.Parameters.AddWithValue("@Servico", pOS.Servico);

            cmd.Parameters.AddWithValue("@DataEntrada", pOS.DataEntrada);

            if (pOS.DataSaida != null)
                cmd.Parameters.Add("@DataSaida", SqlString.Null).Value = pOS.DataSaida;
            else
                cmd.Parameters.Add("@DataSaida", SqlString.Null);

            if (!string.IsNullOrEmpty(pOS.Local))
                cmd.Parameters.Add("@Local", SqlString.Null).Value = pOS.Local;
            else
                cmd.Parameters.Add("@Local", SqlString.Null);

            if (!string.IsNullOrEmpty(pOS.Observacoes))
                cmd.Parameters.Add("@Observacoes", SqlString.Null).Value = pOS.Observacoes;
            else
                cmd.Parameters.Add("@Observacoes", SqlString.Null);

            if (pOS.Custo != null)
                cmd.Parameters.Add("@Custo", SqlString.Null).Value = pOS.Custo;
            else
                cmd.Parameters.Add("@Custo", SqlString.Null);

            cmd.Parameters.AddWithValue("@Status", pOS.Status);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(OrdemServico pOS)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE OrdemServico SET Equipamento=@Equipamento, Marca=@Marca, Modelo=@Modelo, NumeroSerie=@NumeroSerie, Defeito=@Defeito, Servico=@Servico, DataEntrada=@DataEntrada, DataSaida=@DataSaida, Local_=@Local, IdTecnico=@Tecnico, Observacoes=@Observacoes, Custo=@Custo, Status_=@Status");
            sql.Append(" WHERE IdOS=" + pOS.IdOS);

            cmd.Parameters.AddWithValue("@Cliente", (pOS.IdCliente));
            cmd.Parameters.AddWithValue("@Tecnico", (pOS.IdTecnico));
            cmd.Parameters.AddWithValue("@Equipamento", (pOS.Equipamento));

            if (!string.IsNullOrEmpty(pOS.Marca))
                cmd.Parameters.Add("@Marca", SqlString.Null).Value = pOS.Marca;
            else
                cmd.Parameters.Add("@Marca", SqlString.Null);

            if (!string.IsNullOrEmpty(pOS.Modelo))
                cmd.Parameters.Add("@Modelo", SqlString.Null).Value = pOS.Modelo;
            else
                cmd.Parameters.Add("@Modelo", SqlString.Null);

            if (!string.IsNullOrEmpty(pOS.NumeroSerie))
                cmd.Parameters.Add("@NumeroSerie", SqlString.Null).Value = pOS.NumeroSerie;
            else
                cmd.Parameters.Add("@NumeroSerie", SqlString.Null);

            cmd.Parameters.AddWithValue("@Defeito", pOS.Defeito);

            cmd.Parameters.AddWithValue("@Servico", pOS.Servico);

            cmd.Parameters.AddWithValue("@DataEntrada", pOS.DataEntrada);

            if (pOS.DataSaida != null)
                cmd.Parameters.Add("@DataSaida", SqlString.Null).Value = pOS.DataSaida;
            else
                cmd.Parameters.Add("@DataSaida", SqlString.Null);

            if (!string.IsNullOrEmpty(pOS.Local))
                cmd.Parameters.Add("@Local", SqlString.Null).Value = pOS.Local;
            else
                cmd.Parameters.Add("@Local", SqlString.Null);

            if (!string.IsNullOrEmpty(pOS.Observacoes))
                cmd.Parameters.Add("@Observacoes", SqlString.Null).Value = pOS.Observacoes;
            else
                cmd.Parameters.Add("@Observacoes", SqlString.Null);

            if (pOS.Custo != null)
                cmd.Parameters.Add("@Custo", SqlString.Null).Value = pOS.Custo;
            else
                cmd.Parameters.Add("@Custo", SqlString.Null);

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
                os.ClienteNome = (string)dr["clientenome"];
                os.IdTecnico = (int)dr["IdTecnico"];
                os.TecnicoNome = (string)dr["tecniconome"];
                os.Equipamento = (string)dr["Equipamento"];
                os.Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (string)dr["Marca"];
                os.Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (string)dr["Modelo"];
                os.NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (string)dr["NumeroSerie"];
                os.Defeito = (string)dr["Defeito"];
                os.Servico = (string)dr["Servico"];
                os.DataEntrada = (DateTime)dr["DataEntrada"];
                os.DataSaida = dr.IsDBNull(dr.GetOrdinal("DataSaida")) ? null : (DateTime?)dr["DataSaida"];
                os.Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"];
                os.Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"];
                os.Custo = dr.IsDBNull(dr.GetOrdinal("Custo")) ? null : (decimal?)dr["Custo"];
                os.Status = (string)dr["Status_"];
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
                        ClienteNome = (string)dr["clientenome"],
                        IdTecnico = (int)dr["IdTecnico"],
                        TecnicoNome = (string)dr["tecniconome"],
                        Equipamento = (string)dr["Equipamento"],
                        Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (string)dr["Marca"],
                        Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (string)dr["Modelo"],
                        NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (string)dr["NumeroSerie"],
                        Defeito = (string)dr["Defeito"],
                        Servico = (string)dr["Servico"],
                        DataEntrada = (DateTime)dr["DataEntrada"],
                        DataSaida = dr.IsDBNull(dr.GetOrdinal("DataSaida")) ? null : (DateTime?)dr["DataSaida"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Custo = dr.IsDBNull(dr.GetOrdinal("Custo")) ? null : (decimal?)dr["Custo"],
                        Status = (string)dr["Status_"]
                    });
            }
            dr.Close();
            return os;
        }

        public static List<OrdemServico> GetIdOS(int pId)
        {
            StringBuilder sql = new StringBuilder();
            List<OrdemServico> os = new List<OrdemServico>();

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
                os.Add(
                    new OrdemServico
                    {
                        IdOS = (int)dr["IdOS"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = (string)dr["clientenome"],
                        IdTecnico = (int)dr["IdTecnico"],
                        TecnicoNome = (string)dr["tecniconome"],
                        Equipamento = (string)dr["Equipamento"],
                        Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (string)dr["Marca"],
                        Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (string)dr["Modelo"],
                        NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (string)dr["NumeroSerie"],
                        Defeito = (string)dr["Defeito"],
                        Servico = (string)dr["Servico"],
                        DataEntrada = (DateTime)dr["DataEntrada"],
                        DataSaida = dr.IsDBNull(dr.GetOrdinal("DataSaida")) ? null : (DateTime?)dr["DataSaida"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Custo = dr.IsDBNull(dr.GetOrdinal("Custo")) ? null : (decimal?)dr["Custo"],
                        Status = (string)dr["Status_"]
                    });
            }
            return os;
        }

        public static List<OrdemServico> GetClienteNome(string pClienteNome)
        {
            StringBuilder sql = new StringBuilder();
            List<OrdemServico> os = new List<OrdemServico>();

            sql.Append("select os.IdOS, os.IdCliente, cl.Nome as clientenome, os.IdTecnico, tc.Nome as tecniconome, os.Equipamento, os.Marca, os.modelo, os.NumeroSerie, os.Defeito, os.Servico, os.DataEntrada, os.DataSaida, os.Local_, os.Observacoes, os.Custo, os.Status_");
            sql.Append(" from OrdemServico as os");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on os.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on os.IdTecnico = tc.IdTecnico");
            sql.Append(" WHERE cl.Nome Like '%" + pClienteNome.Trim() + "%'");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                os.Add(
                    new OrdemServico
                    {
                        IdOS = (int)dr["IdOS"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = (string)dr["clientenome"],
                        IdTecnico = (int)dr["IdTecnico"],
                        TecnicoNome = (string)dr["tecniconome"],
                        Equipamento = (string)dr["Equipamento"],
                        Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (string)dr["Marca"],
                        Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (string)dr["Modelo"],
                        NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (string)dr["NumeroSerie"],
                        Defeito = (string)dr["Defeito"],
                        Servico = (string)dr["Servico"],
                        DataEntrada = (DateTime)dr["DataEntrada"],
                        DataSaida = dr.IsDBNull(dr.GetOrdinal("DataSaida")) ? null : (DateTime?)dr["DataSaida"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Custo = dr.IsDBNull(dr.GetOrdinal("Custo")) ? null : (decimal?)dr["Custo"],
                        Status = (string)dr["Status_"]
                    });
            }
            return os;
        }

        public static List<OrdemServico> GetTecnicoNome(string pTecnicoNome)
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
                        ClienteNome = (string)dr["clientenome"],
                        IdTecnico = (int)dr["IdTecnico"],
                        TecnicoNome = (string)dr["tecniconome"],
                        Equipamento = (string)dr["Equipamento"],
                        Marca = dr.IsDBNull(dr.GetOrdinal("Marca")) ? "" : (string)dr["Marca"],
                        Modelo = dr.IsDBNull(dr.GetOrdinal("Modelo")) ? "" : (string)dr["Modelo"],
                        NumeroSerie = dr.IsDBNull(dr.GetOrdinal("NumeroSerie")) ? "" : (string)dr["NumeroSerie"],
                        Defeito = (string)dr["Defeito"],
                        Servico = (string)dr["Servico"],
                        DataEntrada = (DateTime)dr["DataEntrada"],
                        DataSaida = dr.IsDBNull(dr.GetOrdinal("DataSaida")) ? null : (DateTime?)dr["DataSaida"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Custo = dr.IsDBNull(dr.GetOrdinal("Custo")) ? null : (decimal?)dr["Custo"],
                        Status = (string)dr["Status_"]
                    });
            }
            return os;
        }

        //public static int BuscaId()
        //{
        //    StringBuilder sql = new StringBuilder();
        //    int idOs = 0;

        //    sql.Append("select MAX(IdOS)");
        //    sql.Append(" from OrdemServico");

        //    SqlDataReader dr = SqlConn.Get(sql.ToString());

        //    while (dr.Read())
        //    {
        //        if ((int?)dr["IdOS"] != null)
        //        {
        //            idOs = (int)dr["IdOS"];
        //        }
        //        else
        //        {
        //            return 0;
        //        }

        //    }
        //    return idOs;
        //}

    }
}