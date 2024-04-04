using MediatR;

namespace PetShop;

public record CreatePet(AnimalTypeEnum AnimalType, SpeciesEnum Species, SexEnum Sex, string Speciality, decimal Price) : IRequest<PetDto>;

public class CreatePetHandler : IRequestHandler<CreatePet, PetDto>
{
    private readonly IPetsRepository _petsRepository;

    public CreatePetHandler(IPetsRepository petsRepository)
    {
        _petsRepository = petsRepository;
    }

    public Task<PetDto> Handle(CreatePet request, CancellationToken cancellationToken)
    {
        if (request.Price < 0)
        {
            throw new ApplicationException("The price of the pet can't be negative");
        }

        Pet pet = new(
            animalType: request.AnimalType,
            species: request.Species,
            sex: request.Sex,
            speciality: request.Speciality,
            price: request.Price
            )
        {
            Id = GetNextId()
        };

        var newPet = _petsRepository.Create(pet);

        return Task.FromResult(PetDto.FromPet(newPet));
    }

    private int GetNextId()
    {
        return _petsRepository.GetLastId();
    }
}