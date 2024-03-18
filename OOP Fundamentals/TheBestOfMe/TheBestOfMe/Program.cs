using TheBestOfMe;

namespace TheBestOfMe
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var dateString = "1983, 9, 30";
            var sport = "football";
            string proffession = "Chemistry";
            string teacherName = "Petar Beron";

            Person person1 = new Person(dateString);
            Athlete athlete = new Athlete(sport);
            Teacher teacher = new Teacher();
            try
            {
                person1.Name = "Kaloyan";
                person1.Email = "kaloyan@google.com";
                athlete.Name = "Hristo Stoichkov";
                Console.WriteLine(teacher.Proffession);
                teacher.Name = teacherName;
                teacher.Proffession = proffession;

            }
            catch  (ApplicationException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                //// instantiating the objects.
                //Console.WriteLine(person1.Age);
                //Console.WriteLine(person1.Name);
                //Console.WriteLine(person1.Email);
                //Console.WriteLine(athlete.Name);
                //Console.WriteLine(athlete.Sport);
                //Console.WriteLine(teacher.Proffession);
                //athlete.Work("I am an athlete and I excercise to live");
                //teacher.Work("I live to teach others");
                //int a = 5, b = 10;
                //int result = teacher.Work(a, b);
                //Console.WriteLine($"Teacher calculated {a} + {b} = {result}");

                // implementing the IEnumerable interface.
                Person[] peopleArray = new Person[3]
                {
                    person1,
                    athlete,
                    teacher,
                };

                People peoplelist = new People(peopleArray);
               
                var something = peoplelist.GetEnumerator();
                
                while (something.MoveNext())
                    Console.WriteLine(something.Current);

                //foreach (Person person in peoplelist)
                //    Console.WriteLine(person.Age);

                // implementing the ICloneable interface.
                Teacher teacher2 = (Teacher)teacher.Clone();
                Console.WriteLine(teacher2.Proffession);
                teacher.Proffession = "new profession";
                teacher2.Proffession = "another profession";

                Console.WriteLine(teacher.Proffession);
                Console.WriteLine(teacher2.Proffession);
            }
      
        }
        
    }
    
}
