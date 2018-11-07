using Newtonsoft.Json;

namespace ExerciseXamarin.Models
{
    public class SearchResult
    {
        [JsonProperty(PropertyName = "response")]
        public SearchResponse SearchResponse { get; set; }

       
    }

}