using LINQAdvanced;

//  Assignment requirements
//  Create a console application and do the following:

//  1.Create one or more sequences and use at least one operator of each type

//  2. Create an example for each learned method

// Call the methods for the execution of each example, much better in debug mode :)
List<string> stringNumbers = ["1", "2", "3", "4", "a"];
List<string> letters = ["a", "b", "c"];

Athlete pesho = new("Pesho", SportEnum.MountainRunning);
Athlete gosho = new("Gosho", SportEnum.MountainRunning);
Athlete misho = new("Misho", SportEnum.MountainRunning);
Athlete ivanM = new("Ivan", SportEnum.MountainRunning);
Athlete ivanR = new("Ivan", SportEnum.RoadRunning);
Athlete stoyan = new("Stoyan", SportEnum.MountainRunning);
Athlete kaloyan = new("Kaloyan", SportEnum.MountainRunning);
Athlete mitko = new("Mitko", SportEnum.RoadRunning);
Athlete dimitarM = new("Dimitar", SportEnum.MountainRunning);
Athlete dimitarR = new("Dimitar", SportEnum.RoadRunning);
Athlete stefan = new("Stefan", SportEnum.RoadRunning);
Athlete stanimir = new("Stanimir", SportEnum.MountainRunning);

Race pirin = new("Pirin extreme", 38, "20/9.2024", 10, SportEnum.MountainRunning);
Race kozhaKaya = new("Kodhza kaya", 85, "12/5/2024", 20, SportEnum.MountainRunning);
Race sofiaMarathon = new("Sofia marathon", 42, "10/10/2024", 200, SportEnum.RoadRunning);


List<Athlete> athletes =
[
    pesho,
    gosho,
    misho,
    ivanM,
    stoyan,
    kaloyan,
    mitko,
    dimitarR,
    dimitarM,
    ivanR,
    stefan,
    stanimir
];
List<Race> races = [
    pirin,
    kozhaKaya,
    sofiaMarathon
    ];
void RegisterPlayers()
{
    pirin.Register(pesho);
    pirin.Register(gosho);
    pirin.Register(misho);
    pirin.Register(ivanM);
    sofiaMarathon.Register(ivanR);
    kozhaKaya.Register(stoyan);
    kozhaKaya.Register(kaloyan);
    sofiaMarathon.Register(mitko);
    kozhaKaya.Register(dimitarM);
    sofiaMarathon.Register(dimitarR);
    sofiaMarathon.Register(stefan);
    kozhaKaya.Register(stanimir);
    Console.WriteLine();
}
void JoinZipAndSetOperatorsExamples()
{
    var resultZip = stringNumbers.Zip(letters, (a, b) => $"{b}{a}{b}");
    var resultJoin = stringNumbers.Join(letters, symbol1 => symbol1, name => name, (symbol1, name) => new { Symbol = symbol1, SymbolName = name });
    var concatExample = stringNumbers.Concat(letters).ToList();
    var unionExample = stringNumbers.Union(letters).ToList();
    var intersectExample = stringNumbers.Intersect(letters).ToList();
    var exceptExample = stringNumbers.Except(letters).ToList();

    Console.WriteLine(string.Join("\n", resultJoin));
    Console.WriteLine(string.Join("\n", resultZip));
    Console.WriteLine(string.Join(", ", concatExample));
    Console.WriteLine(string.Join(", ", unionExample));
    Console.WriteLine(string.Join(", ", intersectExample));
    Console.WriteLine(string.Join(", ", exceptExample));
    Console.WriteLine(stringNumbers.SequenceEqual(stringNumbers));
}
void GroupJoinExamples()
{
    RegisterPlayers();
    var resultGroupJoin = races.GroupJoin(athletes,
        raceName => raceName.Name,
        athleteName => athleteName.Race?.Name,
        (race, athlete) => new { Race = race, AthleteName = athlete });

    foreach (var group in resultGroupJoin)
    {
        Console.WriteLine($"{group.Race.Name}, {group.Race.Distance} km, {group.Race.RaceDate.Date.ToShortDateString()}:");
        foreach (var competitor in group.AthleteName)
        {
            Console.WriteLine($"    - {competitor.Name}");
        }
    }
    Console.WriteLine();
    // Equal to this example
    foreach (var competition in races)
    {
        Console.WriteLine($"{competition.Name}:\n    -{string.Join("\n    -", competition.Competitors.Select(competitor => competitor.Name).ToList())}");
    }
}

void GroupByExamples()
{
    RegisterPlayers();
    var raceGroups = races.GroupBy(races => races.Sport)
        .Select(raceGroup => new
        {
            sport = raceGroup.Key,
            races = raceGroup.ToList()
        })
        .ToList();
    foreach (var group in raceGroups)
    {
        int totalAthletes = 0;

        foreach (var currentRace in group.races)
        {
            totalAthletes += currentRace.Competitors.Count;

        }
        Console.WriteLine($"{group.sport}: {group.races.Count} races with {totalAthletes} competitors");
        
    }
}

List<int> numbers = [2, 1, 1, 3, 12, 44, 17, 91, 990, -2];
var emptyArray = Enumerable.Empty<int>();
void AggregationAndQuantifiersMethodsExamples()
{
    Console.WriteLine(numbers.Count);
    Console.WriteLine(numbers.Min());
    Console.WriteLine(numbers.Max());
    Console.WriteLine(numbers.Sum());
    Console.WriteLine(numbers.Average());
    Console.WriteLine(numbers.Contains(1));
    Console.WriteLine(numbers.Any(number => number % 2 == 0));
    Console.WriteLine(numbers.All(number => number > 0));
}

void ElementOperatorsExamples()
{
    var firstElement = numbers.First();
    var defaultElement = emptyArray.FirstOrDefault(100);
    try
    {
        var singleElement = numbers.Single();
    }
    catch (InvalidOperationException)
    {
        // nothing happens
    }
    finally
    {

        var elementAt = numbers.ElementAtOrDefault(6);
        var defaultOrEmpty = numbers.DefaultIfEmpty(0);

        Console.WriteLine(firstElement);
        Console.WriteLine(defaultElement);
        Console.WriteLine(elementAt);
        Console.WriteLine(defaultOrEmpty.Count());
    }

    var repeat = Enumerable.Repeat(3, 15);
    var range = Enumerable.Range(1, firstElement);
    
    Console.WriteLine(emptyArray.Count());
    Console.WriteLine(repeat.Count());
    Console.WriteLine(range.Last());
}
//GroupJoinExamples();
//JoinZipAndSetOperatorsExamples();
//GroupByExamples();
//AggregationAndQuantifiersMethodsExamples();
//ElementOperatorsExamples();
