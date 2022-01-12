using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Terra.Net.Lcd.Objects
{

    /// <summary>
    /// Event allows application developers to attach additional information to
    /// ResponseBeginBlock, ResponseEndBlock, ResponseCheckTx and ResponseDeliverTx.
    /// Later, transactions may be queried using these events.
    /// </summary>
    public class Event
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attributes")]
        public List<EventAttribute> Attributes { get; set; }

        public List<string> ToRequestString()
        {
            return Attributes.Select(x => $"{Type}.{x.Key}={x.Value}").ToList();
        }
    }

    /// <summary>
    /// EventAttribute is a single key-value pair, associated with an event.
    /// </summary>
    public class EventAttribute
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("index")]
        public bool Index { get; set; }
    }
}