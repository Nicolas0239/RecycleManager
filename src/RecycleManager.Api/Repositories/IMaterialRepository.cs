using RecycleManager.Api.DTOs;

namespace RecycleManager.Api.Repositories;
public interface IMaterialRepository
{
    Task<(IEnumerable<MaterialDto> Items, int Total)> GetPagedAsync(int page, int pageSize);
    Task<MaterialDto> AddAsync(MaterialDto dto);
    Task<MaterialDto?> UpdateAsync(MaterialDto dto);
    Task<MaterialDto?> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}
