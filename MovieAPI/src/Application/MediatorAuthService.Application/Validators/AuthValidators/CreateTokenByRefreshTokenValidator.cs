using FluentValidation;
using MovieAPI.Application.Cqrs.Commands.AuthCommands;

namespace MovieAPI.Application.Validators.AuthValidators;

public class CreateTokenByRefreshTokenValidator : AbstractValidator<CreateTokenByRefreshTokenCommand>
{
	public CreateTokenByRefreshTokenValidator()
	{
		RuleFor(x => x.RefreshToken)
			.NotEmpty();
	}
}