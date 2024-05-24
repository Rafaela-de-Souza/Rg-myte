﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyTe.Models.Entities
{
    public class UsuarioViewModel
    {
        [Required]
        [Display(Name = "Nome Completo:")]
        public string? Nome { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("E-mail:")]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Senha:")]
        public string? Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha:")]
        [Compare("Senha")]
        public string? ConfirmarSenha { get; set; }
        public string? Perfil { get; set; }
    }
}
