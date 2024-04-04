using MediatR;

namespace PetShop;

public record GetPetsBySex(SexEnum Sex) : IRequest<List<PetDto>>;
public class GetPetsBySexHandler : IRequestHandler<GetPetsBySex, List<PetDto>>
{
    private readonly IPetsRepository _petsRepository;

    public GetPetsBySexHandler(IPetsRepository petsRepository)
    {
        _petsRepository = petsRepository;
    }

    public Task<List<PetDto>> Handle(GetPetsBySex request, CancellationToken cancellationToken)
    {
        var pets = _petsRepository.GetPetsBySex(request.Sex);
        return Task.FromResult(pets.Select(PetDto.FromPet).ToList());
    }
}
