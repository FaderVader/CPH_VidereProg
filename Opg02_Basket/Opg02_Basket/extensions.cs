using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg02_Basket
{
    public static class Extensions
    {   
        public static string ConvertDecToCurr(this decimal input)
        {
            //string formatter = "{0:#.#,00}";
            //return string.Format(formatter, input);

            string decToString = input.ToString();
            return decToString.Replace('.', ',');
        }
    }
}
