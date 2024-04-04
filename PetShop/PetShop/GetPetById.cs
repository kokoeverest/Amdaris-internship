using MediatR;

namespace PetShop;

public record GetPetById(int PetId) : IRequest<PetDto>;

public class GetPetByIdHandler : IRequestHandler<GetPetById, PetDto>
{
    private readonly IPetsRepository _petsRepository;

    public GetPetByIdHandler(IPetsRepository petsRepository)
    {
        _petsRepository = petsRepository;
    }

    public Task<PetDto> Handle(GetPetById request, CancellationToken cancellationToken)
    {
        try
        {
            var pet = _petsRepository.GetPetById(request.PetId);
            return Task.FromResult(PetDto.FromPet(pet));
        }
        catch (ApplicationException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}

