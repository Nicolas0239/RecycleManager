using Microsoft.EntityFrameworkCore;
using RecycleManager.Api.DTOs;
using RecycleManager.Api.Domain;
using RecycleManager.Api.Infrastructure;

namespace RecycleManager.Api.Repositories;
public class MaterialRepository : IMaterialRepository
{
    private readonly AppDbContext _db;
    public MaterialRepository(AppDbContext db) => _db = db;

    public async Task<(IEnumerable<MaterialDto> Items, int Total)> GetPagedAsync(int page, int pageSize)
    {
        var query = _db.Materials.Include( m => m.CollectionPoint).AsNoTracking().OrderBy(m => m.Name);
        var total = await query.CountAsync();
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize)
                     .Select(m => new MaterialDto
                     {
                         Id = m.Id,
                         Name = m.Name,
                         Category = m.Category,
                         CollectionPoint = new CollectionPointDto
                         {
                             CollectionPointId = m.CollectionPointId,
                             Name = m.CollectionPoint.Name,
                             Address = m.CollectionPoint.Address
                         }
                     }).ToListAsync();
        return (items, total);
    }

    public async Task<MaterialDto> AddAsync(MaterialDto dto)
    {
        var entity = new Material { Name = dto.Name, Category = dto.Category, IsRecyclable = true, CollectionPointId = dto.CollectionPoint.CollectionPointId };
        _db.Materials.Add(entity);
        await _db.SaveChangesAsync();
        dto.Id = entity.Id;
        return dto;
    }

    public async Task<MaterialDto?> GetByIdAsync(int id)
    {
        return await _db.Materials
            .AsNoTracking()
            .Where(m => m.Id == id)
            .Select(m => new MaterialDto 
            { 
                Id = m.Id, 
                Name = m.Name, 
                Category = m.Category, 
                CollectionPoint = new CollectionPointDto
                {
                    CollectionPointId = m.CollectionPointId,
                    Name = m.CollectionPoint.Name,
                    Address = m.CollectionPoint.Address
                }
            })
            .FirstOrDefaultAsync();
    }

    public async Task<MaterialDto?> UpdateAsync(MaterialDto dto)
    {
        var entity = await _db.Materials.FirstOrDefaultAsync(m => m.Id == dto.Id);

        if (entity == null) return null;

        entity.Name = dto.Name;
        entity.Category = dto.Category;
        entity.CollectionPointId = dto.CollectionPoint.CollectionPointId;
        
        _db.Materials.Update(entity);
        await _db.SaveChangesAsync();

        return dto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _db.Materials.FindAsync(id);

        if (entity == null) return false;

        _db.Materials.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }
}
