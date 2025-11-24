using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace JSONSerialisationDeserialisation
{
    public class Post
    {
        // Holt aus Json id und setzt sie als Id
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
     }
}
