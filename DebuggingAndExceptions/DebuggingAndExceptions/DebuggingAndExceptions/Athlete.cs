using CustomExceptions;

namespace DebuggingAndExceptions
{
    public class Athlete
    {
        public string Name { get; set; }
        private int Sport { get; set; }
        private int TotalDistance { get; set; }
        private int TotalMinutes { get; set; }
        private int MaxDistance {  get; set; }
        private int MaxHours { get; set; }
        public HashSet<Race> Goals { get; set; }
        public Athlete(string name, int sport)
        {
            Name = name; Sport = sport; Goals = [];
        }
        public bool AddRace(Race race)
        {
            if (Goals.Contains(race))
            {
                throw new RaceExistExeption("You are already registered for this race!");
            }
            try
            {
                race.Register(this);
            }
            catch (InvalidDataException)
            {
                throw;
            }

            Goals.Add(race);
            return true;

        }
        public bool RemoveRace(Race race)
        {
            if (!Goals.Contains(race))
            {
                return false;
            }
            Goals.Remove(race);
            return true;
        }
        public int Compete(Race race)
        {
            if ((TotalDistance < race.Distance * 2) || (GetTotalHours < race.Distance) || (MaxDistance < race.Distance / 2) || (MaxHours < race.Distance))
            {
                Console.WriteLine($"{Name} can't finish {race.Name} because of insufficient training...");
                return (int) RaceEnum.DNF;
            }
            
            if ((TotalDistance > race.Distance * 4) && (MaxDistance > race.Distance / 2) && (MaxHours > race.Distance * 2))
            {
                Console.WriteLine($"{Name} could finish first in this race!!!");
                return (int)RaceEnum.First;
            }
            else if ((TotalDistance > race.Distance * 2) && (MaxDistance > race.Distance / 2) && (MaxHours > race.Distance))
            {
                Console.WriteLine($"{Name} could finish in the middle in this race.");
                return (int)(RaceEnum.Middle);
            }
            else
            {
                Console.WriteLine($"{Name} could finish in the last in this race.");
                return (int)RaceEnum.Last;
            }
        }
        public bool Train(int durationMinutes, int distanceKilometers)
        {
            if (durationMinutes < 40)
            {
                throw new UnderTraingException("This workout is not enough for you!");
            }
            else if (durationMinutes > 720)
            {
                throw new OverTrainingException("Risk of overtraing!");
            }
            if  (distanceKilometers < 2)
            {
                throw new UnderTraingException("This workout is too short!");
            }
            else if (distanceKilometers > 100)
            {
                throw new OverTrainingException("This workout is too long!");
            }

            TotalDistance += distanceKilometers;
            TotalMinutes += durationMinutes;

            if (distanceKilometers > MaxDistance)
            {
                MaxDistance = distanceKilometers;
            }
            if (durationMinutes > MaxHours)
            {
                MaxHours = durationMinutes;
            }
            return true;
        }
        public int GetSport => Sport;
        public int HardestWorkout => MaxHours;
        public int LongestRun => MaxDistance;
        public int GetTotalHours => TotalMinutes / 60;
    }
}
