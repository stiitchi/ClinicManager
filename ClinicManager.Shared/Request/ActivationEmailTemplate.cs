using Newtonsoft.Json;

namespace ClinicManager.Shared.Request
{
    public class ActivationEmailTemplate
    {
        [JsonProperty("fullname")]
        public string Fullname { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

    }
}
