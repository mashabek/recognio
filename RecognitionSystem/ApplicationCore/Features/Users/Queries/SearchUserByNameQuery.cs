using ApplicationCore.Common.Extensions;
using ApplicationCore.Common.ResponseModels;
using ApplicationCore.Features.Users.DTOs;
using ApplicationCore.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Features.Users.Queries;

public record SearchUserByNameQuery(string name) : IReqsuest<PaginatedList<UserDTO>>;

public class SearchUserByNameHandler : IRequestHandler<SearchUserByNameQuery, PaginatedList<UserDTO>>
{
    private readonly AppDbContext _dbContext;

    public SearchUserByNameHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<PaginatedList<UserDTO>> Handle(SearchUserByNameQuery request, CancellationToken cancellationToken)
    {
        var matchingUsers = await _dbContext.Users
            .Where(user => 
                user.FirstName.ToLower().Contains(request.name.ToLower()) ||
                user.LastName.ToLower().Contains(request.name.ToLower())).Select(u => new UserDTO(u.FirstName + " " + u.LastName, u.Id))
            .PaginatedListAsync(1, 10);
        return matchingUsers;
    }
}