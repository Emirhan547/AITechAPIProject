using AITech.WebUI.DTOs.ProjectDtos;
using FluentValidation;

namespace AITech.WebUI.Validators
{
    public class ProjectValidator : AbstractValidator<CreateProjectDto>
    {
        public ProjectValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Başlık Boş bırakılamaz")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakterli olmalıdır");
            RuleFor(p => p.ImageUrl).NotEmpty().WithMessage("Resim Boş bırakılamaz");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Kategori Boş bırakılamaz");
        }
    }
}