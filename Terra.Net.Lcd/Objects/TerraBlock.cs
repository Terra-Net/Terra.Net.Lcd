using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terra.Net.Lcd.Objects
{
    
    public partial class TerraBlock
    {
        [JsonProperty("block_id")]
        public BlockId BlockId { get; set; }

        [JsonProperty("block")]
        public Block Block { get; set; }
    }

    public partial class Block
    {
        [JsonProperty("header")]
        public TerraBlockHeader Header { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("evidence")]
        public Evidence Evidence { get; set; }

        [JsonProperty("last_commit")]
        public LastCommit LastCommit { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("txs")]
        public string[] Txs { get; set; }
    }

    public partial class Evidence
    {
        [JsonProperty("evidence")]
        public object[] EvidenceEvidence { get; set; }
    }

    public partial class TerraBlockHeader
    {
        [JsonProperty("version")]
        public Version Version { get; set; }

        [JsonProperty("chain_id")]
        public string ChainId { get; set; }

        [JsonProperty("height")]
        public ulong Height { get; set; }

        [JsonProperty("time")]
        public DateTimeOffset Time { get; set; }

        [JsonProperty("last_block_id")]
        public BlockId LastBlockId { get; set; }

        [JsonProperty("last_commit_hash")]
        public string LastCommitHash { get; set; }

        [JsonProperty("data_hash")]
        public string DataHash { get; set; }

        [JsonProperty("validators_hash")]
        public string ValidatorsHash { get; set; }

        [JsonProperty("next_validators_hash")]
        public string NextValidatorsHash { get; set; }

        [JsonProperty("consensus_hash")]
        public string ConsensusHash { get; set; }

        [JsonProperty("app_hash")]
        public string AppHash { get; set; }

        [JsonProperty("last_results_hash")]
        public string LastResultsHash { get; set; }

        [JsonProperty("evidence_hash")]
        public string EvidenceHash { get; set; }

        [JsonProperty("proposer_address")]
        public string ProposerAddress { get; set; }
    }

    public partial class BlockId
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("parts")]
        public Parts Parts { get; set; }
    }

    public partial class Parts
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }

    public partial class Version
    {
        [JsonProperty("block")]
        public long Block { get; set; }
    }

    public partial class LastCommit
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("round")]
        public long Round { get; set; }

        [JsonProperty("block_id")]
        public BlockId BlockId { get; set; }

        [JsonProperty("signatures")]
        public Signature[] Signatures { get; set; }
    }

    public partial class Signature
    {
        [JsonProperty("block_id_flag")]
        public long BlockIdFlag { get; set; }

        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; }

        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("signature")]
        public string SignatureSignature { get; set; }
    }
}
