using project_api.Core.Entities;

namespace project_api.DataAccess.Repositories.Impl;

public class PetRepository : GeneralRepository<Pet>, IPetRepository
{
    private readonly AppDbContext _context;

    public PetRepository(AppDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }
}
