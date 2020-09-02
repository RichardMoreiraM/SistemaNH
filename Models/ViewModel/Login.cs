﻿using System.ComponentModel.DataAnnotations;


namespace SistemaNH.Models.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "Identificador es requerido!")]
        public string Id { get; set; }


        [Required(ErrorMessage = "Clave es requerida!")]
        public string Clave { get; set; }
    }
}
