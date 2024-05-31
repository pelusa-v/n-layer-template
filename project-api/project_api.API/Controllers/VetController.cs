using Microsoft.AspNetCore.Mvc;
using project_api.Application.DTOs;
using project_api.Application.Services;

namespace project_api.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VetController : ControllerBase
{
    private readonly IVetService _vetService;

    public VetController(IVetService vetService)
    {
        _vetService = vetService;
    }

    [HttpGet("pets")]
    public async Task<ActionResult<ResultResponse<List<PetDTO>>>> ListPets()
    {
        var pets = await _vetService.ListPets();
        var totalPets = await _vetService.TotalPets();
        return ResultResponse.Success(pets, totalPets);
    }
}