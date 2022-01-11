
using Microsoft.Extensions.Logging;
using Terra.Net.Lcd.Helpers;
using Terra.Net.Lcd.Interfaces;
using Terra.Net.Lcd.Objects;
using Terra.Net.Lcd.Objects.Requests;

namespace Terra.Net.Lcd
{
    public class TerraLcdClient : BaseRestClient, ITerraLcdClient
    {
        #region Endpoints
        private const string GetBlockByHeightOldUrl = "/blocks/{}";
        private const string GetGasPricesUrl = "/v1/txs/gas_prices";
        private const string GetMempoolUrl = "/v1/mempool?account=";
        private const string GetTxInMempoolUrl = "/v1/mempool/{}";
        private const string GetTxUrl = "/v1/tx/{}";
        private const string GetTransactionsListUrl = "/v1/tx";
        private const string GetBlockByHeightUrl = "/cosmos/base/tendermint/v1beta1/blocks/{}";
        private const string GetNodeInfoUrl = "/cosmos/base/tendermint/v1beta1/node_info";
        private const string GetSyncingUrl = "/cosmos/base/tendermint/v1beta1/syncing";
        private const string GetValidatorSetUrl = "/cosmos/base/tendermint/v1beta1/validatorsets/{}";
        private const string SimulateUrl = "/cosmos/tx/v1beta1/simulate";





        #endregion
        public TerraLcdClient(TerraClientOptions exchangeOptions, ILogger<TerraLcdClient> logger) : base(exchangeOptions, logger)
        {
        }
        #region Blocks
        public async Task<CallResult<BlockResponseOld>> GetBlockByHeightOld(ulong height, CancellationToken ct = default)
        {
            return await Get<BlockResponseOld>(GetBlockByHeightOldUrl.FillPathParameters(height.ToString()), null, ct);
        }

        public async Task<CallResult<BlockResponseOld>> GetLatestBlockOld(CancellationToken ct = default)
        {
            return await Get<BlockResponseOld>(GetBlockByHeightOldUrl.FillPathParameters("latest"), null, ct);
        }
        #endregion

        #region Legacy tx endpoints
        public async Task<CallResult<GasPrices>> GetGasPrices(CancellationToken ct = default)
        {
            var data = await Get<Dictionary<string, ulong>>(GetGasPricesUrl, ct: ct);
            if (data)
            {
                return new CallResult<GasPrices>(new GasPrices(data.Result));

            }
            else
            {
                return new CallResult<GasPrices>(default(GasPrices), data.Error);
            }
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="address"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<CallResult<MempoolResponse>> GetMempool(string? address = null, CancellationToken ct = default)
        {
            return await Get<MempoolResponse>(GetMempoolUrl + address, ct: ct);
        }
        public Task<CallResult<Tx>> GetTxInMempool(string hash, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<CallResult<Tx>> GetTx(string hash, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public Task<CallResult<List<Tx>>> GetTxList(GetTxListRequest request, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }
        #endregion  // Legacy tx endpoints

        #region Service

        /// <inheritdoc />
        public async Task<CallResult<BlockResponse>> GetBlockByHeight(ulong height, CancellationToken ct = default)
        {
            return await Get<BlockResponse>(GetBlockByHeightUrl.FillPathParameters(height.ToString()), null, ct);
        }

        /// <inheritdoc />
        public async Task<CallResult<BlockResponse>> GetLatestBlock(CancellationToken ct = default)
        {
            return await Get<BlockResponse>(GetBlockByHeightUrl.FillPathParameters("latest"), null, ct);
        }
        
        /// <inheritdoc />
        public async Task<CallResult<NodeInfo>> GetNodeInfo(CancellationToken ct = default)
        {
            return await Get<NodeInfo>(GetNodeInfoUrl, null, ct);
        }

        /// <inheritdoc />
        public async Task<CallResult<SyncingResponse>> GetSyncing(CancellationToken ct = default)
        {
            return await Get<SyncingResponse>(GetSyncingUrl, null, ct);
        }

        /// <inheritdoc />
        public Task<CallResult<ValidatorSetResponse>> GetValidatorSetByHeight(ulong height, PaginationRequest? paginationParams = null, CancellationToken ct = default) 
            => GetValidatorSet(height.ToString(), paginationParams, ct);

        /// <inheritdoc />
        public Task<CallResult<ValidatorSetResponse>> GetLatestValidatorSet(PaginationRequest? paginationParams = null, CancellationToken ct = default)
            => GetValidatorSet("latest", paginationParams, ct);

        private async Task<CallResult<ValidatorSetResponse>> GetValidatorSet(string height, PaginationRequest? paginationParams, CancellationToken ct = default)
        {
            var p = paginationParams?.AsDictionary();
            return await Get<ValidatorSetResponse>(GetValidatorSetUrl.FillPathParameters(height), p, ct);
        }



        #endregion // end of Service reg
    }
}