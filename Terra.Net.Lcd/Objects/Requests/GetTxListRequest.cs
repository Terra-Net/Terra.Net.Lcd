using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terra.Net.Lcd.Objects.Requests
{
    public class GetTxListRequest : BasePaginationRequest
    {
        public string Address { get; set; }
        public ulong? Block { get; set; }
        public string ChainId { get; set; }
    }
}
