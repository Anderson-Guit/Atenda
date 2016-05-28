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
    public class OrcamentoRepository
    {

        public void Create(Orcamento pOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Orcamento (Servico, Valor, ValorTotal, IdCliente)");
            sql.Append("VALUES(@Servico, @Valor, @ValorTotal, @IdCliente)");

            if (!string.IsNullOrEmpty(pOrcamento.Servico))
                cmd.Parameters.Add("@Servico", SqlString.Null).Value = pOrcamento.Servico;
            else
                cmd.Parameters.Add("@Servico", SqlString.Null);

            if (pOrcamento.Valor != null)
                cmd.Parameters.Add("@Valor", SqlString.Null).Value = pOrcamento.Valor;
            else
                cmd.Parameters.Add("@Valor", SqlString.Null);

            cmd.Parameters.AddWithValue("@ValorTotal", pOrcamento.ValorTotal);

            cmd.Parameters.AddWithValue("@IdCliente", pOrcamento.IdCliente);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void AddProdutos(Orcamento pOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Orcamento_Produto (IdProduto, IdOrcamento, Qntd)");
            sql.Append("VALUES(@IdProduto, @IdOrcamento, @Qntd)");

             var LastIdOrc = GetLast();

             if (pOrcamento.IdProduto != null)
                 cmd.Parameters.Add("@IdOrcamento", SqlString.Null).Value = LastIdOrc.IdOrcamento;
             else
                 cmd.Parameters.Add("@IdOrcamento", SqlString.Null);

            if (pOrcamento.IdProduto != null)
                cmd.Parameters.Add("@IdProduto", SqlString.Null).Value = pOrcamento.IdProduto;
            else
                cmd.Parameters.Add("@IdProduto", SqlString.Null);

            if (pOrcamento.IdProduto != null)
                cmd.Parameters.Add("@Qntd", SqlString.Null).Value = pOrcamento.ProdutoQntd;
            else
                cmd.Parameters.Add("@Qntd", SqlString.Null);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Orcamento pOrcamento)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Orcamento SET Servico=@Servico, Valor=@Valor, IdProduto=@IdProduto, ValorTotal=@ValorTotal");
            sql.Append(" WHERE IdOrcamento=" + pOrcamento.IdOrcamento);

            if (!string.IsNullOrEmpty(pOrcamento.Servico))
                cmd.Parameters.Add("@Servico", SqlString.Null).Value = pOrcamento.Servico;
            else
                cmd.Parameters.Add("@Servico", SqlString.Null);

            if (pOrcamento.Valor != null)
                cmd.Parameters.Add("@Valor", SqlString.Null).Value = pOrcamento.Valor;
            else
                cmd.Parameters.Add("@Valor", SqlString.Null);


            if (pOrcamento.IdProduto != null)
                cmd.Parameters.Add("@IdProduto", SqlString.Null).Value = pOrcamento.IdProduto;
            else
                cmd.Parameters.Add("@IdProduto", SqlString.Null);

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

        public Orcamento GetLast()
        {
            StringBuilder sql = new StringBuilder();
            Orcamento orcamento = new Orcamento();

            sql.Append("SELECT TOP 1 *");
            sql.Append(" FROM Orcamento");
            sql.Append(" ORDER BY IdOrcamento DESC");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                orcamento.IdOrcamento = (int)dr["IdOrcamento"];
            }
            dr.Close();
            return orcamento;
        }

        public List<Produto> GetProdutos(int pId)
        {
            StringBuilder sql = new StringBuilder();
            List<Produto> produtos = new List<Produto>();

            sql.Append("SELECT pro.IdProduto, pro.Nome, pro.Valor, pro.Descricao, o_p.Qntd ");
            sql.Append(" FROM Produto as pro");
            sql.Append(" INNER JOIN Orcamento_Produto as o_p");
            sql.Append(" ON o_p.IdProduto = pro.IdProduto");
            sql.Append(" INNER JOIN Orcamento as orc");
            sql.Append(" ON o_p.IdOrcamento = " + pId);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                produtos.Add(
                    new Produto
                    {
                        IdProduto = (int)dr["IdProduto"],
                        Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (string)dr["Nome"],
                        Descricao = dr.IsDBNull(dr.GetOrdinal("Descricao")) ? "" : (string)dr["Descricao"],
                        Valor = (decimal)dr["Valor"],
                        QntdEstoque = dr.IsDBNull(dr.GetOrdinal("Qntd")) ? null : (int?)dr["Qntd"],
                    });
            }
            dr.Close();
            return produtos;
        }

        public static Orcamento GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Orcamento orcamento = new Orcamento();

            sql.Append("select oc.IdOrcamento, oc.Servico, oc.Valor, oc.ValorTotal, oc.IdCliente, cl.Nome as nomecliente");
            sql.Append(" from Orcamento as oc");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on oc.IdCliente = cl.IdCliente");
            sql.Append(" WHERE oc.IdOrcamento = " + pId);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                orcamento.IdOrcamento = (int)dr["IdOrcamento"];
                orcamento.Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"];
                orcamento.Valor = dr.IsDBNull(dr.GetOrdinal("Valor")) ? null : (decimal?)dr["Valor"];
                orcamento.ValorTotal = (decimal)dr["ValorTotal"];
                orcamento.IdCliente = (int)dr["IdCliente"];
                orcamento.ClienteNome = (string)dr["nomecliente"];

            }
            dr.Close();
            return orcamento;
        }

        public static List<Orcamento> GetClienteName(String pClienteNome)
        {
            StringBuilder sql = new StringBuilder();
            List<Orcamento> orcamentos = new List<Orcamento>();

            sql.Append("select oc.IdOrcamento, oc.Servico, oc.ValorServico, oc.ValorTotal, oc.IdCliente, cl.Nome as nomecliente");
            sql.Append(" from Orcamento as oc");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on oc.IdCliente = cl.IdCliente");
            sql.Append(" WHERE cl.Nome Like '%" + pClienteNome.Trim() + "%'");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                orcamentos.Add(
                    new Orcamento
                    {
                        IdOrcamento = (int)dr["IdOrcamento"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"],
                        Valor = dr.IsDBNull(dr.GetOrdinal("Valor")) ? null : (decimal?)dr["Valor"],
                        ValorTotal = (decimal)dr["ValorTotal"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = (string)dr["nomecliente"],
                    });
            }
            dr.Close();
            return orcamentos;
        }



        public static List<Orcamento> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Orcamento> orcamentos = new List<Orcamento>();

            sql.Append("select oc.IdOrcamento, oc.Servico, oc.Valor, oc.ValorTotal, oc.IdCliente, cl.Nome as nomecliente");
            sql.Append(" from Orcamento as oc");
            sql.Append(" inner join Cliente as cl");
            sql.Append(" on oc.IdCliente = cl.IdCliente");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                orcamentos.Add(
                    new Orcamento
                    {
                        IdOrcamento = (int)dr["IdOrcamento"],
                        Servico = dr.IsDBNull(dr.GetOrdinal("Servico")) ? "" : (string)dr["Servico"],
                        Valor = dr.IsDBNull(dr.GetOrdinal("Valor")) ? null : (decimal?)dr["Valor"],
                        ValorTotal = (decimal)dr["ValorTotal"],
                        IdCliente = (int)dr["IdCliente"],
                        ClienteNome = (string)dr["nomecliente"],
                    });
            }
            dr.Close();
            return orcamentos;
        }

    }
}