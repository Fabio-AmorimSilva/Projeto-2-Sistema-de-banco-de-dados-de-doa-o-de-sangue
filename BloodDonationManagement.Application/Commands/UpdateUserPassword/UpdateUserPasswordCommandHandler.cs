﻿namespace BloodDonationManagement.Application.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandHandler(
    IUserRepository repository,
    PasswordHashService service
) : IRequestHandler<UpdateUserPasswordCommand, ResultDto<string>>
{
    public async Task<ResultDto<string>> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetAsync(id: request.Id);

        if (user is null)
            return ResultDto<string>.Error(ErrorMessages.NotFound<User>());

        var hashedPassword = PasswordHashService.HashPassword(request.Password);

        user.UpdatePassword(hashedPassword);

        await repository.UpdateAsync(user);

        return ResultDto<string>.Success();
    }
}