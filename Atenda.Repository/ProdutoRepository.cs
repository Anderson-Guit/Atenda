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
    public class ProdutoRepository
    {
        public void Create(Produto pProduto)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Produto (Nome, Descricao, Valor, QntdEstoque)");
            sql.Append("VALUES(@Nome, @Descricao, @Valor, @QntdEstoque)");

            cmd.Parameters.AddWithValue("@Nome", (pProduto.Nome));
            cmd.Parameters.AddWithValue("@Descricao", pProduto.Descricao);
            cmd.Parameters.AddWithValue("@Valor", pProduto.Valor);
            cmd.Parameters.AddWithValue("@QntdEstoque", pProduto.QntdEstoque);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Produto pProduto)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Produto SET Nome=@Nome, Descricao=@Descricao, Valor=@Valor, QntdEstoque=@QntdEstoque");
            sql.Append(" WHERE IdProduto=" + pProduto.IdProduto);

            cmd.Parameters.AddWithValue("@Nome", pProduto.Nome);
            cmd.Parameters.AddWithValue("@Descricao", pProduto.Descricao);
            cmd.Parameters.AddWithValue("@Valor", pProduto.Valor);
            cmd.Parameters.AddWithValue("@QntdEstoque", pProduto.QntdEstoque);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("DELETE FROM Produto ");
            sql.Append("WHERE IdProduto=" + pId);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public static List<Produto> GetName(String pNome)
        {
            StringBuilder sql = new StringBuilder();
            List<Produto> produtos = new List<Produto>();

            sql.Append(" SELECT *");
            sql.Append(" FROM Produto");
            sql.Append(" WHERE Nome like '%" + pNome.Trim() + "%'");
            sql.Append(" ORDER BY Nome");

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
                        QntdEstoque = (int)dr["QntdEstoque"],
                    });
            }
            dr.Close();
            return produtos;
        }

        public static Produto GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Produto produto = new Produto();

            sql.Append("SELECT * ");
            sql.Append("FROM Produto ");
            sql.Append("WHERE IdProduto = " + pId);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                produto.IdProduto = (int)dr["IdProduto"];
                produto.Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (string)dr["Nome"];
                produto.Descricao = dr.IsDBNull(dr.GetOrdinal("Descricao")) ? "" : (string)dr["Descricao"];
                produto.Valor = (decimal)dr["Valor"];
                produto.QntdEstoque = (int)dr["QntdEstoque"];

            }
            dr.Close();
            return produto;
        }

        public static List<Produto> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Produto> produtos = new List<Produto>();

            sql.Append("SELECT * ");
            sql.Append("FROM Produto ");

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
                        QntdEstoque = (int)dr["QntdEstoque"],
                    });
            }
            dr.Close();
            return produtos;
        }
    }
}
