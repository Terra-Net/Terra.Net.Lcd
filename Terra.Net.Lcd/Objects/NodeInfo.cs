using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects
{
    /// <summary>
    /// the request type for the Query/GetNodeInfo RPC method.
    /// </summary>
    public class NodeInfo
    {
        [JsonProperty("default_node_info")]
        public DefaultNodeInfo DefaultNodeInfo { get; set; }

        [JsonProperty("application_version")]
        public ApplicationVersion ApplicationVersion { get; set; }
    }

    public class ApplicationVersion
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("app_name")]
        public string AppName { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("git_commit")]
        public string GitCommit { get; set; }

        [JsonProperty("build_tags")]
        public string BuildTags { get; set; }

        [JsonProperty("go_version")]
        public string GoVersion { get; set; }

        [JsonProperty("build_deps")]
        public List<BuildDep> BuildDeps { get; set; }

        [JsonProperty("cosmos_sdk_version")]
        public string CosmosSdkVersion { get; set; }
    }

    public class BuildDep
    {
        /// <summary>
        /// module path
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        /// module version
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// checksum
        /// </summary>
        [JsonProperty("sum")]
        public string Sum { get; set; }
    }

    public class DefaultNodeInfo
    {
        [JsonProperty("protocol_version")]
        public ProtocolVersion ProtocolVersion { get; set; }

        [JsonProperty("default_node_id")]
        public string DefaultNodeId { get; set; }

        [JsonProperty("listen_addr")]
        public string ListenAddr { get; set; }

        [JsonProperty("network")]
        public string Network { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("channels")]
        public string Channels { get; set; }

        [JsonProperty("moniker")]
        public string Moniker { get; set; }

        [JsonProperty("other")]
        public OtherNodeInfo Other { get; set; }
    }

    public class OtherNodeInfo
    {
        [JsonProperty("tx_index")]
        public string TxIndex { get; set; }

        [JsonProperty("rpc_address")]
        public string RpcAddress { get; set; }
    }

    public class ProtocolVersion
    {
        [JsonProperty("p2p")]
        public ulong P2P { get; set; }

        [JsonProperty("block")]
        public ulong Block { get; set; }

        [JsonProperty("app")]
        public ulong App { get; set; }
    }
}