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
    public class AgendaRepository
    {

        public void Create(Agenda pAgenda)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Agenda (IdTecnico, IdCliente, Data_, Hora, Local_, Servico, Observacoes, Status_)");
            sql.Append("VALUES(@IdTecnico, @IdCliente, @Data, @Hora, @Local, @Servico, @Observacoes, @Status)");

            cmd.Parameters.AddWithValue("@IdTecnico", pAgenda.IdTecnico);
            cmd.Parameters.AddWithValue("@IdCliente", pAgenda.IdCliente);
            cmd.Parameters.AddWithValue("@Data", pAgenda.Data);

            if ((pAgenda.Hora) != null)
                cmd.Parameters.Add("@Hora", SqlString.Null).Value = pAgenda.Hora;
            else
                cmd.Parameters.Add("@Hora", SqlString.Null);

            if (!string.IsNullOrEmpty(pAgenda.Local))
                cmd.Parameters.Add("@Local", SqlString.Null).Value = pAgenda.Local;
            else
                cmd.Parameters.Add("@Local", SqlString.Null);

            if (!string.IsNullOrEmpty(pAgenda.Servico))
                cmd.Parameters.Add("@Servico", SqlString.Null).Value = pAgenda.Servico;
            else
                cmd.Parameters.Add("@Servico", SqlString.Null);

            if (!string.IsNullOrEmpty(pAgenda.Observacoes))
                cmd.Parameters.Add("@Observacoes", SqlString.Null).Value = pAgenda.Observacoes;
            else
                cmd.Parameters.Add("@Observacoes", SqlString.Null);

            cmd.Parameters.AddWithValue("@Status", pAgenda.Status);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Agenda pAgenda)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Agenda SET IdTecnico=@IdTecnico, Data_=@Data, Hora=@Hora, Local_=@Local, Servico=@Servico, Observacoes=@Observacoes, Status_=@Status");
            sql.Append(" WHERE IdAgenda=" + pAgenda.IdAgenda);

            cmd.Parameters.AddWithValue("@IdTecnico", pAgenda.IdTecnico);
            cmd.Parameters.AddWithValue("@Data", pAgenda.Data);

            if ((pAgenda.Hora) != null)
                cmd.Parameters.Add("@Hora", SqlString.Null).Value = pAgenda.Hora;
            else
                cmd.Parameters.Add("@Hora", SqlString.Null);

            if (!string.IsNullOrEmpty(pAgenda.Local))
                cmd.Parameters.Add("@Local", SqlString.Null).Value = pAgenda.Local;
            else
                cmd.Parameters.Add("@Local", SqlString.Null);

            if (!string.IsNullOrEmpty(pAgenda.Servico))
                cmd.Parameters.Add("@Servico", SqlString.Null).Value = pAgenda.Servico;
            else
                cmd.Parameters.Add("@Servico", SqlString.Null);

            if (!string.IsNullOrEmpty(pAgenda.Observacoes))
                cmd.Parameters.Add("@Observacoes", SqlString.Null).Value = pAgenda.Observacoes;
            else
                cmd.Parameters.Add("@Observacoes", SqlString.Null);

            cmd.Parameters.AddWithValue("@Status", pAgenda.Status);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("DELETE FROM Agenda ");
            sql.Append("WHERE IdAgenda = " + pId);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public static List<Agenda> GetClienteNome(String pClienteNome)
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> agendas = new List<Agenda>();

            sql.Append("select ag.IdAgenda, ag.IdTecnico, tc.Nome as TecnicoNome, ag.IdCliente, cl.Nome as ClienteNome, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes, ag.Status_");
            sql.Append(" from Agenda as ag");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on ag.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on ag.IdTecnico = tc.IdTecnico");
            sql.Append(" WHERE cl.Nome Like '%" + pClienteNome.Trim() + "%'");
            sql.Append(" ORDER BY ag.Data_");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agendas.Add(
                    new Agenda
                    {
                        IdAgenda = (int)dr["IdAgenda"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = (string)dr["ClienteNome"],
                        IdTecnico = (int)dr["IDTecnico"],
                        TecnicoNome = (string)dr["TecnicoNome"],
                        Data = (DateTime)dr["Data_"],
                        Hora = dr.IsDBNull(dr.GetOrdinal("Hora")) ? null : (DateTime?)dr["Hora"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Status = (string)dr["Status_"],
                    });
            }
            dr.Close();
            return agendas;
        }

        public static List<Agenda> GetTecnicoNome(String pTecnicoNome)
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> agendas = new List<Agenda>();

            sql.Append("select ag.IdAgenda, ag.IdTecnico, tc.Nome as TecnicoNome, ag.IdCliente, cl.Nome as ClienteNome, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes, ag.Status_");
            sql.Append(" from Agenda as ag");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on ag.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on ag.IdTecnico = tc.IdTecnico");
            sql.Append(" WHERE tc.Nome Like '%" + pTecnicoNome.Trim() + "%'");
            sql.Append(" ORDER BY ag.Data_");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agendas.Add(
                    new Agenda
                    {
                        IdAgenda = (int)dr["IdAgenda"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = (string)dr["ClienteNome"],
                        IdTecnico = (int)dr["IdTecnico"],
                        TecnicoNome = (string)dr["TecnicoNome"],
                        Data = (DateTime)dr["Data_"],
                        Hora = dr.IsDBNull(dr.GetOrdinal("Hora")) ? null : (DateTime?)dr["Hora"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Status = (string)dr["Status_"],
                    });
            }
            dr.Close();
            return agendas;
        }

        public static List<Agenda> GetStatus(string pStatus)
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> agendas = new List<Agenda>();

            sql.Append("select ag.IdAgenda, ag.IdTecnico, tc.Nome as TecnicoNome, ag.IdCliente, cl.Nome as ClienteNome, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes, ag.Status_");
            sql.Append(" from Agenda as ag");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on ag.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on ag.IdTecnico = tc.IdTecnico");
            sql.Append(" WHERE ag.Status_ Like '%" + pStatus.Trim() + "%'");
            sql.Append(" ORDER BY ag.Data_");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agendas.Add(
                    new Agenda
                    {
                        IdAgenda = (int)dr["IdAgenda"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = (string)dr["ClienteNome"],
                        IdTecnico = (int)dr["IdTecnico"],
                        TecnicoNome = (string)dr["TecnicoNome"],
                        Data = (DateTime)dr["Data_"],
                        Hora = dr.IsDBNull(dr.GetOrdinal("Hora")) ? null : (DateTime?)dr["Hora"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Status = (string)dr["Status_"],
                    });
            }
            dr.Close();
            return agendas;
        }

        public static Agenda GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Agenda agenda = new Agenda();

            sql.Append("select ag.IdAgenda, ag.IdTecnico, tc.Nome as TecnicoNome, ag.IdCliente, cl.Nome as ClienteNome, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes, ag.Status_");
            sql.Append(" from Agenda as ag");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on ag.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on ag.IdTecnico = tc.IdTecnico");
            sql.Append(" WHERE ag.IdAgenda = " + pId );

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agenda.IdAgenda = (int)dr["IdAgenda"];
                agenda.IdCliente = (int)dr["IdCliente"];
                agenda.ClienteNome = (string)dr["ClienteNome"];
                agenda.IdTecnico = (int)dr["IDTecnico"];
                agenda.TecnicoNome = (string)dr["TecnicoNome"];
                agenda.Data = (DateTime)dr["Data_"];
                agenda.Hora = dr.IsDBNull(dr.GetOrdinal("Hora")) ? null : (DateTime?)dr["Hora"];
                agenda.Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"];
                agenda.Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"];
                agenda.Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"];
                agenda.Status = (string)dr["Status_"];
            }
            dr.Close();
            return agenda;
        }

        public static List<Agenda> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> agendas = new List<Agenda>();

            sql.Append("select ag.IdAgenda, ag.IdTecnico, tc.Nome as TecnicoNome, ag.IdCliente, cl.Nome as ClienteNome, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes, ag.Status_");
            sql.Append(" from Agenda as ag");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on ag.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on ag.IdTecnico = tc.IdTecnico");
            sql.Append(" ORDER BY ag.Data_");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agendas.Add(
                    new Agenda
                    {
                        IdAgenda = (int)dr["IdAgenda"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = (string)dr["ClienteNome"],
                        IdTecnico = (int)dr["IdTecnico"],
                        TecnicoNome = (string)dr["TecnicoNome"],
                        Data = (DateTime)dr["Data_"],
                        Hora = dr.IsDBNull(dr.GetOrdinal("Hora")) ? null : (DateTime?)dr["Hora"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Status = (string)dr["Status_"],
                    });
            }
            dr.Close();
            return agendas;
        }

        public static List<Agenda> GetAllToIndex()
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> agendas = new List<Agenda>();

            sql.Append(" select top (5)");
            sql.Append(" ag.IdAgenda, ag.IdTecnico, tc.Nome as TecnicoNome, ag.IdCliente, cl.Nome as ClienteNome, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes, ag.Status_");
            sql.Append(" from Agenda as ag");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on ag.IdCliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on ag.IdTecnico = tc.IdTecnico");
            sql.Append(" ORDER BY ag.Data_");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agendas.Add(
                    new Agenda
                    {
                        IdAgenda = (int)dr["IdAgenda"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = (string)dr["ClienteNome"],
                        IdTecnico = (int)dr["IDTecnico"],
                        TecnicoNome = (string)dr["TecnicoNome"],
                        Data = (DateTime)dr["Data_"],
                        Hora = dr.IsDBNull(dr.GetOrdinal("Hora")) ? null : (DateTime?)dr["Hora"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (string)dr["Local_"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (string)dr["Observacoes"],
                        Status = (string)dr["Status_"],
                    });
            }
            dr.Close();
            return agendas;
        }

    }
}