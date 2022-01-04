using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terra.Net.Lcd.Objects
{

    public class Tx
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("tx")]
        public TxBody TxBody { get; set; }

        [JsonProperty("txhash")]
        public string Txhash { get; set; }

        [JsonProperty("chainId")]
        public string ChainId { get; set; }
    }

    public partial class TxBody
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public TxValue Value { get; set; }
    }
    public class TerraTransactionMessage
    {
        [JsonProperty("type")]
        public string MessageType { get; set; }
        [JsonProperty("value")]
        public Dictionary<string, object> MesasgeValue { get; set; }
    }
    public partial class TxValue
    {
        [JsonProperty("msg")]
        public List<TerraTransactionMessage> Messages { get; set; }

        [JsonProperty("fee")]
        public Fee Fee { get; set; }

        [JsonProperty("signatures")]
        public List<CommitSignature> Signatures { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }

        [JsonProperty("timeout_height")]
        public ulong TimeoutHeight { get; set; }
    }

    public partial class Fee
    {
        [JsonProperty("amount")]
        public List<Amount> Amount { get; set; }

        [JsonProperty("gas")]
        public ulong Gas { get; set; }
    }

    public partial class Amount
    {
        [JsonProperty("denom")]
        public string Denom { get; set; }

        [JsonProperty("amount")]
        public long AmountAmount { get; set; }
    }

}
