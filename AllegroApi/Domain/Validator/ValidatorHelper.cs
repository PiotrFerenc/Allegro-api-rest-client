using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace AllegroApi.Domain.Validator
{
    public static class ValidatorHelper
    {
        public static async Task<bool> TryValidate<TValidator,TItem>(TItem item) where TValidator : AbstractValidator<TItem>, new()
        {
            var validator = new TValidator();
            
            var validatorResult = await validator.ValidateAsync(item);

            if (!validatorResult.IsValid)
            {
                throw new Exception(string.Join(", ",validatorResult.Errors.Select(x => x.ErrorMessage)));
            }

            return true;
        }
    }
}