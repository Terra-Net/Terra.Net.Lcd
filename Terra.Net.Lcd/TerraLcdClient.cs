using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Terra.Net.Lcd.Interfaces;
using Terra.Net.Lcd.Objects;

namespace Terra.Net.Lcd
{
    public class TerraLcdClient : RestClient, ITerraLcdClient
    {
        public TerraLcdClient(TerraClientOptions exchangeOptions) : base("terra", exchangeOptions, null)
        {
        }

        public async Task<TerraBlock> GetBlockByHeight(ulong height, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}