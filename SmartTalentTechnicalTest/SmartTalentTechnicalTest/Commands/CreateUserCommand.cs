namespace SmartTalentTechnicalTest.Commands
{
    public record CreateUserCommand( string name, string email, string password);
    public record UpdateUserCommand(Guid userId, string name, string email, string password, int type);
}
