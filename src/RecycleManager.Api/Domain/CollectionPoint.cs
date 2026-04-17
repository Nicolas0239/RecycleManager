using System.Text.Json.Serialization;

namespace RecycleManager.Api.Domain
{
    public class CollectionPoint
    {
        public long CollectionPointId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;

        [JsonIgnore]
        public ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
