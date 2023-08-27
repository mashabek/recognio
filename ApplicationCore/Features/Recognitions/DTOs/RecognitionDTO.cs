namespace ApplicationCore.Features.Recognitions.DTOs;

public class RecognitionDTO
{
    public int Id { get; private set; }
    public string RecognizedUserName { get; private set; }
    public string Header { get; private set; }
    public string Description { get; private set; }
}