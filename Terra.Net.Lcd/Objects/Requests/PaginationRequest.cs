using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects.Requests
{
    public class PaginationRequest : BasePaginationRequest
    {
        private string? key;
        private ulong? offset;

        /// <summary>
        /// key is a value returned in PageResponse.next_key to begin querying the next page most efficiently.
        /// Only one of offset or key should be set
        /// </summary>
        [JsonProperty("key")]
        public string? Key { 
            get => key; 
            set {
                key = value;
                offset = null; 
            }
        }

        /// <summary>
        /// offset is a numeric offset that can be used when key is unavailable.It is less efficient than using key.
        /// Only one of offset or key shouldbe set.
        /// </summary>
        [JsonProperty("offset")] 
        public override ulong? Offset {
            get => offset;
            set
            {
                offset = value;
                key = null;
            }
        }

        /// <summary>
        /// count_total is set to true  to indicate that the result set should include 
        /// a count of the total number of items available for pagination in UIs. 
        /// count_total is only respected when offset is used. It is ignored when key is set.
        /// </summary>
        [JsonProperty("count_total")]
        public bool? CountTotal { get; set; }

        /// <summary>
        /// reverse is set to true if results are to be returned in the descending order.
        /// </summary>
        [JsonProperty("reverse")]
        public bool? Reverse { get; set; }
    }
}
