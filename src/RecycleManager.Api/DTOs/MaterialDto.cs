using RecycleManager.Api.Domain;

namespace RecycleManager.Api.DTOs;
public class MaterialDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public CollectionPointDto CollectionPoint { get; set; } = null;
}
