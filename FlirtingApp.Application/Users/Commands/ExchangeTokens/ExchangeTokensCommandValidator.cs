﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace FlirtingApp.Application.Users.Commands.ExchangeTokens
{
	class ExchangeTokensCommandValidator: AbstractValidator<ExchangeTokensCommand>
	{
		public ExchangeTokensCommandValidator()
		{
			RuleFor(e => e.AccessToken).MinimumLength(100);
			RuleFor(e => e.RefreshToken).MinimumLength(10);
			RuleFor(e => e.RemoteIpAddress).NotEmpty();
		}
	}
}
