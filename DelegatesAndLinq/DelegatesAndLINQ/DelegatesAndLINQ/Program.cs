
namespace DelegatesAndLINQ
{
    public class Program
    {
        public delegate void Print(string str);
        public static void Main(string[] args)
        {
            // Example collections
            List<User> users = [
                    new User(firstName: "John", lastName: "Doe"),
                    new User(id: 4, firstName: "Britney", lastName: "Spears"),
                    new User(firstName: "Robin", lastName: "Williams"),
                    new User(firstName: "Ivan", lastName: "Ivanov"),
                    new User(id: null, firstName: "Petar", lastName: "Stoyanov", email: "petarv@mail.bg", password: ""),
                    new User(id: 2, firstName: "Mihail", lastName: "Dimitrov"),
                    new User(id: 1, firstName: "Hristo", lastName: "Petkanov", email: "petkanov@gmail.gb", password: "")
            ];
            List<int> numbers1 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            List<int> numbers2 = [10, 20, 30, 40, 50, 60, 70, 80, 3, 100];

            // Executing the examples
            UserServices userServices = new();
            userServices._users = users;
            List<User> people = userServices.FindAll(user => user.Email != null);

            // Using delegates
            Print print = delegate (string str)
            {
                Console.WriteLine(str);
            };

            var plus = delegate (int num1, int num2)
            {
                return num1 + num2;
            };

            //foreach (User person in people)
            //{
            //    print($"{person.FirstName} {person.LastName}: {person.Email ?? "No еmail"}");
            //}
            //for (int i = 0; i < numbers1.Count; i++)
            //{
            //    Console.WriteLine(plus(numbers1[i], numbers2[i]));
            //}

            // Using lambda expressions (comment the delegate examples)

            var calculator = (int x, int y, string command = "add") =>
            {
                if (command == "sub")
                {
                    return x - y;
                }
                if (command == "mul")
                {
                    return x * y;
                }
                if (command == "div" && y != 0)
                {
                    return x / y;
                }
                return x + y;
            };
            
            Func<List<int>, int> sumList = list =>
            {
                int total = 0;
                foreach (int x in list)
                {
                    total += x;
                }
                return total;
            };

            //for (int i = 0; i < numbers1.Count; i++)
            //{
            //    Console.WriteLine(calculator(numbers1[i], numbers2[i]));
            //    Console.WriteLine(calculator(numbers1[i], numbers2[i], "mul"));
            //    Console.WriteLine(calculator(numbers1[i], numbers2[i], "div"));
            //}
            //Console.WriteLine(sumList(numbers1));
            //Console.WriteLine(sumList(numbers2));

            // Using LINQ on the collections

            var emails = users.Where(user => user.Email != null)
                              .Where(user => user.Id != null)
                              .Select(user => $"{user.Id} {user.FirstName} {user.LastName} {user.Email}");
                              
            var sortedUsers = users.OrderBy(user => user.FirstName)
                                   .Select(user => $"{user.FirstName} {user.LastName}")
                                   .Take(4);
            var sortedByLastName = from user in users
                                   where user.LastName != null
                                   orderby user.LastName
                                   select $"{user.FirstName} {user.LastName}";

            foreach (var mail in emails)
            {
                Console.WriteLine(mail);
            }
            Console.WriteLine();
            foreach (var user in sortedUsers)
            {
                Console.WriteLine(user);
            }
            Console.WriteLine();
            foreach (var user in sortedByLastName)
            {
                Console.WriteLine(user);

            }
        }
    }
}
