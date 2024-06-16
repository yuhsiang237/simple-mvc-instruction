using FluentValidation;
using WebMVCApplication.Models.Validators;

namespace WebMVCApplication.Models.Validators
{
    public class UserDataValidator : AbstractValidator<UserData>
    {
        public UserDataValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().WithMessage("不可為空");
            RuleFor(r => r.LastName).NotEmpty().WithMessage("不可為空");
            RuleFor(r => r.Age).NotEmpty().WithMessage("不可為空");
            RuleFor(r => r.Gender).NotEmpty().WithMessage("不可為空");
            RuleFor(r => r.Interests)
                .NotEmpty().WithMessage("不可為空")
                .Must(m => m?.Count >= 3)
                .WithMessage("至少填入3項");
            RuleFor(r => r.UserDetail).SetValidator(new UserDetailValidator());
        }
    }
}


public class UserDetailValidator : AbstractValidator<UserDetail>
{
    public UserDetailValidator()
    {
        RuleFor(detail => detail.School).NotEmpty().WithMessage("不可為空");
    }
}