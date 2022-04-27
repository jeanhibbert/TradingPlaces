using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingPlaces.WebApi.Extensions
{
    public static class GeneralExtensions
    {
        public static bool IsValidTicker(this string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length < 3 || str.Length > 5)
                return false;

            return (str.ToCharArray().All(c => Char.IsLetter(c) || Char.IsNumber(c) || Char.IsUpper(c)));
        }
    }
}
