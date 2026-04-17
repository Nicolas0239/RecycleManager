using RecycleManager.Api.DTOs;

namespace RecycleManager.Api.Services
{
    public interface ICollectionPointService
    {
        Task<(IEnumerable<CollectionPointwithMaterialsDto> Items, int Total)> GetPagedAsync(int page, int pageSize);
        Task<CollectionPointwithMaterialsDto?> GetByIdAsync(int id);
        Task<CollectionPointDto> CreateAsync(CollectionPointCreateDto dto);
        Task<CollectionPointwithMaterialsDto?> UpdateAsync(int id, CollectionPointDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
