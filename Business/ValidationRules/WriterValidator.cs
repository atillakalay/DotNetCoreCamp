using Entities.Concrete;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Business.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(W => W.WriterName).NotEmpty().WithMessage("Ad Soyad Boş Geçilemez!");
            RuleFor(W => W.WriterMail).NotEmpty().WithMessage("E-mail Boş Geçilemez!");
            RuleFor(W => W.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez!");
            RuleFor(W => W.WriterPasswordRepeat).NotEmpty().WithMessage("Şifre Tekrarı Boş Geçilemez!");
            RuleFor(W => W.WriterName).MinimumLength(2).WithMessage("Minimum 2 karekter girişi yapın!");
            RuleFor(W => W.WriterName).MaximumLength(50).WithMessage("Maximum 50 karekter girişi yapın!");
            RuleFor(w => w.WriterPassword).Must(IsPasswordValid).WithMessage("Parolanızda en az bir küçük harf bir büyük harf ve rakam olmalıdır!");


        }
        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}