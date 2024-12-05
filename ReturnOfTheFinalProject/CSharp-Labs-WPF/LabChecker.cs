using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Labs_WPF
{
    public static class LabChecker
    {
        public static bool IsIntNumber(string number)
        {
            return int.TryParse(number, out var result) && !(number[0] == '0' && number.Length != 1);
        }


        public static bool IsUint(string number, uint maxValue)
        {
            return uint.TryParse(number, out var result)
                && !(number[0] == '0' && number.Length != 1)
                && uint.Parse(number) <= maxValue;
        }

        public static bool IsByte(string number, byte maxValue)
        {
            return byte.TryParse(number, out var result) 
                && !(number[0] == '0' && number.Length != 1) 
                && byte.Parse(number) <= maxValue;
        }
    }
}
