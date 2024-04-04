using MediatR;
using PetShop.Application.Pets.Responses;
using PetShop.Domain.Enums;
using PetShop.Infrastructure.Abstractions;

namespace PetShop.Application.Pets.Queries;

public record GetPetsBySpecies(SpeciesEnum Species) : IRequest<List<PetDto>>;
public class GetPetsBySpeciesHandler : IRequestHandler<GetPetsBySpecies, List<PetDto>>
{
    private readonly IPetsRepository _petsRepository;

    public GetPetsBySpeciesHandler(IPetsRepository petsRepository)
    {
        _petsRepository = petsRepository;
    }

    public Task<List<PetDto>> Handle(GetPetsBySpecies request, CancellationToken cancellationToken)
    {
        var pets = _petsRepository.GetPetsBySpecies(request.Species);
        return Task.FromResult(pets.Select(PetDto.FromPet).ToList());
    }
}