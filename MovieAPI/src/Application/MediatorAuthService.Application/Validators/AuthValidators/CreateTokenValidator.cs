﻿using FluentValidation;
using MovieAPI.Application.Cqrs.Queries.AuthQueries;

namespace MovieAPI.Application.Validators.AuthValidators;

public class CreateTokenValidator : AbstractValidator<CreateTokenQuery>
{
	public CreateTokenValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty();

		RuleFor(x => x.Password)
			.NotEmpty();
	}
}