﻿using MediatR;

namespace PetShop;

public record GetAllPets : IRequest<List<PetDto>>;
public class GetAllPetsHandler : IRequestHandler<GetAllPets, List<PetDto>>
{
    private readonly IPetsRepository _petsRepository;

    public GetAllPetsHandler(IPetsRepository petsRepository)
    {
        _petsRepository = petsRepository;
    }

    public Task<List<PetDto>> Handle(GetAllPets request, CancellationToken cancellationToken)
    {
        var pets = _petsRepository.GetAll();
        return Task.FromResult(pets.Select(PetDto.FromPet).ToList());
    }
}