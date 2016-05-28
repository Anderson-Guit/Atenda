using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Atenda.Data;

namespace Atenda.Web.ViewModel
{
    public class OrcamentoViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }

        public Orcamento Orcamento { get; set; }
    }
}