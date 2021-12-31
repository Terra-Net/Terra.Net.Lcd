using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terra.Net.Lcd.Objects
{
    public class GasPrices
    {
        public readonly Dictionary<string, ulong> Prices;

        public GasPrices(Dictionary<string, ulong> data)
        {
            Prices = data ?? throw new ArgumentNullException(nameof(data));
        }
    }
}
