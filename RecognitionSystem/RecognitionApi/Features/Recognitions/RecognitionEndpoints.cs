using ApplicationCore.Features.Recognitions.Queries;
using MediatR;
using RecognitionCore.Domain.Entities;

namespace RecognitionApi.Features.Recognitions;

public static class RecognitionEndpoints
{
    public static RouteGroupBuilder MapRecognitionsApi(this RouteGroupBuilder group)
    {
        group.MapGet("/", (ISender m) =>  m.Send(new GetAllRecognitionsQuery()));
        return group;
    }
    
}
