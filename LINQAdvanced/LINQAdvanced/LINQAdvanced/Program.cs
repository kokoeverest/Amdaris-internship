
List<string> l1 = ["1", "2", "3", "4", "a"];
List<string> l2 = ["a", "b", "c"];

var result = l1.Zip(l2, (a, b) => $"{b}{a}{b}");

//Console.WriteLine(string.Join("\n", result));
Console.WriteLine(string.Join(", ", l1.Concat(l2).ToList()));
Console.WriteLine(l1.SequenceEqual(l1));