using RecognitionCore.Domain.Shared;

namespace RecognitionCore.Domain.Entities;

public class Recognition : BaseEntity, IAuditableEntity
{
    public Recognition(string recognizedUserId, string recognizedByUserId, string header, string description)
    {
        this.RecognizedUserId = recognizedUserId;
        this.RecognizedByUserId = recognizedByUserId;
        this.Header = header;
        this.Description = description;
    }

    public Recognition()
    {
        
    }
    public string RecognizedUserId { get; private set; }
    public string RecognizedByUserId { get; private set; }
    public User RecognizedUser { get; private set; }
    public User RecognizedByUser { get; private set; }
    public string Header { get; private set; }
    public string Description { get; private set; }
    
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}