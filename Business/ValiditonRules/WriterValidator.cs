using Entities.Concrete;
using FluentValidation;

namespace Business.ValiditonRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(W => W.WriterName).NotEmpty().WithMessage("Ad Soyad Boş Geçilemez!");
            RuleFor(W => W.WriterMail).NotEmpty().WithMessage("E-mail Boş Geçilemez!");
            RuleFor(W => W.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez!");
            RuleFor(W => W.WriterName).MinimumLength(2).WithMessage("Minimum 2 karekter girişi yapın!");
            RuleFor(W => W.WriterName).MaximumLength(50).WithMessage("Maximum 50 karekter girişi yapın!");

        }
    }
}