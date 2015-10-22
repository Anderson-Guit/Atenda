﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atenda.App.Classes
{
    [Table(Name = "Cliente")]
    public class Cliente
    {

            [Column(IsPrimaryKey = true, IsDbGenerated = true)]
            public int IdCliente { get; set; }

            [Column(CanBeNull = false)]
            public string Nome { get; set; }

            [Column(CanBeNull = false)]
            public string Telefone { get; set; }

            [Column(CanBeNull = true)]
            public string Endereco { get; set; }

            [Column(CanBeNull = true)]
            public string Cidade { get; set; }

            [Column(CanBeNull = true)]
            public string Estado { get; set; }

            [Column(CanBeNull = true)]
            public string Pais { get; set; }

            [Column(CanBeNull = true)]
            public string CPF_CNPJ { get; set; }

        }

    }
