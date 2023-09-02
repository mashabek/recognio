namespace ApplicationCore.Features.Users.DTOs;

public class UserDTO
{
    public string Name { get; private set; }
    public string Id { get; private set; }

    public UserDTO(string name, string id)
    {
        Name = name;
        Id = id;
    }
}