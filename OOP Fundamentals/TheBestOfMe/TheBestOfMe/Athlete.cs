using StaticVsNonstatic;

namespace TheBestOfMe
{
    public class Athlete: Person
    {
        private string _sport;
        public string Sport { get { return _sport; } }

        public Athlete(string sport)
        {
            _sport = sport;
        }
    public new void Work(string work) => Console.WriteLine(work);
    }
}
