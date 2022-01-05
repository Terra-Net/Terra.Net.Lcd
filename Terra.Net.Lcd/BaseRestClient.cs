using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
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
        public async Task<CallResult<T>> Get<T>(string endpoint, Dictionary<string, object>? parameters = null, CancellationToken ct = default)
        {
            var id = Interlocked.Read(ref _requestId);
            Interlocked.Increment(ref _requestId);
            var param = parameters.CreateUrlParameters();
            LogRequest(id, endpoint, param);      
            return await ProcessResponse<T>(await _httpClient.GetAsync(endpoint + param, ct), id, ct);
        }
        public async Task<CallResult<T>> Post<T>(string endpoint, Dictionary<string, object>? parameters = null, CancellationToken ct = default)
        {
            var id = Interlocked.Read(ref _requestId);
            Interlocked.Increment(ref _requestId);
            var param = JsonConvert.SerializeObject(parameters);
            var json = new StringContent(param, Encoding.UTF8, "application/json");
            LogRequest(id, endpoint, param);
            return await ProcessResponse<T>(await _httpClient.PostAsync(endpoint, json, ct), id, ct);
        }

        private async Task<CallResult<T>> ProcessResponse<T>(HttpResponseMessage data, ulong requestId, CancellationToken ct = default)
        {
            if (data.IsSuccessStatusCode)
            {
                var content = await data.Content.ReadAsStringAsync(ct);
                if (content != null)
                {
                    LogResponse(requestId);
                    return new CallResult<T>(JsonConvert.DeserializeObject<T>(content));
                }
                else
                {
                    LogEmptyResponse(requestId);
                    return new CallResult<T>(default(T));
                }
            }
            else
            {
                var body = await data.Content.ReadAsStringAsync();
                LogRequestFail(requestId, data.StatusCode.ToString(), body);
                return new CallResult<T>(default(T), JsonConvert.DeserializeObject<CallError>(body));
            }
        }

        [LoggerMessage(EventId = 1, Level = LogLevel.Debug, Message = "{id} Executing request to {Endpoint} with params {bodyOrParams}")]
        partial void LogRequest(ulong id, string endpoint, string bodyOrParams);
        [LoggerMessage(EventId = 2, Level = LogLevel.Error, Message = "{id} request was failed with {statusCode}: {body} ")]
        partial void LogRequestFail(ulong id, string statusCode, string body);
        [LoggerMessage(EventId = 3, Level = LogLevel.Debug, Message = "{id} catched response")]
        partial void LogResponse(ulong id);
        [LoggerMessage(EventId = 4, Level = LogLevel.Warning, Message = "{id} has empty response")]
        partial void LogEmptyResponse(ulong id);
    }
}