namespace BloodDonationManagement.Application.Commands.InsertUser;

public class InserUserCommandHandler(
    IUserRepository repository
) : IRequestHandler<InsertUserCommand>
{
    public async Task Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var password = PasswordHashService.HashPassword(request.Password);
        
        var user = new User(
            name: request.Name,
            email: request.Email,
            password: password
        );
        
        await repository.AddAsync(user);
    }
}