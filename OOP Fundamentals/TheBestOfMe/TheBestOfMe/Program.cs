using StaticVsNonstatic;

namespace TheBestOfMe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var dateString = "1983, 9, 30";
            var sport = "football";
            string proffession = "Chemistry";

            Person person1 = new Person(dateString);
            Athlete athlete = new Athlete(sport);
            Teacher teacher = new Teacher();
            try
            {
                person1.Name = "Kaloyan";
                person1.Email = "kaloyan@google.com";
                athlete.Name = "Hristo Stoichkov";
                Console.WriteLine(teacher.Proffession);
                teacher.Proffession = proffession;

            }
            catch  (ApplicationException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine(person1.Age);
                Console.WriteLine(person1.Name);
                Console.WriteLine(person1.Email);
                Console.WriteLine(athlete.Name);
                Console.WriteLine(athlete.Sport);
                Console.WriteLine(teacher.Proffession);
                athlete.Work("I am an athlete and I excercise to live");
                teacher.Work("I live to teach others");
                int a = 5, b = 10;
                int result = teacher.Work(a, b);
                Console.WriteLine($"Teacher calculated {a} + {b} = {result}");
            }
      
        }
        
    }
    
}

