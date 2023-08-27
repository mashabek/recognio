using ApplicationCore.Persistance;
using MediatR;
using RecognitionCore.Domain.Entities;

namespace ApplicationCore.Features.Recognitions.Commands;

public class RecognizeUserCommand : IRequest<int>
{
    public int RecognizedUserId { get; init; }
    public string Header { get; init; }
    public string Description { get; init; }
    public int RecognizedByUserId { get; init; }
}
public class RecognizeUserCommandHandler : IRequestHandler<RecognizeUserCommand, int>
{
    private readonly AppDbContext _dbContext;

    public RecognizeUserCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> Handle(RecognizeUserCommand request, CancellationToken cancellationToken)
    {
        var r = request;
        var entity = await _dbContext.Recognitions.AddAsync(new Recognition(r.RecognizedUserId, r.RecognizedByUserId, r.Header, r.Description), cancellationToken);
        return entity.Entity.Id;
    }
}