using RecycleManager.Api.DTOs;

namespace RecycleManager.Api.Services;
public interface IMaterialService
{
    Task<PagedResult<MaterialDto>> GetPagedAsync(int page, int pageSize);
    Task<MaterialDto> CreateAsync(MaterialCreateDto createDto);
    Task<MaterialDto?> GetByIdAsync(int id);
    Task<MaterialDto?> UpdateAsync(int id, MaterialDto dto);
    Task<bool> DeleteAsync(int id);
}
