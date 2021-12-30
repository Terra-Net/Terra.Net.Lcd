using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terra.Net.Lcd.Objects;

namespace Terra.Net.Lcd.Interfaces
{
    /// <summary>
    /// https://fcd.terra.dev/swagger
    /// </summary>
    public interface ITerraLcdClient
    {
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <summary>
        /// GetBlockByHeight queries block for given height.
        /// </summary>
        /// <returns>A successful response.</returns>
        Task<TerraBlock> GetBlockByHeight(ulong height, CancellationToken ct=default);
    }
}
