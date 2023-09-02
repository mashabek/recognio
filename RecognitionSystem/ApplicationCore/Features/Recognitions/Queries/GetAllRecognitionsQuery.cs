using ApplicationCore.Features.Recognitions.DTOs;
using ApplicationCore.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecognitionCore.Domain.Entities;

namespace ApplicationCore.Features.Recognitions.Queries;

public class GetAllRecognitionsQuery : IRequest<IReadOnlyList<RecognitionDTO>>
{
    
}

public class GetAllRecognitionsHandler : IRequestHandler<GetAllRecognitionsQuery, IReadOnlyList<RecognitionDTO>>
{
    private readonly AppDbContext _dbContext;

    public GetAllRecognitionsHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IReadOnlyList<RecognitionDTO>> Handle(GetAllRecognitionsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Recognitions.Select(r => new RecognitionDTO(r.Id, r.RecognizedUser.NormalizedUserName, r.Header, r.Description)).ToListAsync(cancellationToken);
    }
}