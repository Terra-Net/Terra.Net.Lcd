using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace Terra.Net.Lcd.Objects
{

    /// <summary>
    /// Tx is the standard type used for broadcasting transactions.
    /// </summary>
    public class Tx
    {
        /// <summary>
        /// TxBody is the body of a transaction that all signers sign over.
        /// </summary>
        [JsonProperty("body")]
        public TxBody Body { get; set; }

        /// <summary>
        /// AuthInfo describes the fee and signer modes that are used to sign a
        /// transaction.
        /// </summary>
        [JsonProperty("auth_info")]
        public AuthInfo AuthInfo { get; set; }

        /// <summary>
        /// signatures is a list of signatures that matches the length and order of
        /// AuthInfo's signer_infos to allow connecting signature meta information like
        /// public key and signing mode by position.
        /// </summary>
        [JsonProperty("signatures")]
        public List<string> Signatures { get; set; }
    }

    public class TxOld
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("tx")]
        public TxBodyOld TxBody { get; set; }

        [JsonProperty("txhash")]
        public string Txhash { get; set; }

        [JsonProperty("chainId")]
        public string ChainId { get; set; }
    }

    public class TxBodyOld
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public TxValueOld Value { get; set; }
    }
    public class TerraTransactionMessage
    {
        [JsonProperty("type")]
        public string MessageType { get; set; }
        [JsonProperty("value")]
        public Dictionary<string, object> MesasgeValue { get; set; }
    }
    public class TxValueOld : TxValuePostBodyOld
    {
        /// <summary>
        /// timeout is the block height after which this transaction will not be processed by the chain
        /// </summary>
        [JsonProperty("timeout_height")]
        public ulong? TimeoutHeight { get; set; }
    }

    public class TxValuePostBodyOld
    {
        [JsonProperty("msg")]
        public List<TerraTransactionMessage> Messages { get; set; }

        [JsonProperty("fee")]
        public FeeOld Fee { get; set; }

        [JsonProperty("signatures")]
        public List<CommitSignature> Signatures { get; set; }

        [JsonProperty("memo")]
        public string Note { get; set; }
    }

    public class FeeOld
    {
        [JsonProperty("amount")]
        public List<Amount> Amount { get; set; }

        [JsonProperty("gas")]
        public ulong Gas { get; set; }
    }

    /// <summary>
    /// Coin defines a token with a denomination and an amount.
    /// NOTE: The amount field is an Int which implements the custom method signatures required by gogoproto.
    /// </summary>
    public class Amount
    {
        [JsonProperty("denom")]
        public string Denom { get; set; }

        [JsonProperty("amount")]
        public long AmountAmount { get; set; }
    }
    /// <summary>
    /// AuthInfo describes the fee and signer modes that are used to sign a
    /// transaction.
    /// </summary>
    public class AuthInfo
    {
        /// <summary>
        /// signer_infos defines the signing modes for the required signers. The number
        ///and order of elements must match the required signers from TxBody's
        /// messages.The first element is the primary signer and the one which pays
        /// the fee.
        /// </summary>
        [JsonProperty("signer_infos")]
        public List<SignerInfo> SignerInfos { get; set; }

        [JsonProperty("fee")]
        public Fee Fee { get; set; }
    }
    /// <summary>
    /// Fee is the fee and gas limit for the transaction. The first signer is the
    /// primary signer and the one which pays the fee.The fee can be calculated
    /// based on the cost of evaluating the body and doing signature verification
    /// of the signers.This can be estimated via simulation.
    /// </summary>
    public class Fee
    {
        [JsonProperty("amount")]
        public List<Amount> Amount { get; set; }

        [JsonProperty("gas_limit")]
        public ulong GasLimit { get; set; }

        [JsonProperty("payer")]
        public string Payer { get; set; }

        [JsonProperty("granter")]
        public string Granter { get; set; }
    }

    /// <summary>
    /// SignerInfo describes the public key and signing mode of a single top-level
    /// signer.
    /// </summary>
    public class SignerInfo
    {
        [JsonProperty("public_key")]
        public Dictionary<string, object> PublicKey { get; set; }

        [JsonProperty("mode_info")]
        public ModeInfo ModeInfo { get; set; }

        /// <summary>
        /// sequence is the sequence of the account, which describes the
        /// number of committed transactions signed by a given address.It is used to
        /// prevent replay attacks.
        /// </summary>
        [JsonProperty("sequence")]
        public ulong Sequence { get; set; }
    }

    /// <summary>
    /// ModeInfo describes the signing mode of a single or nested multisig signer.
    /// </summary>
    public class ModeInfo
    {
        [JsonProperty("single")]
        public SingleMode Single { get; set; }

        [JsonProperty("multi")]
        public Multi Multi { get; set; }
    }

    /// <summary>
    /// mode is the signing mode of the single signer
    /// </summary>
    public class SingleMode
    {
        [JsonProperty("mode")]
        public SignMode Mode { get; set; }
    }

    /// <summary>
    /// SignMode represents a signing mode with its own security guarantees.
    /// 
    ///  - SIGN_MODE_UNSPECIFIED: SIGN_MODE_UNSPECIFIED specifies an unknown signing mode and will be
    /// rejected
    ///  - SIGN_MODE_DIRECT: SIGN_MODE_DIRECT specifies a signing mode which uses SignDoc and is
    /// verified with raw bytes from Tx
    ///  - SIGN_MODE_TEXTUAL: SIGN_MODE_TEXTUAL is a future signing mode that will verify some
    /// human-readable textual representation on top of the binary representation
    /// from SIGN_MODE_DIRECT
    ///  - SIGN_MODE_LEGACY_AMINO_JSON: SIGN_MODE_LEGACY_AMINO_JSON is a backwards compatibility mode which uses
    /// Amino JSON and will be removed in the future
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SignMode
    {

        /// <summary>
        /// Enum UNSPECIFIED for value: SIGN_MODE_UNSPECIFIED
        /// </summary>
        [EnumMember(Value = "SIGN_MODE_UNSPECIFIED")]
        Unspecified,

        /// <summary>
        /// Enum DIRECT for value: SIGN_MODE_DIRECT
        /// </summary>
        [EnumMember(Value = "SIGN_MODE_DIRECT")]
        Direct,

        /// <summary>
        /// Enum TEXTUAL for value: SIGN_MODE_TEXTUAL
        /// </summary>
        [EnumMember(Value = "SIGN_MODE_TEXTUAL")]
        Textual,

        /// <summary>
        /// Enum LEGACYAMINOJSON for value: SIGN_MODE_LEGACY_AMINO_JSON
        /// </summary>
        [EnumMember(Value = "SIGN_MODE_LEGACY_AMINO_JSON")]
        LegacyAminoJSON
    }

    public class Multi
    {
        [JsonProperty("bitarray")]
        public Bitarray Bitarray { get; set; }

        /// <summary>
        /// mode_infos is the corresponding modes of the signers of the multisig which could include nested multisig public keys
        /// </summary>
        [JsonProperty("mode_infos")]
        public List<ModeInfo> ModeInfos { get; set; }
    }

    /// <summary>
    /// CompactBitArray is an implementation of a space efficient bit array.
    /// This is used to ensure that the encoded data takes up a minimal amount of
    /// space after proto encoding.
    /// This is not thread safe, and is not intended for concurrent usage.
    /// </summary>
    public class Bitarray
    {
        [JsonProperty("extra_bits_stored")]
        public long ExtraBitsStored { get; set; }

        [JsonProperty("elems")]
        public string Elems { get; set; }
    }

    public class TxBody
    {
        /// <summary>
        /// messages is a list of messages to be executed. The required signers of
        /// those messages define the number and order of elements in AuthInfo's
        /// signer_infos and Tx's signatures. Each required signer address is added to
        /// the list only the first time it occurs.
        /// By convention, the first required signer (usually from the first message)
        /// is referred to as the primary signer and pays the fee for the whole
        /// transaction.
        /// </summary>
        [JsonProperty("messages")]
        public List<Dictionary<string,object>> Messages { get; set; }
        /// <summary>
        /// memo is any arbitrary note/comment to be added to the transaction.
        /// WARNING: in clients, any publicly exposed text should not be called memo,
        /// but should be called note instead(see https://github.com/cosmos/cosmos-sdk/issues/9122).
        /// </summary>
        [JsonProperty("memo")]
        public string Note { get; set; }

        /// <summary>
        /// timeout is the block height after which this transaction will not
        /// be processed by the chain
        /// </summary>
        [JsonProperty("timeout_height")]
        public ulong TimeoutHeight { get; set; }

        /// <summary>
        /// extension_options are arbitrary options that can be added by chains
        /// when the default options are not sufficient. If any of these are present
        /// and can't be handled, they will be ignored
        /// </summary>
        [JsonProperty("extension_options")]
        public List<Dictionary<string,object>> ExtensionOptions { get; set; }

        [JsonProperty("non_critical_extension_options")]
        public List<Dictionary<string,object>> NonCriticalExtensionOptions { get; set; }
    }

    /// <summary>
    /// `Any` contains an arbitrary serialized protocol buffer message along with a
    /// URL that describes the type of the serialized message.
    /// 
    /// Protobuf library provides support to pack/unpack Any values in the form
    /// of utility functions or additional generated methods of the Any type.
    /// 
    /// Example 1: Pack and unpack a message in C++.
    /// 
    ///     Foo foo = ...;
    ///     Any any;
    ///     any.PackFrom(foo);
    ///     ...
    ///     if (any.UnpackTo(&foo)) {
    ///       ...
    ///     }
    /// 
    /// Example 2: Pack and unpack a message in Java.
    /// 
    ///     Foo foo = ...;
    ///     Any any = Any.pack(foo);
    ///     ...
    ///     if (any.is(Foo.class)) {
    ///       foo = any.unpack(Foo.class);
    ///     }
    /// 
    ///  Example 3: Pack and unpack a message in Python.
    /// 
    ///     foo = Foo(...)
    ///     any = Any()
    ///     any.Pack(foo)
    ///     ...
    ///     if any.Is(Foo.DESCRIPTOR):
    ///       any.Unpack(foo)
    ///       ...
    /// 
    ///  Example 4: Pack and unpack a message in Go
    /// 
    ///      foo := &pb.Foo{...}
    ///      any, err := ptypes.MarshalAny(foo)
    ///      ...
    ///      foo := &pb.Foo{}
    ///      if err := ptypes.UnmarshalAny(any, foo); err != nil {
    ///        ...
    ///      }
    /// 
    /// The pack methods provided by protobuf library will by default use
    /// 'type.googleapis.com/full.type.name' as the type URL and the unpack
    /// methods only use the fully qualified type name after the last '/'
    /// in the type URL, for example "foo.bar.com/x/y.z" will yield type
    /// name "y.z".
    /// 
    /// 
    /// JSON
    /// ====
    /// The JSON representation of an `Any` value uses the regular
    /// representation of the deserialized, embedded message, with an
    /// additional field `@type` which contains the type URL. Example:
    /// 
    ///     package google.profile;
    ///     message Person {
    ///       string first_name = 1;
    ///       string last_name = 2;
    ///     }
    /// 
    ///     {
    ///       "@type": "type.googleapis.com/google.profile.Person",
    ///       "firstName": <string>,
    ///       "lastName": <string>
    ///     }
    /// 
    /// If the embedded message type is well-known and has a custom JSON
    /// representation, that representation will be embedded adding a field
    /// `value` which holds the custom JSON in addition to the `@type`
    /// field. Example (for message [google.protobuf.Duration][]):
    /// 
    ///     {
    ///       "@type": "type.googleapis.com/google.protobuf.Duration",
    ///       "value": "1.212s"
    ///     }
    /// </summary>
    public class ProtoBufMessage
    {
        /// <summary>
        /// A URL/resource name that uniquely identifies the type of the serializedprotocol buffer message. This string must contain at least
        /// one "/" character. The last segment of the URL's path must represent
        /// the fully qualified name of the type (as in
        /// `path/google.protobuf.Duration`). The name should be in a canonical form
        /// (e.g., leading "." is not accepted).
        /// 
        /// In practice, teams usually precompile into the binary all types that they
        /// expect it to use in the context of Any. However, for URLs which use the
        /// scheme `http`, `https`, or no scheme, one can optionally set up a type
        /// server that maps type URLs to message definitions as follows:
        /// 
        /// * If no scheme is provided, `https` is assumed.
        /// * An HTTP GET on the URL must yield a [google.protobuf.Type][]
        ///   value in binary format, or produce an error.
        /// * Applications are allowed to cache lookup results based on the
        ///   URL, or have them precompiled into a binary to avoid any
        ///   lookup. Therefore, binary compatibility needs to be preserved
        ///   on changes to types. (Use versioned type names to manage
        ///   breaking changes.)
        /// 
        /// Note: this functionality is not currently available in the official
        /// protobuf release, and it is not used for type URLs beginning with
        /// type.googleapis.com.
        /// 
        /// Schemes other than `http`, `https` (or the empty scheme) might be
        /// used with implementation specific semantics.
        /// </summary>
        [JsonProperty("type_url")]
        public string TypeUrl { get; set; }

        /// <summary>
        /// Must be a valid serialized protocol buffer of the above specified type.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }

}
