using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes.Dbs
{
    class ProdutoDB
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
        public static void Create(Produto pProduto)
        {
            dataBase db = getDataBase();

            db.Produto.InsertOnSubmit(pProduto);

            db.SubmitChanges();
        }

        // salva um carro
        public static void Delete(Produto pProduto)
        {
            dataBase db = getDataBase();
            var query = from p in db.Produto
                        where p.IdProduto == pProduto.IdProduto
                        select p;

            db.Produto.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void Update(Produto pProduto)
        {
            dataBase db = getDataBase();

            Produto produto = (from p in db.Produto
                               where p.IdProduto == pProduto.IdProduto
                               select p).First();

            //trata os campos que serão alterados
            produto.Nome = pProduto.Nome;
            produto.Descricao = pProduto.Descricao;
            produto.Valor = pProduto.Valor;
            produto.QntdEstoque = pProduto.QntdEstoque;

            db.SubmitChanges();
        }

        public static Produto GetOne(int pId)
        {
            dataBase db = getDataBase();
            var query = from p in db.Produto
                        where p.IdProduto == pId
                        select p;



            Produto produto = query.ToList()[0];
            return produto;
        }

        public static List<Produto> GetAll()
        {
            dataBase db = getDataBase();
            var query = from p in db.Produto
                        select p;

            List<Produto> produtos = new List<Produto>(query.AsEnumerable());
            return produtos;
        }

        public static List<Produto> GetNome(string nomeSearch)
        {
            dataBase db = getDataBase();
            var query = from p in db.Produto
                        where (p.Nome.Contains(nomeSearch))
                        select p;


            List<Produto> produtos = new List<Produto>(query.AsEnumerable());
            return produtos;
        }

    }
}
