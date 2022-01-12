using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Terra.Net.Lcd.Objects
{
    public enum CosmosOrdering
    {

        /// <summary>
        /// Enum ASC for value: ORDER_BY_ASC
        /// </summary>
        [EnumMember(Value = "ORDER_BY_ASC")]
        ASC,

        /// <summary>
        /// Enum DESC for value: ORDER_BY_DESC
        /// </summary>
        [EnumMember(Value = "ORDER_BY_DESC")]
        DESC,

        /// <summary>
        /// Enum Unspecified for value: ORDER_BY_UNSPECIFIED
        /// </summary>
        [EnumMember(Value = "ORDER_BY_UNSPECIFIED")]
        Unspecified
    }
}