using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Helpers
{
    public class CPFHelper
    {
        public static bool IsValid(string cpf)
        {
            // Remover caracteres não numéricos do CPF
            cpf = Regex.Replace(cpf, @"[^\d]", "");

            // Verificar se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verificar se todos os dígitos são iguais (CPF inválido)
            bool allDigitsEqual = true;
            for (int i = 1; i < cpf.Length; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    allDigitsEqual = false;
                    break;
                }
            }
            if (allDigitsEqual)
                return false;

            // Calcular o primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);
            int resto = (soma % 11);
            if (resto < 2)
            {
                if (cpf[9] - '0' != 0)
                    return false;
            }
            else
            {
                if (cpf[9] - '0' != 11 - resto)
                    return false;
            }

            // Calcular o segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);
            resto = (soma % 11);
            if (resto < 2)
            {
                if (cpf[10] - '0' != 0)
                    return false;
            }
            else
            {
                if (cpf[10] - '0' != 11 - resto)
                    return false;
            }

            return true;
        }
    }
}