using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Terra.Net.Lcd.Helpers;
using Terra.Net.Lcd.Objects;

namespace Terra.Net.Lcd
{
    public partial class BaseRestClient
    {
        private readonly TerraClientOptions _options;
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        public BaseRestClient(TerraClientOptions options, ILogger logger)
        {
            _logger = logger;
            _options = options;
            _httpClient = _options.HttpClient;
        }
        private ulong _requestId;
        public async Task<T> Get<T>(string endpoint, Dictionary<string, object>? parameters = null, CancellationToken ct = default)
        {
            var id = Interlocked.Read(ref _requestId);
            Interlocked.Increment(ref _requestId);

            var param = parameters.CreateUrlParameters();
            LogRequest(id, endpoint, param);
            var data = await _httpClient.GetAsync(endpoint + param, ct);
            if (data.IsSuccessStatusCode)
            {
                var content = await data.Content.ReadAsStringAsync(ct);
                if (content != null)
                {
                    LogResponse(id);
                    return JsonConvert.DeserializeObject<T>(content);
                }
                else
                {
                    LogEmptyResponse(id);
                    return default(T);
                }

            }
            else
            {
                LogRequestFail(id, data.StatusCode.ToString(), await data.Content.ReadAsStringAsync(ct));
                return default(T);
            }
        }

        [LoggerMessage(EventId = 1, Level = LogLevel.Debug, Message = "{RequestId}] Executing request to {Endpoint} with params {body}")]
        partial void LogRequest(ulong id, string endpoint, string bodyOrParams);
        [LoggerMessage(EventId = 2, Level = LogLevel.Error, Message = "{RequestId}] request was failed with {statusCode}: {body} ")]
        partial void LogRequestFail(ulong id, string statusCode, string body);
        [LoggerMessage(EventId = 3, Level = LogLevel.Debug, Message = "{RequestId}] catched response")]
        partial void LogResponse(ulong id);
        [LoggerMessage(EventId = 4, Level = LogLevel.Warning, Message = "{RequestId}] has empty response")]
        partial void LogEmptyResponse(ulong id);
    }
}