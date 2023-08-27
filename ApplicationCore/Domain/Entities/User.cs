using RecognitionCore.Domain.Shared;

namespace RecognitionCore.Domain.Entities;

public class User : BaseAuditableEntity
{
    public string Name { get; private set; }
    public ICollection<Recognition> Recognitions = new List<Recognition>();

    public User(string name)
    {
        Name = name;
    }
}