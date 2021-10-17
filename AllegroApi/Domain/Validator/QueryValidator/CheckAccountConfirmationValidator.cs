using AllegroApi.Query.Account.AllegroAuth;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class CheckAccountConfirmationValidator : AbstractValidator<CheckAccountConfirmationCommand>
    {
        public CheckAccountConfirmationValidator()
        {
            RuleFor(x => x.DeviceCodeId).NotEmpty();
        }
    }
}