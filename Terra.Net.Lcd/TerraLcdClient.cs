
using Terra.Net.Lcd.Helpers;
using Terra.Net.Lcd.Interfaces;
using Terra.Net.Lcd.Objects;

namespace Terra.Net.Lcd
{
    public class TerraLcdClient : TerraRestClient, ITerraLcdClient
    {
        #region Endpoints
        private const string GetBlockByHeightUrl = "/blocks/{height}";
        #endregion
        public TerraLcdClient(TerraClientOptions exchangeOptions) : base(exchangeOptions)
        {
        }

        public async Task<TerraBlock> GetBlockByHeight(ulong height, CancellationToken ct = default)
        {
            return await Get<TerraBlock>(GetBlockByHeightUrl.FillPathParameters(height.ToString()), null, ct);
        }
    }
}