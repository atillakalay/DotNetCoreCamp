using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş Bırakılamaz.");
            RuleFor(b => b.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş Bırakılamaz.").MaximumLength(150).WithMessage("Lütfen 150 Karekterden Daha Az Veri Girişi Yapın").MinimumLength(5).WithMessage("Minumum 5 Karekter Girişi Yapın.");
            RuleFor(b => b.BlogImage).NotEmpty().WithMessage("Blog Görseli Boş Bırakılamaz.");
        }
    }
}
