﻿using FluentValidation;
using MovieAPI.Application.Cqrs.Commands.UserCommands;

namespace MovieAPI.Application.Validators.UserValidators;

public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Surname)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty();
    }
}