namespace BloodDonationManagement.Application.Commands.LoginUser;

public class LoginUserCommandHandler(
    IUserRepository repository,
    JwtTokenService tokenService
) : IRequestHandler<LoginUserCommand, ResultDto<string>>
{
    public async Task<ResultDto<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = PasswordHashService.HashPassword(request.Password);
        var user = await repository.GetUserByEmailAndPassword(request.Email, hashedPassword);

        if (user is null)
            return ResultDto<string>.Error(ErrorMessages.NotFound<User>());

        var token = tokenService.GenerateToken(user);

        return new ResultDto<string>(token);
    }
}