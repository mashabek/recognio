namespace ApplicationCore.Features.Recognitions.DTOs;

public class RecognitionDTO
{
    public int Id { get; private set; }
    public string RecognizedUserName { get; private set; }
    public string Header { get; private set; }
    public string Description { get; private set; }

    public RecognitionDTO(int id, string recognizedUserName, string header, string description)
    {
        RecognizedUserName = recognizedUserName;
        Header = header;
        Description = description;
    }
}