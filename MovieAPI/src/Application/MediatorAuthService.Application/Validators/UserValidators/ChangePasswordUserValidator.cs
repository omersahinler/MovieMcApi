﻿using FluentValidation;
using MovieAPI.Application.Cqrs.Commands.UserCommands;

namespace MovieAPI.Application.Validators.UserValidators;

public class ChangePasswordUserValidator : AbstractValidator<ChangePasswordUserCommand>
{
	public ChangePasswordUserValidator()
	{
		RuleFor(x => x.OldPassword)
			.NotEmpty();

        RuleFor(x => x.NewPassword)
            .NotEmpty();
    }
}