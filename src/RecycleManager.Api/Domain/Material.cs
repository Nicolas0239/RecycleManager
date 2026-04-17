using System.ComponentModel.DataAnnotations.Schema;

namespace RecycleManager.Api.Domain;
public class Material
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public bool IsRecyclable { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public long CollectionPointId { get; set; }
    [ForeignKey("CollectionPointId")]
    public CollectionPoint CollectionPoint { get; set; } = null!;
}
