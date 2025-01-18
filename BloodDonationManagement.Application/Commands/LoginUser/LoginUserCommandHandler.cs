namespace BloodDonationManagement.Application.Commands.LoginUser;

public class LoginUserCommandHandler(
    IUserRepository repository,
    JwtTokenService tokenService
) : IRequestHandler<LoginUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = PasswordHashService.HashPassword(request.Password);
        var user = await repository.GetUserByEmailAndPassword(request.Email, hashedPassword);

        if (user is null)
            return Result<string>.Error(ErrorMessages.NotFound<User>());

        var token = tokenService.GenerateToken(user);

        return new Result<string>(token);
    }
}