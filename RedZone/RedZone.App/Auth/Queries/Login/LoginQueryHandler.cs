using RedZone.App.Auth.Commands.Register;
using RedZone.App.Common.Interfaces.Auth;
using RedZone.App.Common.Interfaces.Persistence;
using RedZone.App.Services.Auth.Common;
using ErrorOr;
using RedZone.Domain.Common.Errors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedZone.Domain.Users;

namespace RedZone.App.Auth.Queries.Login
{
    public class VerifyEmailQueryHandler : IRequestHandler<VerifyEmailQuery, ErrorOr<AuthResult>>
    {
        private readonly IUserRepository _userRepository;
        public VerifyEmailQueryHandler( IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ErrorOr<AuthResult>> Handle(VerifyEmailQuery query, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Auth.UnvalidEmail;
            }
            var result = _userRepository.Login(query.Email, query.password);
            if (result is null)
            {
                return new[] { Errors.Auth.UnvalidPassword };
            }
            
            return result;
        }
    }
}
