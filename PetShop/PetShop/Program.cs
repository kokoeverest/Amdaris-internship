using PetShop;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

var diContainer = new ServiceCollection()
    .AddSingleton<IPetsRepository, PetRepository>()
    .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IPetsRepository).Assembly))
    .BuildServiceProvider();

IMediator mediator = diContainer.GetRequiredService<IMediator>();


var eagle = await mediator.Send(new CreatePet(AnimalTypeEnum.Eagle, SpeciesEnum.Bird, SexEnum.Male, "The eagle flies high", 10000));
var tiger = await mediator.Send(new CreatePet(AnimalTypeEnum.Tiger, SpeciesEnum.Mammal, SexEnum.Female, "The tiger runs fast", 50000));
var dog = await mediator.Send(new CreatePet(AnimalTypeEnum.Dog, SpeciesEnum.Mammal, SexEnum.Male, "The dog just runs", 500));
var snake = await mediator.Send(new CreatePet(AnimalTypeEnum.Snake, SpeciesEnum.Reptile, SexEnum.Male, "The snake creeps on the ground", 1000));

var allPets = await mediator.Send(new GetAllPets());
var mammals = await mediator.Send(new GetPetsBySpecies(SpeciesEnum.Mammal));
var maleAnimals = await mediator.Send(new GetPetsBySex(SexEnum.Male));


Console.WriteLine("All pets in shop:\n");
Console.WriteLine(string.Join("\n", allPets));

Console.WriteLine("Mammals:\n");
Console.WriteLine(string.Join("\n", mammals));


Console.WriteLine("All male animals:\n");
Console.WriteLine(string.Join("\n", maleAnimals));