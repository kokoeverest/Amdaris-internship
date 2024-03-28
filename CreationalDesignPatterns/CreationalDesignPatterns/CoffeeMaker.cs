namespace CreationalDesignPatterns
{
    public class CoffeeMaker
    {
        public BlackCoffee Coffee { get; set; } = new ();
        public Sugar? Sugar { get; set; } = null;
        public SoyMilk? SoyMilk { get; set; } = null;
        public OatMilk? OatMilk { get; set; } = null;
        public CowMilk? CowMilk { get; set; } = null;
        public ICoffeeType? CoffeeMachine { get; set; } = null;
        public List<IIngredient> Additions { get; set; } = [];


        public void MakeCoffee()
        {
            var welcomeText = "What coffee would you like?";
            var selectAdditionalsText = "Would you like to add something to your coffee?";
            var choicesCoffee = "[c] cappuccino    [e] esspresso    [f] flat white        [enter] cancel";
            var additionalIngredients = "[y] soy milk    [c] cow milk    [t] oat milk    [s] sugar    [enter] skip";

            HeatUp();
            string? answer = SelectOption($"{welcomeText}\n{choicesCoffee}");
            
            while (CoffeeMachine is null)
            {
                if (string.IsNullOrEmpty(answer))
                {
                    throw new ("Operation cancelled. Goodbye!");
                }
                CoffeeMachine = ChooseCoffeeAndMilk(answer);

                if (CoffeeMachine is null)
                {
                    answer = SelectOption($"Invalid command.\n{choicesCoffee}");
                }
            }
            string? additions = SelectOption($"{selectAdditionalsText}\n{additionalIngredients}");

            while (!string.IsNullOrEmpty(additions))
            {
                AddIngredients(additions);

                additions = SelectOption($"Something else?\n{additionalIngredients}");
            }

            CoffeeMachine.MakeCoffee(Additions);

            Rinse();
            Console.WriteLine("Goodbye :)");

        }
        public void AddIngredients(string text)
        {
            if (text == "s")
            {
                Additions.Add(Sugar is not null ? Sugar : new Sugar());
            }
            else if (text == "c")
            {
                Additions.Add(CowMilk is not null ? CowMilk : new CowMilk());
            }
            else if (text == "y")
            {
                Additions.Add(SoyMilk is not null ? SoyMilk : new SoyMilk());
            }
            else if (text == "t")
            {
                Additions.Add(OatMilk is not null ? OatMilk : new OatMilk());
            }
        }

        public ICoffeeType? ChooseCoffeeAndMilk(string answer)
        {
            if ( answer == "c")
            {
                var milkType = ChooseMilkType();
                return new Cappuccino(Coffee, milkType);
            }
            else if ( answer == "e")
            {
                return new Espresso(Coffee);
            }
            else if (answer == "f")
            {
                var milkType = ChooseMilkType();
                return new FlatWhite(Coffee, milkType);
            }
            return null;
        }

        public static IIngredient ChooseMilkType()
        {
            var milkOptions = "[y] soy milk    [c] cow milk    [t] oat milk";
            
            var choice = SelectOption($"Select milk type:\n{milkOptions}");
            
            if (choice == "y")
            {
                return new SoyMilk();
            }
            else if (choice == "c")
            {
                return new CowMilk();
            }
            else if (choice == "t")
            {
                return new OatMilk();
            }
            
            return ChooseMilkType();
        }
        public static string? SelectOption(string text)
        {
            Console.WriteLine(text);
            string? answer = Console.ReadLine();
            if (!string.IsNullOrEmpty(answer))
            {
                return answer.ToLower();;
            }
            return null;

        }

        public static void HeatUp()
        {
            Console.WriteLine("Hello! Heating up the machine, please wait...\n");
            Thread.Sleep(5000);
        }

        public static void Rinse()
        {
            Console.WriteLine("Rinsing the machine...\n");
            Thread.Sleep(5000);
        }
    }
}
