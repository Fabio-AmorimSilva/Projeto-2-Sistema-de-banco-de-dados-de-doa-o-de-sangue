namespace BloodDonationManagement.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    IUserRepository repository
) : IRequestHandler<UpdateUserCommand, ResultDto<string>>
{
    public async Task<ResultDto<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetAsync(
            id: request.Id
        );
        
        if(user is null)
            return ResultDto<string>.Error(ErrorMessages.NotFound<User>());

        user.Update(
            name: request.Name,
            email: request.Email
        );
        
        await repository.UpdateAsync(user);
        
        return ResultDto<string>.Success();
    }
}