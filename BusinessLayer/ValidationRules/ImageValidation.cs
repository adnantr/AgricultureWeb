using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.ValidationRules
{
    public class ImageValidation : AbstractValidator<Image>
    {
        public ImageValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel başlıpını boş geçemezsiniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Görsel açıklamasını boş geçemezsiniz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel yolunu boş geçemezsiniz");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Lütfen en fazla 20 karater veri girişi yapınız.");
        
        }
    }
}
