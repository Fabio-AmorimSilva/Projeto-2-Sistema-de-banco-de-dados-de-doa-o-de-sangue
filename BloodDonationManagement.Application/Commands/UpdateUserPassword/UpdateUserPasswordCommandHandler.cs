namespace BloodDonationManagement.Application.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandHandler(
    IUserRepository repository,
    PasswordHashService service
) : IRequestHandler<UpdateUserPasswordCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetAsync(id: request.Id);

        if (user is null)
            return Result<string>.Error(ErrorMessages.NotFound<User>());

        var hashedPassword = PasswordHashService.HashPassword(request.Password);

        user.UpdatePassword(hashedPassword);

        await repository.UpdateAsync(user);

        return Result<string>.Success();
    }
}