using AutoMapper;
using project_api.Application.DTOs;
using project_api.DataAccess.Repositories;

namespace project_api.Application.Services.Impl;

public class VetService : IVetService
{
    private readonly IMapper _mapper;
    private readonly IPetRepository _petRepo;
    
    public VetService(IPetRepository petRepo, IMapper mapper)
    {
        _petRepo = petRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PetDTO>> ListPets()
    {
        var pets = await _petRepo.List();
        return _mapper.Map<List<PetDTO>>(pets);
    }

    public async Task<int> TotalPets()
    {
        return await _petRepo.Count();
    }
}
