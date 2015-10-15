using System;
using Atenda.Conn;
using Atenda.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.Repository
{
    public class ClienteRepository
    {
        public void Create(Cliente pCliente)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("INSERT INTO Cliente (Nome, Telefone, Endereco, Bairro, Cidade, Estado, Pais, CPF_CNPJ)");
            sql.Append("VALUES(@Nome, @Telefone, @Endereco, @Bairro, @Cidade, @Estado, @Pais, @CPF_CNPJ)");

            cmd.Parameters.AddWithValue("@Nome", (pCliente.Nome));
            cmd.Parameters.AddWithValue("@Telefone", pCliente.Telefone);
            cmd.Parameters.AddWithValue("@Endereco", pCliente.Endereco);
            cmd.Parameters.AddWithValue("@Bairro", pCliente.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", pCliente.Cidade);
            cmd.Parameters.AddWithValue("@Estado", pCliente.Estado);
            cmd.Parameters.AddWithValue("@Pais", pCliente.Pais);
            cmd.Parameters.AddWithValue("@CPF_CNPJ", pCliente.CPF_CNPJ);

            cmd.CommandText = sql.ToString();
            SqlConn.CommandPersist(cmd);
        }

        public void Update(Cliente pCliente)
        {
            StringBuilder sql = new StringBuilder();
            SqlCommand cmd = new SqlCommand();

            sql.Append("UPDATE Cliente SET Nome=@Nome, Telefone=@Telefone, Endereco=@Endereco, Bairro=@Bairro, Cidade=@Cidade, Estado=@Estado, Pais=@Pais, CPF_CNPJ=@CPF_CNPJ");
            sql.Append(" WHERE IdCliente = " + pCliente.IdCliente);

            cmd.Parameters.AddWithValue("@Nome", pCliente.Nome);
            cmd.Parameters.AddWithValue("@Telefone", pCliente.Telefone);
            cmd.Parameters.AddWithValue("@Endereco", pCliente.Endereco);
            cmd.Parameters.AddWithValue("@Bairro", pCliente.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", pCliente.Cidade);
            cmd.Parameters.AddWithValue("@Estado", pCliente.Estado);
            cmd.Parameters.AddWithValue("@Pais", pCliente.Pais);
            cmd.Parameters.AddWithValue("@CPF_CNPJ", pCliente.CPF_CNPJ);

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

        public static Cliente GetName(String Nome)
        {
            StringBuilder sql = new StringBuilder();
            Cliente cliente = new Cliente();

            sql.Append("SELECT * ");
            sql.Append("FROM Cliente ");
            sql.Append("WHERE Nome = '" + Nome + "'");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                cliente.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                cliente.Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"];
                cliente.Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (String)dr["Telefone"];
                cliente.Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (String)dr["Endereco"];
                cliente.Bairro = dr.IsDBNull(dr.GetOrdinal("Bairro")) ? "" : (String)dr["Bairro"];
                cliente.Cidade = dr.IsDBNull(dr.GetOrdinal("Cidade")) ? "" : (String)dr["Cidade"];
                cliente.Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? "" : (String)dr["Estado"];
                cliente.Pais = dr.IsDBNull(dr.GetOrdinal("Pais")) ? "" : (String)dr["Pais"];
                cliente.CPF_CNPJ = dr.IsDBNull(dr.GetOrdinal("CPF_CNPJ")) ? "" : (String)dr["CPF_CNPJ"];
            }
            dr.Close();
            return cliente;
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
                cliente.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                cliente.Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"];
                cliente.Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (String)dr["Telefone"];
                cliente.Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (String)dr["Endereco"];
                cliente.Bairro = dr.IsDBNull(dr.GetOrdinal("Bairro")) ? "" : (String)dr["Bairro"];
                cliente.Cidade = dr.IsDBNull(dr.GetOrdinal("Cidade")) ? "" : (String)dr["Cidade"];
                cliente.Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? "" : (String)dr["Estado"];
                cliente.Pais = dr.IsDBNull(dr.GetOrdinal("Pais")) ? "" : (String)dr["Pais"];
                cliente.CPF_CNPJ = dr.IsDBNull(dr.GetOrdinal("CPF_CNPJ")) ? "" : (String)dr["CPF_CNPJ"];
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
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"],
                        Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (String)dr["Telefone"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (String)dr["Endereco"],
                        Bairro = dr.IsDBNull(dr.GetOrdinal("Bairro")) ? "" : (String)dr["Bairro"],
                        Cidade = dr.IsDBNull(dr.GetOrdinal("Cidade")) ? "" : (String)dr["Cidade"],
                        Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? "" : (String)dr["Estado"],
                        Pais = dr.IsDBNull(dr.GetOrdinal("Pais")) ? "" : (String)dr["Pais"],
                        CPF_CNPJ = dr.IsDBNull(dr.GetOrdinal("CPF_CNPJ")) ? "" : (String)dr["CPF_CNPJ"]


                    });
            }
            dr.Close();
            return clientes;
        }

        public static List<Cliente> GetBySearch(String Nome)
        {
            StringBuilder sql = new StringBuilder();
            List<Cliente> cliente = new List<Cliente>();

            sql.Append("SELECT * ");
            sql.Append("FROM Curso ");

            SqlDataReader dr = SqlConn.Get(sql.ToString());

            while (dr.Read())
            {
                cliente.Add(
                    new Cliente
                    {
                        IdCliente = (int)dr["IdCliente"],
                        Nome = dr.IsDBNull(dr.GetOrdinal("Nome")) ? "" : (String)dr["Nome"],
                        Telefone = dr.IsDBNull(dr.GetOrdinal("Telefone")) ? "" : (String)dr["Telefone"],
                        Endereco = dr.IsDBNull(dr.GetOrdinal("Endereco")) ? "" : (String)dr["Endereco"],
                        Bairro = dr.IsDBNull(dr.GetOrdinal("Bairro")) ? "" : (String)dr["Bairro"],
                        Cidade = dr.IsDBNull(dr.GetOrdinal("Cidade")) ? "" : (String)dr["Cidade"],
                        Estado = dr.IsDBNull(dr.GetOrdinal("Estado")) ? "" : (String)dr["Estado"],
                        Pais = dr.IsDBNull(dr.GetOrdinal("Pais")) ? "" : (String)dr["Pais"],
                        CPF_CNPJ = dr.IsDBNull(dr.GetOrdinal("CPF_CNPJ")) ? "" : (String)dr["CPF_CNPJ"]
                    });
            }

            dr.Close();

            return cliente;
        }
    }
}
