using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes
{
    class ClienteDB
    {
        private static dataBase getDataBase()
        {
            dataBase db = new dataBase();
            if (!db.DatabaseExists())
            {
                //cria o banco
                db.CreateDatabase();
            }
            return db;
        }

        // salva um carro
        public static void Create(Cliente pCliente)
        {
            dataBase db = getDataBase();

            db.Cliente.InsertOnSubmit(pCliente);

            db.SubmitChanges();
        }

        // salva um carro
        public static void Delete(Cliente pCliente)
        {
            dataBase db = getDataBase();
            var query = from c in db.Cliente
                        where c.IdCliente == pCliente.IdCliente
                        select c;

            db.Cliente.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void Update(Cliente pCliente)
        {
            dataBase db = getDataBase();

            Cliente cliente = (from c in db.Cliente
                               where c.IdCliente == pCliente.IdCliente
                               select c).First(); 

            //trata os campos que serão alterados
            cliente.Nome = pCliente.Nome;
            cliente.Telefone = pCliente.Telefone;
            cliente.Endereco = pCliente.Endereco;
            cliente.Cidade = pCliente.Cidade;
            cliente.Estado = pCliente.Estado;
            cliente.Pais = pCliente.Pais;
            cliente.CPF_CNPJ = pCliente.CPF_CNPJ;

            db.SubmitChanges();
        }

        public static Cliente GetOne(int pId)
        {
            dataBase db = getDataBase();
            var query = from c in db.Cliente
                        where c.IdCliente == pId
                        
                        select c;
                        
                        

            Cliente cliente = query.ToList()[0];
            return cliente;
        }

        public static List<Cliente> GetAll()
        {
            dataBase db = getDataBase();
            var query = from c in db.Cliente
                        select c;

            List<Cliente> clientes = new List<Cliente>(query.AsEnumerable());
            return clientes;
        }

    }
}
