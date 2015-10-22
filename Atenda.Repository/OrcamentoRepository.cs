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
    public class OrcamentoRepository
    {

        public void Create(Orcamento pOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Orcamento (Servico, ValorServico, IdProduto, ValorProduto, ValorTotal, IdCliente)");
            sql.Append("VALUES(@Servico, @ValorServico, @IdProduto, @ValorProduto, @ValorTotal, @IdCliente)");

            cmd.Parameters.AddWithValue("@Servico", pOrcamento.Servico);
            cmd.Parameters.AddWithValue("@ValorServico", pOrcamento.ValorServico);
            cmd.Parameters.AddWithValue("@IdProduto", pOrcamento.IdProduto);
            cmd.Parameters.AddWithValue("@ValorProduto", pOrcamento.ValorProduto);
            cmd.Parameters.AddWithValue("@ValorTotal", pOrcamento.ValorTotal);
            cmd.Parameters.AddWithValue("@IdCliente", pOrcamento.IdCliente);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Orcamento pOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Orcamento SET Servico=@Servico, ValorServico=@ValorServico, IdProduto=@IdProduto, ValorProduto=@ValorProduto, ValorTotal=@ValorTotal");
            sql.Append(" WHERE IdOrcamento=" + pOrcamento.IdOrcamento);

            cmd.Parameters.AddWithValue("@Servico", pOrcamento.Servico);
            cmd.Parameters.AddWithValue("@ValorServico", pOrcamento.ValorServico);
            cmd.Parameters.AddWithValue("@IdProduto", pOrcamento.IdProduto);
            cmd.Parameters.AddWithValue("@ValorProduto", pOrcamento.ValorProduto);
            cmd.Parameters.AddWithValue("@ValorTotal", pOrcamento.ValorTotal);
            cmd.Parameters.AddWithValue("@IdCliente", pOrcamento.IdCliente);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("DELETE FROM Orcamento ");
            sql.Append("WHERE IdOrcamento = " + pId);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public static Orcamento GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Orcamento orcamento = new Orcamento();

            sql.Append("select oc.IdOrcamento, oc.Servico, oc.ValorServico, oc.IdProduto, pr.Nome as nomeproduto, pr.Valor as valorproduto, oc.ValorTotal, oc.IdCliente, cl.Nome as nomecliente");
            sql.Append(" from Orcamento as oc");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on oc.IdCliente = cl.IdCliente");
            sql.Append(" inner join produto as pr");
            sql.Append(" on oc.IdProduto = pr.IdProduto");
            sql.Append(" WHERE oc.IdOrcamento = " + pId);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                orcamento.IdOrcamento = (int)dr["IdOrcamento"];
                orcamento.Servico = (string)dr["Servico"];
                orcamento.ValorServico = (decimal)dr["ValorServico"];
                orcamento.IdProduto = (int)dr["IdProduto"];
                orcamento.NomeProduto = (string)dr["nomeproduto"];
                orcamento.ValorProduto = (decimal)dr["valorproduto"];
                orcamento.ValorTotal = (decimal)dr["ValorTotal"];
                orcamento.IdCliente = (int)dr["IdCliente"];
                orcamento.NomeCliente = (string)dr["nomecliente"];

            }
            dr.Close();
            return orcamento;
        }

        public static Orcamento GetByClienteName(String Nome)
        {
            StringBuilder sql = new StringBuilder();
            Orcamento orcamento = new Orcamento();

            sql.Append("select oc.IdOrcamento, oc.Servico, oc.ValorServico, oc.IdProduto, pr.Nome as nomeproduto, pr.Valor as valorproduto, oc.ValorTotal, oc.IdCliente, cl.Nome as nomecliente");
            sql.Append(" from Orcamento as oc");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on oc.IdCliente = cl.IdCliente");
            sql.Append(" inner join produto as pr");
            sql.Append(" on oc.IdProduto = pr.IdProduto");
            sql.Append(" WHERE nomecliente = " + Nome);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                orcamento.IdOrcamento = (int)dr["IdOrcamento"];
                orcamento.Servico = (string)dr["Servico"];
                orcamento.ValorServico = (decimal)dr["ValorServico"];
                orcamento.IdProduto = (int)dr["IdProduto"];
                orcamento.NomeProduto = (string)dr["nomeproduto"];
                orcamento.ValorProduto = (decimal)dr["valorproduto"];
                orcamento.ValorTotal = (decimal)dr["ValorTotal"];
                orcamento.IdCliente = (int)dr["IdCliente"];
                orcamento.NomeCliente = (string)dr["nomecliente"];

            }
            dr.Close();
            return orcamento;
        }

        public static List<Orcamento> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Orcamento> orcamentos = new List<Orcamento>();

            sql.Append("select oc.IdOrcamento, oc.Servico, oc.ValorServico, oc.IdProduto, pr.Nome as nomeproduto, pr.Valor as valorproduto, oc.ValorTotal, oc.IdCliente, cl.Nome as nomecliente");
            sql.Append(" from Orcamento as oc");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on oc.IdCliente = cl.IdCliente");
            sql.Append(" inner join produto as pr");
            sql.Append(" on oc.IdProduto = pr.IdProduto");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                orcamentos.Add(
                    new Orcamento
                    {
                        IdOrcamento = (int)dr["IdOrcamento"],
                        Servico = (string)dr["Servico"],
                        ValorServico = (decimal)dr["ValorServico"],
                        IdProduto = (int)dr["IdProduto"],
                        NomeProduto = (string)dr["nomeproduto"],
                        ValorProduto = (decimal)dr["valorproduto"],
                        ValorTotal = (decimal)dr["ValorTotal"],
                        IdCliente = (int)dr["IdCliente"],
                        NomeCliente = (string)dr["nomecliente"],
                    });
            }
            dr.Close();
            return orcamentos;
        }

    }
}