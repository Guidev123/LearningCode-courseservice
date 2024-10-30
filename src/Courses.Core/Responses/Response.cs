using System.Text.Json.Serialization;

namespace Courses.Core.Responses
{
    public class Response<TData>
    {
        private readonly int _code;

        [JsonConstructor]
        public Response()
            => _code = 200;

        public Response(
            TData? data,
            int code = 200,
            string? message = null,
            IEnumerable<string>? validationErrors = null)
        {
            Data = data;
            Message = message;
            _code = code;
            ValidationErrors = validationErrors;
        }

        [JsonPropertyName("Errors")]
        public IEnumerable<string>? ValidationErrors { get; set; }
        public TData? Data { get; set; }
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess
            => _code is >= 200 and <= 299;
    }
}
