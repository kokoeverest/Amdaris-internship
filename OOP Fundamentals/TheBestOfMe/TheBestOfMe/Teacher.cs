using TheBestOfMe;

namespace TheBestOfMe
{
    internal class Teacher: Person
    {
        protected string _proffession;

        public Teacher(string proffession = "Highschool teacher")
        {
            _proffession = proffession;
        }
        public string Proffession { get { return _proffession; } set { _proffession = value; } }
    
        public new void Work(string work) => Console.WriteLine(work);
        public int Work(int a, int b) => a + b;
    }
}
