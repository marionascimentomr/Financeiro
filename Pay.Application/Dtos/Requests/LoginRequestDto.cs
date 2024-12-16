﻿using System.ComponentModel.DataAnnotations;

namespace Pay.Application.Dtos.Requests
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Informe o email de acesso.")]
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha de acesso.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@#$%^&+=])(?!.*\s).{8,}$",
            ErrorMessage = "Informe uma senha forte com pelo menos 8 caracteres, Exemplo: @Admin1234")]
        public string Password { get; set; }
    }
}
