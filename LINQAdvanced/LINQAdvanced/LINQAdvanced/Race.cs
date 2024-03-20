namespace LINQAdvanced
{
    public class Race
    {
        public Race(string name, int distance, string raceDate, int maxCompetitors, SportEnum sport)
        {
            Name = name;
            Distance = distance;
            RaceDate = DateTime.Parse(raceDate);
            Sport = sport;
            MaxCompetitors = maxCompetitors;
            Competitors = [];
        }

        public string Name { get; set; }
        public int Distance { get; set; }
        public DateTime RaceDate { get; set; }
        public SportEnum Sport { get; set; }
        public int MaxCompetitors { get; set; }
        public List<Athlete> Competitors { get; set; }

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
            athlete.AddRace(this);
            Console.WriteLine($"{athlete.Name} registered successfully for {Name}!");

            return true;
        }
        
    }
}