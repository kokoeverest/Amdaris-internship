namespace DebuggingAndExceptions
{
    public class Race
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public DateTime RaceDate { get; set; }
        public int Sport { get; set; }
        public int MaxCompetitors { get; set; }
        public List<Athlete> Competitors { get; set; }

        public Race(string name, int distance, string raceDate, int maxCompetitors, int sport)
        {
            Name = name;
            Distance = distance;
            RaceDate = DateTime.Parse(raceDate);
            Sport = sport;
            MaxCompetitors = maxCompetitors;
            Competitors = [];
        }
        public bool Register(Athlete athlete)
        {
            if (athlete.GetSport != Sport)
            {
                throw new InvalidDataException("Your sport does not match the race sport!");
            }
            if (Competitors.Count >= MaxCompetitors)
            {
                throw new InvalidDataException("Maximum number of competitors is reached for this race!");
            }
            if (RaceDate < DateTime.Now)
            {
                throw new InvalidDataException("This race is already completed!");
            }
            Competitors.Add(athlete);

            Console.WriteLine($"{athlete.Name} registered successfully for {Name}!");
            
            return true;
        }
        public void Execute()
        {
            foreach (var athlete in Competitors)
            {
                athlete.Compete(this);
            }
        }
    }
}
