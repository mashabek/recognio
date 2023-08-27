using RecognitionCore.Domain.Shared;

namespace RecognitionCore.Domain.Entities;

public class Recognition : BaseAuditableEntity
{
    public Recognition(int recognizedUserId, int recognizedByUserId, string header, string description)
    {
        this.RecognizedUserId = recognizedUserId;
        this.RecognizedByUserId = recognizedByUserId;
        this.Header = header;
        this.Description = description;
    }
    public int RecognizedUserId { get; private set; }
    public int RecognizedByUserId { get; private set; }
    public User RecognizedUser { get; private set; }
    public User RecognizedByUser { get; private set; }
    public string Header { get; private set; }
    public string Description { get; private set; }
}