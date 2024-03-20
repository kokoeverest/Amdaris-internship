namespace LINQAdvanced
{
    public class Athlete
    {
        private string _name;
        private SportEnum _sport;
        private int TotalDistance { get; set; }
        private int TotalMinutes { get; set; }
        private int MaxDistance {  get; set; }
        private int MaxHours { get; set; }

        public Athlete(string name, SportEnum sport)
        {
            _name = name; _sport = sport; Race = null;
        }
        public string Name => _name;
        public Race? Race { get; set; }
        public SportEnum GetSport => _sport;
        public int HardestWorkout => MaxHours;
        public int LongestRun => MaxDistance;
        public int GetTotalHours => TotalMinutes / 60;
        public int GetTotalDistance => TotalDistance;
        internal bool AddRace(Race race)
        {
            Race = race;
            return true;
        }
        public bool RemoveRace()
        {
            if (Race != null)
            {
                return false;
            }
            Race = null;
            return true;
        }
        public int Compete(Race race)
        {
            if ((TotalDistance < race.Distance * 2) || (GetTotalHours < race.Distance) || (MaxDistance < race.Distance / 2) || (MaxHours < race.Distance))
            {
                Console.WriteLine($"{_name} can't finish {race.Name} because of insufficient training...");
                return 0;
            }

            if ((TotalDistance > race.Distance * 4) && (MaxDistance > race.Distance / 2) && (MaxHours > race.Distance * 2))
            {
                Console.WriteLine($"{_name} could finish first in this race!!!");
                return 1;
            }
            else if ((TotalDistance > race.Distance * 2) && (MaxDistance > race.Distance / 2) && (MaxHours > race.Distance))
            {
                Console.WriteLine($"{_name} could finish in the middle in this race.");
                return 2;
            }
            else
            {
                Console.WriteLine($"{_name} could finish in the last in this race.");
                return 3;
            }
        }
    }
}
