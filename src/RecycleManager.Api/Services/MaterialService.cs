using RecycleManager.Api.DTOs;
using RecycleManager.Api.Repositories;

namespace RecycleManager.Api.Services;
public class MaterialService : IMaterialService
{
    private readonly IMaterialRepository _repo;
    public MaterialService(IMaterialRepository repo) => _repo = repo;

    public async Task<PagedResult<MaterialDto>> GetPagedAsync(int page, int pageSize)
    {
        var (items, total) = await _repo.GetPagedAsync(page, pageSize);
        return new PagedResult<MaterialDto> { Items = items, Page = page, PageSize = pageSize, TotalCount = total };
    }

    public async Task<MaterialDto> CreateAsync(MaterialCreateDto createDto)
    {
        // basic validation is performed by injected validator in controllers
        var dto = new MaterialDto { Name = createDto.Name, Category = createDto.Category, CollectionPoint =
            new CollectionPointDto
            {
                CollectionPointId = createDto.CollectionPointId
            }
            };
        return await _repo.AddAsync(dto);
    }

    public async Task<MaterialDto?> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<MaterialDto?> UpdateAsync(int id, MaterialDto dto)
    {
        return await _repo.UpdateAsync(dto);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repo.DeleteAsync(id);
    }
}
