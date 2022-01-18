using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects
{
    /// <summary>
    /// SimulateResponse is the response type for the
    /// Service.SimulateRPC method.
    /// </summary>
    public class SimulateResponse
    {
        /// <summary>
        /// gas_info is the information about gas used in the simulation.
        /// </summary>
        [JsonProperty("gas_info")]
        public GasInfo GasInfo { get; set; }

        /// <summary>
        /// result is the result of the simulation.
        /// </summary>
        [JsonProperty("result")]
        public SimulateResponseResult Result { get; set; }
    }

    public class GasInfo
    {
        /// <summary>
        /// GasWanted is the maximum units of work we allow this tx to perform.
        /// </summary>
        [JsonProperty("gas_wanted")]
        public ulong GasWanted { get; set; }

        /// <summary>
        /// GasUsed is the amount of gas actually consumed.
        /// </summary>
        [JsonProperty("gas_used")]
        public ulong GasUsed { get; set; }
    }

    public class SimulateResponseResult
    {
        /// <summary>
        /// Data is any data returned from message or handler execution. It MUST be
        /// length prefixed in order to separate data from multiple message executions.
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// Log contains the log information from message or handler execution.
        /// </summary>
        [JsonProperty("log")]
        public string Log { get; set; }
        
        /// <summary>
        /// Events contains a slice of Event objects that were emitted during message
        /// or handler execution.
        /// </summary>
        [JsonProperty("events")]
        public List<Event> Events { get; set; }
    }

    /// <summary>
    /// the request type for the Service.ComputeTax RPC method.
    /// </summary>
    public class EstimateFeeResponse
    {
        [JsonProperty("tax_amount")]
        public List<Amount> TaxAmount { get; set; }
    }
}