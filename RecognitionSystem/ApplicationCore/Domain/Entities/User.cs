using Microsoft.AspNetCore.Identity;
using RecognitionCore.Domain.Shared;
namespace RecognitionCore.Domain.Entities;

public class User : IdentityUser, IAuditableEntity
{
    public ICollection<Recognition> Recognitions = new List<Recognition>();
    
    public User()
    {
            
    }
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}