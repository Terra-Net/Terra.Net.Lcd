
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terra.Net.Lcd.Objects
{
    public class TerraClientOptions
    {
        public readonly HttpClient HttpClient;
        public readonly string BaseAddress;
        public TerraClientOptions() : this("https://lcd.terra.dev")
        {

        }
        public TerraClientOptions(HttpClient httpClient) : this(httpClient, "https://lcd.terra.dev")
        {
        }
        public TerraClientOptions(string baseAddress)
        {
            BaseAddress = baseAddress;
            HttpClient = new HttpClient() 
            {
                BaseAddress = new Uri(BaseAddress)
            };
        }

        public TerraClientOptions(HttpClient httpClient, string baseAddress) 
        {
            BaseAddress = baseAddress;
            HttpClient = httpClient;
            HttpClient.BaseAddress = new Uri(BaseAddress);
        }
    }
}
