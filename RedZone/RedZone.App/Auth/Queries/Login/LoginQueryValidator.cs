﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedZone.App.Auth.Queries.Login
{
    public class RefreshTokenQueryValidator : AbstractValidator<VerifyEmailQuery>
    {
        public RefreshTokenQueryValidator() 
        {
            RuleFor(X => X.Email).NotEmpty();
            RuleFor(X => X.password).NotEmpty();
        }
    }
}
