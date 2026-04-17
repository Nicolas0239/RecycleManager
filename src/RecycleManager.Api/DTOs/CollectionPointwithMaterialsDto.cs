namespace RecycleManager.Api.DTOs
{
    public class CollectionPointwithMaterialsDto
    {
        public long CollectionPointId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public List<MaterialDto> Materials {get; set;} = new List<MaterialDto>();
}
}
