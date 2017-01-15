using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Model
{
    public class ExcludeAttribute : ValidationAttribute
    {
        private static char[] _symbols;
        public ExcludeAttribute(char[] symbols)
        {
            _symbols = symbols;
        }
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string strval = value.ToString();
                foreach (var symbol in _symbols)
                {
                    if (strval.Contains(symbol))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}