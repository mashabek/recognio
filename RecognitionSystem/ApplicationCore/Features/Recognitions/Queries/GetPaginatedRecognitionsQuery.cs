using ApplicationCore.Common.Extensions;
using ApplicationCore.Common.ResponseModels;
using ApplicationCore.Features.Recognitions.DTOs;
using ApplicationCore.Persistance;
using MediatR;

namespace ApplicationCore.Features.Recognitions.Queries;

public record GetPaginatedRecognitionsQuery : IRequest<PaginatedList<RecognitionDTO>>
{
    public int Page { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetPaginatedRecognitionsHandler : IRequestHandler<GetPaginatedRecognitionsQuery, PaginatedList<RecognitionDTO>>
{
    private readonly AppDbContext _dbContext;

    public GetPaginatedRecognitionsHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<PaginatedList<RecognitionDTO>> Handle(GetPaginatedRecognitionsQuery request, CancellationToken cancellationToken)
    {
       return await  _dbContext.Recognitions.Select(r => new RecognitionDTO(r.Id, r.RecognizedUser.UserName, r.Header, r.Description))
                                            .PaginatedListAsync(request.Page, request.PageSize);
    }
}