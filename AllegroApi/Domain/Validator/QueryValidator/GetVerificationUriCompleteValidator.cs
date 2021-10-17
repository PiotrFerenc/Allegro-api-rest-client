using AllegroApi.Query.Account.AllegroAuth;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class GetVerificationUriCompleteValidator : AbstractValidator<GetVerificationUriCompleteCommand>
    {
        public GetVerificationUriCompleteValidator()
        {
            RuleFor(x => x.AuthKey).NotEmpty();
            RuleFor(x => x.ClientId).NotEmpty();
        }
    }
}