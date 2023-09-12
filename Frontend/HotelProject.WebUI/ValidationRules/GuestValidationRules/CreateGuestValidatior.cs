using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidatior: AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidatior()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez!");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez!");

            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(20).WithMessage("3-20 karakter giriniz!");
            RuleFor(x => x.Surname).MinimumLength(3).MaximumLength(20).WithMessage("3-20 karakter giriniz!");
            RuleFor(x => x.City).MinimumLength(3).MaximumLength(20).WithMessage("3-20 karakter giriniz!");
        }
    }
}
