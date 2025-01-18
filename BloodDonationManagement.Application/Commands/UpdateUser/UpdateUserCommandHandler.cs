namespace BloodDonationManagement.Application.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    IUserRepository repository
) : IRequestHandler<UpdateUserCommand, Result<string>>
{
    public async Task<Result<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetAsync(
            id: request.Id
        );
        
        if(user is null)
            return Result<string>.Error(ErrorMessages.NotFound<User>());

        user.Update(
            name: request.Name,
            email: request.Email
        );
        
        await repository.UpdateAsync(user);
        
        return Result<string>.Success();
    }
}