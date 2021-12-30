
using Microsoft.Extensions.Logging;
using Terra.Net.Lcd.Helpers;
using Terra.Net.Lcd.Interfaces;
using Terra.Net.Lcd.Objects;

namespace Terra.Net.Lcd
{
    public class TerraLcdClient : BaseRestClient, ITerraLcdClient
    {
        #region Endpoints
        private const string GetBlockByHeightUrl = "/blocks/{height}";
        #endregion
        public TerraLcdClient(TerraClientOptions exchangeOptions, ILogger<TerraLcdClient> logger) : base(exchangeOptions, logger)
        {
        }

        public async Task<TerraBlock> GetBlockByHeight(ulong height, CancellationToken ct = default)
        {
            return await Get<TerraBlock>(GetBlockByHeightUrl.FillPathParameters(height.ToString()), null, ct);
        }
        public async Task<TerraBlock> GetLatestBlock(CancellationToken ct = default)
        {
            return await Get<TerraBlock>(GetBlockByHeightUrl.FillPathParameters("latest"), null, ct);
        }
    }
}