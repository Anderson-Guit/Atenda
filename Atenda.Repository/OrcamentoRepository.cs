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
    class OrcamentoRepository
    {

        public void Create(Orcamento pOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Orcamento (Servico, ValorServico, IdProduto, ValorTotal, IdCliente)");
            sql.Append("VALUES(@Servico, @ValorServico, @IdProduto, @ValorTotal, @IdCliente)");

            cmd.Parameters.AddWithValue("@Servico", pOrcamento.Servico);
            cmd.Parameters.AddWithValue("@ValorServico", pOrcamento.ValorServico);
            cmd.Parameters.AddWithValue("@IdProduto", pOrcamento.IdProduto);
            cmd.Parameters.AddWithValue("@ValorTotal", pOrcamento.ValorTotal);
            cmd.Parameters.AddWithValue("@IdCliente", pOrcamento.IdCliente);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Orcamento pOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Orcamento SET Servico=@Servico, ValorServico=@ValorServico, IdProduto=@IdProduto, ValorTotal=@ValorTotal");
            sql.Append(" WHERE IdOrcamento=" + pOrcamento.IdOrcamento);

            cmd.Parameters.AddWithValue("@Servico", pOrcamento.Servico);
            cmd.Parameters.AddWithValue("@ValorServico", pOrcamento.ValorServico);
            cmd.Parameters.AddWithValue("@IdProduto", pOrcamento.IdProduto);
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

            sql.Append("select or.IdOrcamento, or.Servico, or.ValorServico, or.IdProduto, pr.Nome as nomeproduto, pr.Valor as valorproduto, or.ValorTotal, or.IdCliente, cl.Nome as nomecliente");
            sql.Append(" from Orcamento as or");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on or.IdCliente = cl.IdCliente");
            sql.Append(" inner join produto as pr");
            sql.Append(" on or.IdProduto = pr.IdProduto");
            sql.Append(" WHERE or.IdOrcamento = " + pId);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                orcamento.IdOrcamento = (int)dr["IdOrcamento"];
                orcamento.Servico = (String)dr["Servico"];
                orcamento.ValorServico = (Decimal)dr["ValorServico"];
                orcamento.IdProduto = Convert.ToInt32(dr["IdProduto"]);
                orcamento.NomeProduto = (String)dr["nomeproduto"];
                orcamento.ValorProduto = (Decimal)dr["valorproduto"];
                orcamento.ValorTotal = (Decimal)dr["ValorTotal"];
                orcamento.IdCliente = (int)dr["IdCliente"];
                orcamento.NomeCliente = (String)dr["nomecliente"];

            }
            dr.Close();
            return orcamento;
        }

        public static List<Orcamento> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Orcamento> orcamentos = new List<Orcamento>();

            sql.Append("select or.IdOrcamento, or.Servico, or.ValorServico, or.IdProduto, pr.Nome as nomeproduto, pr.Valor as valorproduto, or.ValorTotal, or.IdCliente, cl.Nome as nomecliente");
            sql.Append(" from Orcamento as or");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on or.IdCliente = cl.IdCliente");
            sql.Append(" inner join produto as pr");
            sql.Append(" on or.IdProduto = pr.IdProduto");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                orcamentos.Add(
                    new Orcamento
                    {
                        IdOrcamento = (int)dr["IdOrcamento"],
                        Servico = (String)dr["Servico"],
                        ValorServico = (Decimal)dr["ValorServico"],
                        IdProduto = Convert.ToInt32(dr["IdProduto"]),
                        NomeProduto = (String)dr["nomeproduto"],
                        ValorProduto = (Decimal)dr["valorproduto"],
                        ValorTotal = (Decimal)dr["ValorTotal"],
                        IdCliente = (int)dr["IdCliente"],
                        NomeCliente = (String)dr["nomecliente"],
                    });
            }
            dr.Close();
            return orcamentos;
        }

    }
}