using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RecycleManager.Api.DTOs;
using RecycleManager.Api.Infrastructure;

namespace RecycleManager.Api.Validators
{
    public class MaterialDtoValidator : AbstractValidator<MaterialDto>
    {
        private readonly AppDbContext _context;
        public MaterialDtoValidator(AppDbContext context)
        {
            _context = context;

            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Category).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CollectionPoint.CollectionPointId).NotNull()
                .MustAsync(async (id, cancellationToken) =>
                {
                    bool existe = await _context.CollectionPoints
                                                .AnyAsync(cp => cp.CollectionPointId == id, cancellationToken);
                    return existe;
                })
                .WithMessage("O Ponto de Coleta informado não existe.");
        }
    }
}
