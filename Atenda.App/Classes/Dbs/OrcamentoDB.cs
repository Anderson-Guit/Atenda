using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes.Dbs
{
    class OrcamentoDB
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
        public static void Create(Orcamento pOrcamento)
        {
            dataBase db = getDataBase();

            db.Orcamento.InsertOnSubmit(pOrcamento);

            db.SubmitChanges();
        }

        // salva um carro
        public static void Delete(Orcamento pOrcamento)
        {
            dataBase db = getDataBase();
            var query = from o in db.Orcamento
                        where o.IdOrcamento == pOrcamento.IdOrcamento
                        select o;

            db.Orcamento.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }

        public static void Update(Orcamento pOrcamento)
        {
            dataBase db = getDataBase();

            Orcamento orcamento = (from o in db.Orcamento
                                    where o.IdOrcamento == pOrcamento.IdOrcamento
                                    select o).First();

            //trata os campos que serão alterados
            orcamento.Servico = pOrcamento.Servico;
            orcamento.ValorServico = pOrcamento.ValorServico;
            orcamento.IdProduto = pOrcamento.IdProduto;
            orcamento.ValorTotal = pOrcamento.ValorTotal;

            db.SubmitChanges();
        }

        public static Orcamento GetOne(int pId)
        {
            dataBase db = getDataBase();
            var query = from o in db.Orcamento
                        where o.IdOrcamento == pId
                        select o;



            Orcamento orcamento = query.ToList()[0];
            return orcamento;
        }

        public static List<Orcamento> GetAll()
        {
            dataBase db = getDataBase();
            var query = from o in db.Orcamento
                        select o;

            List<Orcamento> orcamentos = new List<Orcamento>(query.AsEnumerable());
            return orcamentos;
        }

    }
}
