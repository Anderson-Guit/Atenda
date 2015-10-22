﻿using System;
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

            sql.Append("INSERT INTO Agenda (IdTecnico, IdCliente, Data_, Hora, Local_, Servico, Observacoes, Status_)");
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

            sql.Append("UPDATE Agenda SET IdTecnico=@IdTecnico, Data_=@Data, Hora=@Hora, Local_=@Local, Servico=@Servico, Observacoes=@Observacoes");
            sql.Append(" WHERE IdAgenda=" + pAgenda.IdAgenda);

            cmd.Parameters.AddWithValue("@IdTecnico", pAgenda.IdTecnico);
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
                agenda.IdAgenda = (int)dr["IdAgenda"];
                agenda.IdCliente = (int)dr["IdCliente"];
                agenda.ClienteNome = (string)dr["ClienteNome"];
                agenda.IdTecnico = (int)dr["IDTecnico"];
                agenda.TecnicoNome = (string)dr["TecnicoNome"];
                agenda.Data = (DateTime)dr["Data_"];
                agenda.Hora = (DateTime)dr["Hora"];
                agenda.Local = (string)dr["Local_"];
                agenda.Servico = (string)dr["Servico"];
                agenda.Observacoes = (string)dr["Observacoes"];
                agenda.Status = (bool)dr["Status_"];
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
                agenda.IdAgenda = (int)dr["IdAgenda"];
                agenda.IdCliente = (int)dr["IdCliente"];
                agenda.ClienteNome = (string)dr["ClienteNome"];
                agenda.IdTecnico = (int)dr["IDTecnico"];
                agenda.TecnicoNome = (string)dr["TecnicoNome"];
                agenda.Data = (DateTime)dr["Data_"];
                agenda.Hora = (DateTime)dr["Hora"];
                agenda.Local = (string)dr["Local_"];
                agenda.Servico = (string)dr["Servico"];
                agenda.Observacoes = (string)dr["Observacoes"];
                agenda.Status = (bool)dr["Status_"];
            }
            dr.Close();
            return agenda;
        }

        public static Agenda GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Agenda agenda = new Agenda();

            sql.Append("select ag.IdAgenda, ag.IdTecnico, tc.Nome as TecnicoNome, ag.IdCliente, cl.Nome as ClienteNome, ag.Data_, ag.Hora, ag.Local_, ag.Servico, ag.Observacoes, Status_");
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
                agenda.Hora = (DateTime)dr["Hora"];
                agenda.Local = (string)dr["Local_"];
                agenda.Servico = (string)dr["Servico"];
                agenda.Observacoes = (string)dr["Observacoes"];
                agenda.Status = (bool)dr["Status_"];
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
                        Hora = (DateTime)dr["Hora"],
                        Local = (string)dr["Local_"],
                        Servico = (string)dr["Servico"],
                        Observacoes = (string)dr["Observacoes"],
                        Status = (bool)dr["Status_"],
                    });
            }
            dr.Close();
            return agendas;
        }

    }
}