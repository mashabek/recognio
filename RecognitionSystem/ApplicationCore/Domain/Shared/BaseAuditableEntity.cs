namespace RecognitionCore.Domain.Shared;

public interface IAuditableEntity
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}