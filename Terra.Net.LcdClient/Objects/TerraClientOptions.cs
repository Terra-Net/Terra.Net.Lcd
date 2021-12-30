using CryptoExchange.Net.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terra.Net.LcdClient.Objects
{
    public class TerraClientOptions : RestClientOptions
    {
        public TerraClientOptions():this("https://lcd.terra.dev")
        {

        }
        public TerraClientOptions(HttpClient httpClient) : this(httpClient,"https://lcd.terra.dev")
        {

        }
        public TerraClientOptions(string baseAddress) : base(baseAddress)
        {
        }

        public TerraClientOptions(HttpClient httpClient, string baseAddress) : base(httpClient, baseAddress)
        {
        }
    }
}
