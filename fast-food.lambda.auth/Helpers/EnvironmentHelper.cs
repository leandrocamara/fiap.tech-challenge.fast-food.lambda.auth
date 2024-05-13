using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class EnvironmentHelper
    {
        public static string GetRequiredEnvironmentVariable(string variableName)
        {
            string value = Environment.GetEnvironmentVariable(variableName);
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException($"A variável de ambiente {variableName} não foi definida.");
            }
            return value;
        }

    }
}
