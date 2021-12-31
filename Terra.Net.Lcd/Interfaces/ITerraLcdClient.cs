using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terra.Net.Lcd.Objects;

namespace Terra.Net.Lcd.Interfaces
{
    /// <summary>
    /// https://fcd.terra.dev/swagger
    /// </summary>
    public interface ITerraLcdClient
    {
        #region Legacy txs endpoints
        /// <summary>
        /// Get gas prices
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<CallResult<GasPrices>> GetGasPrices(CancellationToken ct = default);
        /// <summary>
        /// Get transactions in mempool
        /// </summary>
        /// <param name="address">if set, returns txs by specified account</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<CallResult<MempoolResponse>> GetMempool(string? address=null, CancellationToken ct = default);
        #endregion

        #region Blocks
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// GetBlockByHeight queries block for given height.
        /// </summary>
        /// <returns>A successful response.</returns>
        Task<CallResult<BlockResponse>> GetBlockByHeight(ulong height, CancellationToken ct=default);
        Task<CallResult<BlockResponse>> GetLatestBlock(CancellationToken ct = default);
        #endregion
    }
}
