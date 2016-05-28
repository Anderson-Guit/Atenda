using System;
using Atenda.Conn;
using Atenda.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace Atenda.Repository
{
    public class ClienteRepository
    {
        public void Create(Cliente pCliente)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Cliente (Nome, Telefone, Endereco, Bairro, Cidade, Estado, CPF_CNPJ)");
            sql.Append("VALUES(@Nome, @Telefone, @Endereco, @Bairro, @Cidade, @Estado, @CPF_CNPJ)");

            cmd.Parameters.AddWithValue("@Nome", (pCliente.Nome));
            cmd.Parameters.AddWithValue("@Telefone", pCliente.Telefone);

            if (!string.IsNullOrEmpty(pCliente.Endereco))
                cmd.Parameters.Add("@Endereco", SqlString.Null).Value = pCliente.Endereco;
            else
                cmd.Parameters.Add("@Endereco", SqlString.Null);

            if (!string.IsNullOrEmpty(pCliente.Bairro))
                cmd.Parameters.Add("@Bairro", SqlString.Null).Value = pCliente.Bairro;
            else
                cmd.Parameters.Add("@Bairro", SqlString.Null);

            if (!string.IsNullOrEmpty(pCliente.Cidade))
                cmd.Parameters.Add("@Cidade", SqlString.Null).Value = pCliente.Cidade;
            else
                cmd.Parameters.Add("@Cidade", SqlString.Null);

            if (!string.IsNullOrEmpty(pCliente.Estado))
                cmd.Parameters.Add("@Estado", SqlString.Null).Value = pCliente.Estado;
            else
                cmd.Parameters.Add("@Estado", SqlString.Null);

            if (!string.IsNullOrEmpty(pCliente.CPF_CNPJ))
                cmd.Parameters.Add("@CPF_CNPJ", SqlString.Null).Value = pCliente.CPF_CNPJ;
            else
                cmd.Parameters.Add("@CPF_CNPJ", SqlString.Null);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Cliente pCliente)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Cliente SET Nome=@Nome, Telefone=@Telefone, Endereco=@Endereco, Bairro=@Bairro, Cidade=@Cidade, Estado=@Estado, CPF_CNPJ=@CPF_CNPJ");
            sql.Append(" WHERE IdCliente = " + pCliente.IdCliente);

            cmd.Parameters.AddWithValue("@Nome", pCliente.Nome);
            cmd.Parameters.AddWithValue("@Telefone", pCliente.Telefone);

            if (!string.IsNullOrEmpty(pCliente.Endereco))
                cmd.Parameters.Add("@Endereco", SqlString.Null).Value = pCliente.Endereco;
            else
                cmd.Parameters.Add("@Endereco", SqlString.Null);

            if (!string.IsNullOrEmpty(pCliente.Bairro))
                cmd.Parameters.Add("@Bairro", SqlString.Null).Value = pCliente.Bairro;
            else
                cmd.Parameters.Add("@Bairro", SqlString.Null);

            if (!string.IsNullOrEmpty(pCliente.Cidade))
                cmd.Parameters.Add("@Cidade", SqlString.Null).Value = pCliente.Cidade;
            else
                cmd.Parameters.Add("@Cidade", SqlString.Null);

            if (!string.IsNullOrEmpty(pCliente.Estado))
                cmd.Parameters.Add("@Estado", SqlString.Null).Value = pCliente.Estado;
            else
                cmd.Parameters.Add("@Estado", SqlString.Null);

            if (!string.IsNullOrEmpty(pCliente.CPF_CNPJ))
                cmd.Parameters.Add("@CPF_CNPJ", SqlString.Null).Value = pCliente.CPF_CNPJ;
            else
                cmd.Parameters.Add("@CPF_CNPJ", SqlString.Null);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Delete(int pId)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("DELETE FROM Cliente ");
            sql.Append("WHERE IdCliente = " + pId);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public static List<Cliente> GetName(String Nome)
        {
            StringBuilder sql = new StringBuilder();
            List<Cliente> clientes = new List<Cliente>();

            sql.Append("SELECT * ");
            sql.Append("FROM Cliente ");
            sql.Append("WHERE Nome like '%" + Nome.Trim() + "%'");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                clientes.Add(
                    new Cliente
                    {
                        IdCliente = (int)dr["IdCliente"],
                        Nome = (string)dr["Nome"],
                        Telefone = (string)dr["Telefone"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (string)dr["Endereco"],
                        Bairro = dr.IsDBNull(dr.GetOrdinal("Bairro")) ? "" : (string)dr["Bairro"],
                        Cidade = dr.IsDBNull(dr.GetOrdinal("Cidade")) ? "" : (string)dr["Cidade"],
                        Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? "" : (string)dr["Estado"],
                        CPF_CNPJ = dr.IsDBNull(dr.GetOrdinal("CPF_CNPJ")) ? "" : (string)dr["CPF_CNPJ"]
                    });
            }
            dr.Close();
            return clientes;
        }

        public static Cliente Verificacao(Cliente pCliente)
        {
            StringBuilder sql = new StringBuilder();
            Cliente cliente = new Cliente();
            sql.Append("SELECT * ");
            sql.Append("FROM Cliente ");
            sql.Append("WHERE Nome like '%" + pCliente.Nome.Trim() + "%'");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                cliente = new Cliente
                    {
                        //IdCliente = (int)dr["IdCliente"],
                        Nome = (string)dr["Nome"],
                        Telefone = (string)dr["Telefone"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (string)dr["Endereco"],
                        Bairro = dr.IsDBNull(dr.GetOrdinal("Bairro")) ? "" : (string)dr["Bairro"],
                        Cidade = dr.IsDBNull(dr.GetOrdinal("Cidade")) ? "" : (string)dr["Cidade"],
                        Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? "" : (string)dr["Estado"],
                        CPF_CNPJ = dr.IsDBNull(dr.GetOrdinal("CPF_CNPJ")) ? "" : (string)dr["CPF_CNPJ"]
                    };
            }
            dr.Close();
            if (pCliente.Nome == cliente.Nome && pCliente.Telefone == cliente.Telefone)
            {
                return null;
            }
            else
            {
                return cliente;
            }

            
        }

        public static Cliente GetOne(int pId)
        {
            StringBuilder sql = new StringBuilder();
            Cliente cliente = new Cliente();

            sql.Append("SELECT * ");
            sql.Append("FROM Cliente ");
            sql.Append("WHERE IdCliente = " + pId);

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                cliente.IdCliente = (int)dr["IdCliente"];
                cliente.Nome = (string)dr["Nome"];
                cliente.Telefone = (string)dr["Telefone"];
                cliente.Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (string)dr["Endereco"];
                cliente.Bairro = dr.IsDBNull(dr.GetOrdinal("Bairro")) ? "" : (string)dr["Bairro"];
                cliente.Cidade = dr.IsDBNull(dr.GetOrdinal("Cidade")) ? "" : (string)dr["Cidade"];
                cliente.Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? "" : (string)dr["Estado"];
                cliente.CPF_CNPJ = dr.IsDBNull(dr.GetOrdinal("CPF_CNPJ")) ? "" : (string)dr["CPF_CNPJ"];
            }
            dr.Close();
            return cliente;
        }

        public static List<Cliente> GetAll()
        {
            StringBuilder sql = new StringBuilder();
            List<Cliente> clientes = new List<Cliente>();

            sql.Append("SELECT * ");
            sql.Append("FROM Cliente ");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                clientes.Add(
                    new Cliente
                    {
                        IdCliente = (int)dr["IdCliente"],
                        Nome = (string)dr["Nome"],
                        Telefone = (string)dr["Telefone"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (string)dr["Endereco"],
                        Bairro = dr.IsDBNull(dr.GetOrdinal("Bairro")) ? "" : (string)dr["Bairro"],
                        Cidade = dr.IsDBNull(dr.GetOrdinal("Cidade")) ? "" : (string)dr["Cidade"],
                        Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? "" : (string)dr["Estado"],
                        CPF_CNPJ = dr.IsDBNull(dr.GetOrdinal("CPF_CNPJ")) ? "" : (string)dr["CPF_CNPJ"]
                    });
            }
            dr.Close();
            return clientes;
        }
    }
}
