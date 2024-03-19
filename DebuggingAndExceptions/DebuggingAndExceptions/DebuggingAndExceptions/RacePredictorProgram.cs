



//Assignment Instructions

//Create methods which checks input arguments and throws exceptions​
//Create custom exceptions and throw them ​
//Write try-catch-finally block with multiple catch statements​
//Rethrow exception​s
//Add conditional compilation symbols

// example: running race and all the exceptions that can arise during it 
// how to handle different scenarions when specific exceptions (injuries) occur

namespace DebuggingAndExceptions
{

    public class RacePredictor
    {
        public static void Main(string[] args)
        { 
            Race pirinUltra = new(name: "Pirin ultra 160", distance: 160, raceDate: "20/09/2024", maxCompetitors: 2, sport: 0);
            Athlete pesho = new(name: "Petar", sport: 0);
            Athlete gosho = new(name: "Georgi", sport: 0);
            Athlete sasho = new(name: "Sasho", sport: 0);
            try
            {
#if DEBUG
                PeshoTraining(pesho);
#endif
                pesho.AddRace(pirinUltra);
                gosho.AddRace(pirinUltra);
                sasho.AddRace(pirinUltra);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                pirinUltra.Execute();
            }
        }
#if (DEBUG)
        public static void PeshoTraining(Athlete athlete)
        {
            athlete.Train(60, 10);
            athlete.Train(120, 20);
            athlete.Train(120, 25);
            athlete.Train(180, 40);
            athlete.Train(300, 50);
            athlete.Train(68, 10);
            athlete.Train(130, 20);
            athlete.Train(101, 18);
            athlete.Train(140, 28);
            athlete.Train(120, 25);
            athlete.Train(220, 40);
            athlete.Train(55, 10);
            athlete.Train(60, 10);
            athlete.Train(120, 20);
            athlete.Train(120, 25);
            athlete.Train(180, 40);
            athlete.Train(300, 50);
            athlete.Train(68, 10);
            athlete.Train(130, 20);
            athlete.Train(101, 18);
            athlete.Train(140, 28);
            athlete.Train(120, 25);
            athlete.Train(220, 40);
            athlete.Train(60, 10);
            athlete.Train(120, 20);
            athlete.Train(120, 25);
            athlete.Train(180, 40);
            athlete.Train(660, 82);
            athlete.Train(68, 10);
            athlete.Train(130, 20);
            athlete.Train(101, 18);
            athlete.Train(140, 28);
            athlete.Train(120, 25);
            athlete.Train(220, 40);
            athlete.Train(55, 10);
            athlete.Train(60, 10);
            athlete.Train(120, 20);
            athlete.Train(120, 25);
            athlete.Train(180, 40);
            athlete.Train(300, 50);
            athlete.Train(68, 10);
            athlete.Train(130, 20);
            athlete.Train(101, 18);
            athlete.Train(140, 28);
            athlete.Train(120, 25);
            athlete.Train(220, 40);
            athlete.Train(60, 10);
            athlete.Train(120, 20);
            athlete.Train(120, 25);
            athlete.Train(180, 40);
            athlete.Train(300, 50);
            athlete.Train(68, 10);
            athlete.Train(130, 20);
            athlete.Train(101, 18);
            athlete.Train(140, 28);
            athlete.Train(120, 25);
            athlete.Train(220, 40);
            athlete.Train(55, 10);
            athlete.Train(60, 10);
            athlete.Train(120, 20);
            athlete.Train(120, 25);
            athlete.Train(180, 40);
            athlete.Train(300, 50);
            athlete.Train(68, 10);
            athlete.Train(130, 20);
            athlete.Train(101, 18);
            athlete.Train(140, 28);
            athlete.Train(120, 25);
            athlete.Train(220, 40);
            athlete.Train(60, 10);
            athlete.Train(120, 20);
            athlete.Train(120, 25);
            athlete.Train(180, 40);
            athlete.Train(300, 50);
            athlete.Train(68, 10);
            athlete.Train(130, 20);
            athlete.Train(101, 18);
            athlete.Train(140, 28);
            athlete.Train(120, 25);
            athlete.Train(220, 40);
            athlete.Train(55, 10);
            athlete.Train(60, 10);
            athlete.Train(120, 20);
            athlete.Train(120, 25);
            athlete.Train(180, 40);
            athlete.Train(300, 50);
            athlete.Train(68, 10);
            athlete.Train(130, 20);
            athlete.Train(101, 18);
            athlete.Train(140, 28);
            athlete.Train(120, 25);
            athlete.Train(220, 40);
        }
#endif 
    }
}