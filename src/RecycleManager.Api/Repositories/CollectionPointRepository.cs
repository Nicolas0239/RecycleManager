using Microsoft.EntityFrameworkCore;
using RecycleManager.Api.Domain;
using RecycleManager.Api.DTOs;
using RecycleManager.Api.Infrastructure;

namespace RecycleManager.Api.Repositories
{
    public class CollectionPointRepository : ICollectionPointRepository
    {
        private readonly AppDbContext _context;

        public CollectionPointRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CollectionPointDto> AddAsync(CollectionPointCreateDto dto)
        {
            var entity = new CollectionPoint
            {
                Name = dto.Name,
                Address = dto.Address
            };

            _context.CollectionPoints.Add(entity);
            await _context.SaveChangesAsync();

            return new CollectionPointDto
            {
                CollectionPointId = entity.CollectionPointId, // O EF preencheu o ID automaticamente aqui
                Name = entity.Name,
                Address = entity.Address
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.CollectionPoints.FindAsync((long)id); // Cast para long se seu ID for long

            if (entity == null) return false;

            _context.CollectionPoints.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<CollectionPointwithMaterialsDto?> GetByIdAsync(int id)
        {
            var entity = await _context.CollectionPoints
                                       .AsNoTracking()
                                       .Include(cp => cp.Materials) // Eager Loading (Carrega os filhos)
                                       .FirstOrDefaultAsync(cp => cp.CollectionPointId == id);

            if (entity == null) return null;

            // Mapeamento Manual Entidade -> DTO Completo
            return new CollectionPointwithMaterialsDto
            {
                CollectionPointId = entity.CollectionPointId,
                Name = entity.Name,
                Address = entity.Address,
                Materials = entity.Materials.Select(m => new MaterialDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Category = m.Category
                }).ToList()
            };
        }

        public async Task<(IEnumerable<CollectionPointwithMaterialsDto> Items, int Total)> GetPagedAsync(int page, int pageSize)
        {
            var query = _context.CollectionPoints.AsNoTracking();

            // 1. Contagem Total (para a paginação)
            var total = await query.CountAsync();

            // 2. Busca Paginada com Projeção (Select)
            // A projeção é mais eficiente que o Include pois busca só o que precisa
            var items = await query
                .OrderBy(cp => cp.Name) // Importante ordenar para paginar
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(cp => new CollectionPointwithMaterialsDto
                {
                    CollectionPointId = cp.CollectionPointId,
                    Name = cp.Name,
                    Address = cp.Address,
                    // Sub-select para preencher a lista de materiais
                    Materials = cp.Materials.Select(m => new MaterialDto
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Category = m.Category
                    }).ToList()
                })
                .ToListAsync();

            return (items, total);
        }

        public async Task<CollectionPointwithMaterialsDto?> UpdateAsync(CollectionPointDto dto)
        {
            var entity = await _context.CollectionPoints
                                       .Include(cp => cp.Materials) 
                                       .FirstOrDefaultAsync(cp => cp.CollectionPointId == dto.CollectionPointId);

            if (entity == null) return null;

            // 2. Atualiza os campos
            entity.Name = dto.Name;
            entity.Address = dto.Address;

            // 3. Salva
            _context.CollectionPoints.Update(entity);
            await _context.SaveChangesAsync();

            // 4. Retorna o DTO atualizado
            return new CollectionPointwithMaterialsDto
            {
                CollectionPointId = entity.CollectionPointId,
                Name = entity.Name,
                Address = entity.Address,
                // Mapeia os materiais existentes para devolver no objeto completo
                Materials = entity.Materials.Select(m => new MaterialDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Category = m.Category
                }).ToList()
            };
        }
    }
}
