using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace DockerDotnetApi.Models.Requests
{
    public class CardRequest
    {
        [JsonPropertyName("card_number")]
        public string CardNumber { get; set; }
    }
}
