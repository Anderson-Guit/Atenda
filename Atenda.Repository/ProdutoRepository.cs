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
    public class ProdutoRepository
    {
        public void Create(Produto pProduto)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Produto (Nome, Descricao, Valor, QntdEstoque)");
            sql.Append("VALUES(@Nome, @Descricao, @Valor, @QntdEstoque)");

            cmd.Parameters.AddWithValue("@Nome", (pProduto.Nome));

            if (!string.IsNullOrEmpty(pProduto.Descricao))
                cmd.Parameters.Add("@Descricao", SqlString.Null).Value = pProduto.Descricao;
            else
                cmd.Parameters.Add("@Descricao", SqlString.Null);

            cmd.Parameters.AddWithValue("@Valor", pProduto.Valor);

            if (pProduto.QntdEstoque != null)
                cmd.Parameters.Add("@QntdEstoque", SqlString.Null).Value = pProduto.QntdEstoque;
            else
                cmd.Parameters.Add("@QntdEstoque", SqlString.Null);


            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Produto pProduto)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Produto SET Nome=@Nome, Descricao=@Descricao, Valor=@Valor, QntdEstoque=@QntdEstoque");
            sql.Append(" WHERE IdProduto=" + pProduto.IdProduto);

            cmd.Parameters.AddWithValue("@Nome", (pProduto.Nome));

            if (!string.IsNullOrEmpty(pProduto.Descricao))
                cmd.Parameters.Add("@Descricao", SqlString.Null).Value = pProduto.Descricao;
            else
                cmd.Parameters.Add("@Descricao", SqlString.Null);

            cmd.Parameters.AddWithValue("@Valor", pProduto.Valor);

            if (pProduto.QntdEstoque != null)
                cmd.Parameters.Add("@QntdEstoque", SqlString.Null).Value = pProduto.QntdEstoque;
            else
                cmd.Parameters.Add("@QntdEstoque", SqlString.Null);

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
                        QntdEstoque = dr.IsDBNull(dr.GetOrdinal("QntdEstoque")) ? null : (int?)dr["QntdEstoque"],
                    });
            }
            dr.Close();
            return produtos;
        }

        public static Produto GetOne(int? pId)
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
                produto.QntdEstoque = dr.IsDBNull(dr.GetOrdinal("QntdEstoque")) ? null : (int?)dr["QntdEstoque"];

            }
            dr.Close();
            return produto;
        }

        public static List<Produto> GetAllByOS( int pIdOs)
        {
            StringBuilder sql = new StringBuilder();
            List<Produto> produtos = new List<Produto>();

            sql.Append("select prod.IdProduto, prod.Nome, prod.Valor, Os_P.Qntd as Quantidade");
            sql.Append(" from Produto as prod");
            sql.Append(" inner join OrdemServico_Produto as Os_P");
            sql.Append(" on Os_P.IdProduto = prod.IdProduto && Os_P.IdOS = " + pIdOs);
            //sql.Append(" where Os_P.IdProduto = ")

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                produtos.Add(
                    new Produto
                    {
                        IdProduto = (int)dr["IdProduto"],
                        Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (string)dr["Nome"],
                        Valor = (decimal)dr["Valor"],
                        QntdEstoque = dr.IsDBNull(dr.GetOrdinal("Quantidade")) ? null : (int?)dr["Quantidade"],
                    });
            }
            dr.Close();
            return produtos;
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
                        QntdEstoque = dr.IsDBNull(dr.GetOrdinal("QntdEstoque")) ? null : (int?)dr["QntdEstoque"],
                    });
            }
            dr.Close();
            return produtos;
        }
    }
}
