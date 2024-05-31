using project_api.Application.DTOs;

namespace project_api.Application.Services;

public interface IVetService
{
    Task<IEnumerable<PetDTO>> ListPets();
    Task<int> TotalPets();
}
