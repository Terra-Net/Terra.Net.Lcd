using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terra.Net.Lcd.Objects;
using Terra.Net.Lcd.Objects.Requests;

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
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<GasPrices>> GetGasPrices(CancellationToken ct = default);
        /// <summary>
        /// Get transactions in mempool
        /// </summary>
        /// <param name="address">if set, returns txs by specified account</param>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<MempoolResponse>> GetMempool(string? address=null, CancellationToken ct = default);
        Task<CallResult<TxOld>> GetTxInMempool(string hash, CancellationToken ct = default);

        Task<CallResult<TxOld>> GetTx(string hash, CancellationToken ct = default);

        Task<CallResult<List<TxOld>>> GetTxList(GetTxListRequest request, CancellationToken ct = default);


        #endregion

        #region Blocks
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// GetBlockByHeight queries block for given height.
        /// </summary>
        /// <returns>A successful response.</returns>
        Task<CallResult<BlockResponseOld>> GetBlockByHeightOld(ulong height, CancellationToken ct = default);
        /// <summary>
        /// Get the latest block
        /// </summary>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<BlockResponseOld>> GetLatestBlockOld(CancellationToken ct = default);
        #endregion

        #region Service
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// GetBlockByHeight queries block for given height.
        /// </summary>
        /// <returns>A successful response.</returns>
        Task<CallResult<BlockResponse>> GetBlockByHeight(ulong height, CancellationToken ct=default);
        /// <summary>
        /// Get the latest block
        /// </summary>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<BlockResponse>> GetLatestBlock(CancellationToken ct = default);

        /// <summary>
        /// GetNodeInfo queries the current node info.
        /// </summary>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<NodeInfo>> GetNodeInfo(CancellationToken ct = default);

        /// <summary>
        /// GetSyncing queries node syncing.
        /// </summary>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<SyncingResponse>> GetSyncing(CancellationToken ct = default);

        /// <summary>
        /// queries validator-set at a given height.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="paginationParams"></param>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<ValidatorSetResponse>> GetValidatorSetByHeight(ulong height, PaginationRequest paginationParams,  CancellationToken ct = default);
        /// <summary>
        /// queries latest validator-set.
        /// </summary>
        /// <param name="paginationParams"></param>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<ValidatorSetResponse>> GetLatestValidatorSet(PaginationRequest paginationParams,  CancellationToken ct = default);
        /// <summary>
        /// Simulate simulates executing a transaction for estimating gas usage.
        /// </summary>
        /// <param name="request">the request type for the Service.Simulate RPC method.</param>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<SimulateResponse>> Simulate(SimulateRequest body, CancellationToken ct = default);

        /// <summary>
        /// GetTxsEvent fetches txs by event.
        /// </summary>
        /// <param name="transactionEvents">the list of transaction event type. required. Event types interact as AND clause in sql WHERE condition</param>
        /// <param name="paginationParams"></param>
        /// <param name="orderBy"></param>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<TxsEventResponse>> GetTxsByEvent(IEnumerable<Event> transactionEvents, PaginationRequest paginationParams = null, CosmosOrdering orderBy = CosmosOrdering.ASC, CancellationToken ct = default);

        /// <summary>
        /// GetTxsEvent fetches txs by event.
        /// </summary>
        /// <param name="conditions"> the list of the string (format: {eventType}.{eventAttribute}={value}, i.g. tx.height=5970053) representation of the transaction event type.
        /// required. Event types interact as AND clause in sql WHERE condition
        /// </param>
        /// <param name="paginationParams"></param>
        /// <param name="orderBy"></param>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<TxsEventResponse>> GetTxsByEvent(IEnumerable<string> conditions, PaginationRequest paginationParams = null, CosmosOrdering orderBy = CosmosOrdering.ASC, CancellationToken ct = default);

        /// <summary>
        /// broadcast transaction.
        /// </summary>
        /// <param name="body">BroadcastTxRequest is the request type for the Service.BroadcastTxRequest
        /// RPC method.</param>
        /// <param name="ct">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        /// <returns></returns>
        Task<CallResult<TxResponse>> BroadcastTx(BroadcastTxRequest body, CancellationToken ct = default);


        #endregion
    }
}
