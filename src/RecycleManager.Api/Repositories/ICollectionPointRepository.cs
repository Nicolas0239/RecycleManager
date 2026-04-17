using RecycleManager.Api.DTOs;

namespace RecycleManager.Api.Repositories
{
    public interface ICollectionPointRepository
    {
        Task<(IEnumerable<CollectionPointwithMaterialsDto> Items, int Total)> GetPagedAsync(int page, int pageSize);
        Task<CollectionPointDto> AddAsync(CollectionPointCreateDto dto);
        Task<CollectionPointwithMaterialsDto?> UpdateAsync(CollectionPointDto dto);
        Task<CollectionPointwithMaterialsDto?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
