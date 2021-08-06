﻿using AllegroApi.Query.AllegroOffer;
using FluentValidation;

namespace AllegroApi.Domain.Validator.QueryValidator
{
    public class GetAllOffersQueryValidator: AbstractValidator<GetAllOffersQuery>
    {
        public GetAllOffersQueryValidator()
        {
            RuleFor(x => x.Authorization).NotEmpty();
        }
    }
}