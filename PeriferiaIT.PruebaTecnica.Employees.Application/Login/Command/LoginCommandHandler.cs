using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PeriferiaIT.PruebaTecnica.Employees.Application.Login.Command
{
    public record LoginRequestCommand() : IRequest<string> {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }

    class LoginCommandHandler(IConfiguration configuration) : IRequestHandler<LoginRequestCommand, string>
    {
        public Task<string> Handle(LoginRequestCommand request, CancellationToken cancellationToken)
        {
            if (request.UserName == "admin" && request.Password == "admin")
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:IssuerToken"],
                    audience: configuration["Jwt:AudienceToken"],
                    null,
                    expires: DateTime.Now.AddMinutes(double.Parse(configuration["Jwt:ExpirationTime"]!)),
                    signingCredentials: credentials
                );

                return Task.FromResult("Bearer " + new JwtSecurityTokenHandler().WriteToken(token));
            }
            return Task.FromResult(string.Empty);
        }
    }
}
