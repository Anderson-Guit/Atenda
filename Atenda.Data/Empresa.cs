using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.Data
{
    class Empresa
    {

        public int IdEmpresa { get; set; }
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public String CNPJ { get; set; }
        public int Usuario { get; set; }

        public Empresa()
        {

        }

    }
}
