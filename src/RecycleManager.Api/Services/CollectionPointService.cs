using RecycleManager.Api.DTOs;
using RecycleManager.Api.Repositories;

namespace RecycleManager.Api.Services
{
    public class CollectionPointService : ICollectionPointService
    {
        private readonly ICollectionPointRepository _repository;

        public CollectionPointService(ICollectionPointRepository repository)
        {
            _repository = repository;
        }

        public async Task<(IEnumerable<CollectionPointwithMaterialsDto> Items, int Total)> GetPagedAsync(int page, int pageSize)
        {
            return await _repository.GetPagedAsync(page, pageSize);
        }

        public async Task<CollectionPointwithMaterialsDto?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<CollectionPointDto> CreateAsync(CollectionPointCreateDto dto)
        {
            return await _repository.AddAsync(dto);
        }

        public async Task<CollectionPointwithMaterialsDto?> UpdateAsync(int id, CollectionPointDto dto)
        {
            dto.CollectionPointId = id; 

            return await _repository.UpdateAsync(dto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // Cascata: ao deletar, os materiais também seram deletados

            return await _repository.DeleteAsync(id);
        }
    }
}

