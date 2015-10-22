﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Atenda.Data
{
    public class Usuario
    {

        public int IdUsuario { get; set; }

        [Display(Name = "Nome", Description = "Informe o Nome do Cliente.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Senha", Description = "Informe a Senha do Usuário.")]
        [Required(ErrorMessage = "Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirme a Senha", Description = "Repita a Senha.")]
        [Compare("Senha", ErrorMessage = "As senha esta diferente!")]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; }

        [Display(Name = "Administrador", Description = "Define Usuário Simples ou Administrador.")]
        public bool Adm { get; set; }
        
        public Usuario()
        {

        }

    }

    public class Login
    {
        [Display(Name = "Nome", Description = "Informe o Nome do Usuario.")]
        [Required(ErrorMessage = "Digite o Nome de Usuario!")]
        public string Nome { get; set; }

        [Display(Name = "Senha", Description = "Informe a Senha do Usuário.")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Digite a Senha!")]
        public string Senha { get; set; }

        [Display(Name = "Lembre-me", Description = "Lembrar do Login")]
        public bool LembreMe { get; set; }
    }
}
