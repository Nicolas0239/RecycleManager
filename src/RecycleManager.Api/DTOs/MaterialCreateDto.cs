namespace RecycleManager.Api.DTOs;
public class MaterialCreateDto
{
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public bool IsRecyclable { get; set; }
    public long CollectionPointId { get; set; }
}
