using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using RecycleManager.Api.DTOs;

namespace RecycleManager.Api.Validators
{
    public class CollectionPointCreateDtoValidator: AbstractValidator<CollectionPointCreateDto>
    {
        public CollectionPointCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("O endereço é obrigatório.")
                .MaximumLength(200).WithMessage("O endereço deve ter no máximo 200 caracteres.");
        }
    }
}
