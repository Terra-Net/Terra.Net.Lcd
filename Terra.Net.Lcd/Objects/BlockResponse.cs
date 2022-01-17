using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Terra.Net.Lcd.Objects
{
    /// <summary>
    /// BlockResponse is the response type for the Query/GetBlockByHeight RPC method.
    /// </summary>
    public class BlockResponse
    {
        [JsonProperty("block_id")]
        public BlockId BlockId { get; set; }

        [JsonProperty("block")]
        public Block Block { get; set; }
    }

    public class Block
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("evidence")]
        public BlockEvidence Evidence { get; set; }

        [JsonProperty("last_commit")]
        public Commit LastCommit { get; set; }
    }

    public class BlockEvidence
    {
        [JsonProperty("evidence")]
        public List<EvidenceElement> Evidence { get; set; }
    }

    public class EvidenceElement
    {
        [JsonProperty("duplicate_vote_evidence")]
        public DuplicateVoteEvidence DuplicateVoteEvidence { get; set; }

        [JsonProperty("light_client_attack_evidence")]
        public LightClientAttackEvidence LightClientAttackEvidence { get; set; }
    }

    public class DuplicateVoteEvidence
    {
        [JsonProperty("vote_a")]
        public Vote VoteA { get; set; }

        [JsonProperty("vote_b")]
        public Vote VoteB { get; set; }

        [JsonProperty("total_voting_power")]
        public string TotalVotingPower { get; set; }

        [JsonProperty("validator_power")]
        public string ValidatorPower { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }

    /// <summary>
    /// Vote represents a prevote, precommit, or commit vote from validators for consensus.
    /// </summary>
    public class Vote
    {
        [JsonProperty("type")]
        public VoteType Type { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("block_id")]
        public BlockId BlockId { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; }

        [JsonProperty("validator_index")]
        public int ValidatorIndex { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }

    public class LightClientAttackEvidence
    {
        [JsonProperty("conflicting_block")]
        public ConflictingBlock ConflictingBlock { get; set; }

        [JsonProperty("common_height")]
        public string CommonHeight { get; set; }

        [JsonProperty("byzantine_validators")]
        public List<TendermintValidator> ByzantineValidators { get; set; }

        [JsonProperty("total_voting_power")]
        public string TotalVotingPower { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }

    public class TendermintValidator
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("pub_key")]
        public PubKey PubKey { get; set; }

        [JsonProperty("voting_power")]
        public long VotingPower { get; set; }

        [JsonProperty("proposer_priority")]
        public long ProposerPriority { get; set; }
    }

    public class PubKey
    {
        [JsonProperty("ed25519")]
        public string Ed25519 { get; set; }

        [JsonProperty("secp256k1")]
        public string Secp256K1 { get; set; }
    }

    public class ConflictingBlock
    {
        [JsonProperty("signed_header")]
        public SignedHeader SignedHeader { get; set; }

        [JsonProperty("validator_set")]
        public BlockValidatorSet ValidatorSet { get; set; }
    }

    public class SignedHeader
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("commit")]
        public Commit Commit { get; set; }
    }

    public class Header
    {
        [JsonProperty("version")]
        public BasicBlockInfo Version { get; set; }

        [JsonProperty("chain_id")]
        public string ChainId { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

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

    public class BlockValidatorSet
    {
        [JsonProperty("validators")]
        public List<TendermintValidator> Validators { get; set; }

        [JsonProperty("proposer")]
        public TendermintValidator Proposer { get; set; }

        [JsonProperty("total_voting_power")]
        public long TotalVotingPower { get; set; }
    }
   
    public class BlockResponseOld
    {
        [JsonProperty("block_id")]
        public BlockId BlockId { get; set; }

        [JsonProperty("block")]
        public BlockOld Block { get; set; }
    }
    public class BlockOld
    {
        [JsonProperty("header")]
        public TerraBlockHeader Header { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("evidence")]
        public Evidence Evidence { get; set; }

        [JsonProperty("last_commit")]
        public Commit LastCommit { get; set; }
    }

    /// <summary>
    /// Data contains the set of transactions included in the block
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Txs that will be applied by state @ block.Height+1.
        /// NOTE: not all txs here are valid.  We're just agreeing on the order first.
        /// This means that block.AppHash does not include these txs.
        /// </summary>
        [JsonProperty("txs")]
        public string[] Txs { get; set; }
    }

    public class Evidence
    {
        [JsonProperty("evidence")]
        public object[] EvidenceEvidence { get; set; }
    }

    public class TerraBlockHeader
    {
        [JsonProperty("version")]
        public BasicBlockInfo Version { get; set; }

        [JsonProperty("chain_id")]
        public string ChainId { get; set; }

        [JsonProperty("height")]
        public ulong Height { get; set; }

        [JsonProperty("time")]
        public DateTime Time { get; set; }

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

    public class BlockId
    {
        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("parts")]
        public Parts Parts { get; set; }
    }

    public class Parts
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }

    /// <summary>
    /// Consensus captures the consensus rules for processing a block in the blockchain, including all blockchain data structures and the rules of the application&#39;s state transition machine.
    /// </summary>
    public class BasicBlockInfo
    {

        /// <summary>
        /// Gets or Sets Block
        /// </summary>
        [DataMember(Name = "block", EmitDefaultValue = false)]
        public ulong Block { get; set; }

        /// <summary>
        /// Gets or Sets App
        /// </summary>
        [DataMember(Name = "app", EmitDefaultValue = false)]
        public ulong App { get; set; }

    }

    /// <summary>
    /// Commit contains the evidence that a block was committed by a set of validators.
    /// </summary>
    public class Commit
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("round")]
        public long Round { get; set; }

        [JsonProperty("block_id")]
        public BlockId BlockId { get; set; }

        [JsonProperty("signatures")]
        public CommitSignature[] Signatures { get; set; }
        
    }

    /// <summary>
    /// CommitSig is a part of the Vote included in a Commit.
    /// </summary>
    public class CommitSignature
    {
        [JsonProperty("block_id_flag")]
        public BlockIdFlag BlockIdFlag { get; set; }

        [JsonProperty("validator_address")]
        public string ValidatorAddress { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }

    /// <summary>
    /// Defines BlockIdFlag
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum BlockIdFlag
    {

        /// <summary>
        /// Enum UNKNOWN for value: BLOCK_ID_FLAG_UNKNOWN
        /// </summary>
        [EnumMember(Value = "BLOCK_ID_FLAG_UNKNOWN")]
        Unknown = 0,

        /// <summary>
        /// Enum ABSENT for value: BLOCK_ID_FLAG_ABSENT
        /// </summary>
        [EnumMember(Value = "BLOCK_ID_FLAG_ABSENT")]
        Absent = 1,

        /// <summary>
        /// Enum COMMIT for value: BLOCK_ID_FLAG_COMMIT
        /// </summary>
        [EnumMember(Value = "BLOCK_ID_FLAG_COMMIT")]
        Commit = 2,

        /// <summary>
        /// Enum NIL for value: BLOCK_ID_FLAG_NIL
        /// </summary>
        [EnumMember(Value = "BLOCK_ID_FLAG_NIL")]
        Nil = 3
    }

    /// <summary>
    /// SignedMsgType is a type of signed message in the consensus.   - SIGNED_MSG_TYPE_PREVOTE: Votes  - SIGNED_MSG_TYPE_PROPOSAL: Proposals
    /// </summary>
    /// <value>SignedMsgType is a type of signed message in the consensus.   - SIGNED_MSG_TYPE_PREVOTE: Votes  - SIGNED_MSG_TYPE_PROPOSAL: Proposals</value>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VoteType
    {

        /// <summary>
        /// Enum UNKNOWN for value: SIGNED_MSG_TYPE_UNKNOWN
        /// </summary>
        [EnumMember(Value = "SIGNED_MSG_TYPE_UNKNOWN")]
        Unknown = 0,

        /// <summary>
        /// Enum PREVOTE for value: SIGNED_MSG_TYPE_PREVOTE
        /// </summary>
        [EnumMember(Value = "SIGNED_MSG_TYPE_PREVOTE")]
        Prevote = 1,

        /// <summary>
        /// Enum PRECOMMIT for value: SIGNED_MSG_TYPE_PRECOMMIT
        /// </summary>
        [EnumMember(Value = "SIGNED_MSG_TYPE_PRECOMMIT")]
        Precommit = 2,

        /// <summary>
        /// Enum PROPOSAL for value: SIGNED_MSG_TYPE_PROPOSAL
        /// </summary>
        [EnumMember(Value = "SIGNED_MSG_TYPE_PROPOSAL")]
        Proposal = 3
    }

}
