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
    public class AgendaRepository
    {

        public void Create(Agenda pAgenda)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Agenda (Tecnico, Cliente, Data_, Hora, Local_, Servico, Observacoes, Status_)");
            sql.Append("VALUES(@IdTecnico, @IdCliente, @Data, @Hora, @Local, @Servico, @Observacoes, @Status)");

            cmd.Parameters.AddWithValue("@IdTecnico", pAgenda.IdTecnico);
            cmd.Parameters.AddWithValue("@IdCliente", pAgenda.IdCliente);
            cmd.Parameters.AddWithValue("@Data", pAgenda.Data);
            cmd.Parameters.AddWithValue("@Hora", pAgenda.Hora);
            cmd.Parameters.AddWithValue("@Local", pAgenda.Local);
            cmd.Parameters.AddWithValue("@Servico", pAgenda.Servico);
            cmd.Parameters.AddWithValue("@Observacoes", pAgenda.Observacoes);
            cmd.Parameters.AddWithValue("@Status", pAgenda.Status);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Agenda pAgenda)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Agenda SET Data_=@Data, Hora=@Hora, Local_=@Local, Servico=@Servico, Observacoes=@Observacoes");
            sql.Append(" WHERE IdAgenda=" + pAgenda.IdAgenda);

            cmd.Parameters.AddWithValue("@Data", pAgenda.Data);
            cmd.Parameters.AddWithValue("@Hora", pAgenda.Hora);
            cmd.Parameters.AddWithValue("@Local", pAgenda.Local);
            cmd.Parameters.AddWithValue("@Servico", pAgenda.Servico);
            cmd.Parameters.AddWithValue("@Observacoes", pAgenda.Observacoes);
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

        public static Agenda GetClienteName(String pClienteNome)
        {
            StringBuilder sql = new StringBuilder();
            Agenda agenda = new Agenda();

            sql.Append("SELECT * ");
            sql.Append("FROM Agenda ");
            sql.Append("WHERE ClienteNome = '" + pClienteNome + "'");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agenda.IdAgenda = Convert.ToInt32(dr["IdAgenda"]);
                agenda.IdCliente = Convert.ToInt32(dr["Cliente"]);
                agenda.ClienteNome = (String)dr["ClienteNome"];
                agenda.IdTecnico = Convert.ToInt32(dr["Tecnico"]);
                agenda.TecnicoNome = (String)dr["TecnicoNome"];
                agenda.Data = (DateTime)dr["Data_"];
                agenda.Hora = (DateTime)dr["Hora"];
                agenda.Local = (String)dr["Local_"];
                agenda.Servico = (String)dr["Servico"];
                agenda.Observacoes = (String)dr["Observacoes"];
                agenda.Status = (Boolean)dr["Status_"];
            }
            dr.Close();
            return agenda;
        }

        public static Agenda GetTecnicoName(String pTecnicoNome)
        {
            StringBuilder sql = new StringBuilder();
            Agenda agenda = new Agenda();

            sql.Append("SELECT * ");
            sql.Append("FROM Agenda ");
            sql.Append("WHERE TecnicoNome = '" + pTecnicoNome + "'");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agenda.IdAgenda = Convert.ToInt32(dr["IdAgenda"]);
                agenda.IdCliente = Convert.ToInt32(dr["Cliente"]);
                agenda.ClienteNome = (String)dr["ClienteNome"];
                agenda.IdTecnico = Convert.ToInt32(dr["Tecnico"]);
                agenda.TecnicoNome = (String)dr["TecnicoNome"];
                agenda.Data = (DateTime)dr["Data_"];
                agenda.Hora = (DateTime)dr["Hora"];
                agenda.Local = (String)dr["Local_"];
                agenda.Servico = (String)dr["Servico"];
                agenda.Observacoes = (String)dr["Observacoes"];
                agenda.Status = (Boolean)dr["Status_"];
            }
            dr.Close();
            return agenda;
        }

        public static Agenda GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Agenda agenda = new Agenda();

            sql.Append("select ag.IdAgenda, ag.Tecnico, tc.Nome as tecnicos, ag.Cliente, cl.Nome as clientes, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes, Status_");
            sql.Append(" from Agenda as ag");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on ag.Cliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on ag.Tecnico = tc.IdTecnico");
            sql.Append(" WHERE ag.IdAgenda = " + pId );

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agenda.IdAgenda = Convert.ToInt32(dr["IdAgenda"]);
                agenda.IdCliente = Convert.ToInt32(dr["Cliente"]);
                agenda.ClienteNome = (String)dr["clientes"];
                agenda.IdTecnico = Convert.ToInt32(dr["Tecnico"]);
                agenda.TecnicoNome = (String)dr["tecnicos"];
                agenda.Data = (DateTime)dr["Data_"];
                agenda.Hora = (DateTime)dr["Hora"];
                agenda.Local = (String)dr["Local_"];
                agenda.Servico = (String)dr["Servico"];
                agenda.Observacoes = (String)dr["Observacoes"];
                agenda.Status = Convert.ToBoolean(dr["Status_"]);
            }
            dr.Close();
            return agenda;
        }

        public static List<Agenda> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Agenda> agendas = new List<Agenda>();

            sql.Append("select ag.IdAgenda, ag.Tecnico, tc.Nome as tecnicos, ag.Cliente, cl.Nome as clientes, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes, ag.Status_");
            sql.Append(" from Agenda as ag");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on ag.Cliente = cl.IdCliente");
            sql.Append(" inner join Tecnico as tc");
            sql.Append(" on ag.Tecnico = tc.IdTecnico");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                agendas.Add(
                    new Agenda
                    {
                        IdAgenda = Convert.ToInt32(dr["IdAgenda"]),
                        IdTecnico = Convert.ToInt32(dr["Tecnico"]),
                        TecnicoNome = dr.IsDBNull(dr.GetOrdinal("tecnicos")) ? "" : (String)dr["tecnicos"],
                        IdCliente = Convert.ToInt32(dr["Cliente"]),
                        ClienteNome = dr.IsDBNull(dr.GetOrdinal("clientes")) ? "" : (String)dr["clientes"],
                        Data = (DateTime)dr["Data_"],
                        Hora = (DateTime)dr["Hora"],
                        Local = dr.IsDBNull(dr.GetOrdinal("Local_")) ? "" : (String)dr["Local_"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (String)dr["Servico"],
                        Observacoes = dr.IsDBNull(dr.GetOrdinal("Observacoes")) ? "" : (String)dr["Observacoes"],
                        Status = (Boolean)dr["Status_"]
                    });
            }
            dr.Close();
            return agendas;
        }

    }
}