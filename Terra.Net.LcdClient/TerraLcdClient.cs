using CryptoExchange.Net;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Objects;
using Terra.Net.LcdClient.Interfaces;
using Terra.Net.LcdClient.Objects;

namespace Terra.Net.LcdClient
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