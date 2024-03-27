namespace CreationalDesignPatterns
{
    public class CoffeeMaker
    {
        public BlackCoffee Coffee { get; set; } = new();
        public Sugar Sugar { get; set; } = new();
        public SoyMilk SoyMilk { get; set; } = new();
        public OatMilk OatMilk { get; set; } = new();
        public CowMilk CowMilk { get; set; } = new();
        public ICoffeeMachine? CoffeeMachine { get; set; } = null;
        public List<IIngredient> Additions { get; set; } = [];


        public void MakeCoffee()
        {
            var welcomeText = "What coffee would you like?";
            var selectAdditionalsText = "Would you like to add something to your coffee?";
            var choicesCoffee = "[c] cappuccino    [e] esspresso    [f] flat white        [enter] cancel";
            var additionalIngredients = "[y] soy milk    [c] cow milk    [t] oat milk    [s] sugar    [enter] skip";

            WarmUp();
            string? answer = SelectOption($"{welcomeText}\n{choicesCoffee}");
            
            while (CoffeeMachine is null)
            {
                if (answer == "")
                {
                    throw new ("Operation cancelled. Goodbye!");
                }
                CoffeeMachine = ChooseMachine(answer);

                if (CoffeeMachine is null)
                {
                    answer = SelectOption($"Invalid command.\n{choicesCoffee}");
                }
            }
            string? additions = SelectOption($"{selectAdditionalsText}\n{additionalIngredients}");

            while (additions != "")
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
                Additions.Add(Sugar);
            }
            else if (text == "c")
            {
                Additions.Add(CowMilk);
            }
            else if (text == "y")
            {
                Additions.Add(SoyMilk);
            }
            else if (text == "t")
            {
                Additions.Add(OatMilk);
            }
        }

        public ICoffeeMachine? ChooseMachine(string answer)
        {
            if ( answer == "c")
            {
                var milkType = ChooseMilkType();
                return new CappuccinoMachine(Coffee, milkType);
            }
            else if ( answer == "e")
            {
                return new EspressoMachine(Coffee);
            }
            else if (answer == "f")
            {
                var milkType = ChooseMilkType();
                return new FlatWhiteCoffeeMachine(Coffee, milkType);
            }
            return null;
        }

        public IIngredient ChooseMilkType()
        {
            var milkOptions = "[y] soy milk    [c] cow milk    [t] oat milk";
            
            var choice = SelectOption($"Select milk type:\n{milkOptions}");
            
            if (choice == "y")
            {
                return SoyMilk;
            }
            else if (choice == "c")
            {
                return CowMilk;
            }
            else if (choice == "t")
            {
                return OatMilk;
            }
            
            return ChooseMilkType();
        }
        public static string? SelectOption(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine().ToLower();

        }

        public void WarmUp()
        {
            Console.WriteLine("Hello! Heating up the machine, please wait...\n");
            Thread.Sleep(5000);
        }

        public void Rinse()
        {
            Console.WriteLine("Rinsing the machine...\n");
            Thread.Sleep(5000);
        }
    }
}
