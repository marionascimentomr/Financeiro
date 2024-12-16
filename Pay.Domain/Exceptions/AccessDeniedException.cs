﻿namespace Pay.Domain.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public override string Message => "Acesso negado. Usuário ou senha inválidos.";
    }
}
