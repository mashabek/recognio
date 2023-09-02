using ApplicationCore.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecognitionCore.Domain.Entities;

namespace ApplicationCore.Features.Recognitions.Queries;

public class GetUserRecognitionsQuery : IRequest<IReadOnlyList<Recognition>>
{
    public string UserId { get; init; }
}

public class GetUserRecogntionsHanlder : IRequestHandler<GetUserRecognitionsQuery, IReadOnlyList<Recognition>>
{
    private readonly AppDbContext _dbContext;

    public GetUserRecogntionsHanlder(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IReadOnlyList<Recognition>> Handle(GetUserRecognitionsQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Recognitions.Where(r => r.RecognizedUserId == request.UserId).ToListAsync(cancellationToken);
    }
}