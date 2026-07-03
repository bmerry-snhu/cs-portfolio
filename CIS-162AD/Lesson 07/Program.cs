namespace Lesson_07
{
    class Program
    {
        const int MaxAnimals = 100;
        static Animal[] animals = new Animal[MaxAnimals];
        static int currentAnimals = 0;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Animal Farm!");
            do
            {
                displayMenu();

                int input = getInput();

                switch(input)
                {
                    case 1:
                        // Enter an animal
                        addAnimal();
                        break;
                    case 2:
                        // Have all animals speak
                        animalsSpeak();
                        break;
                    case 3:
                        // Exit
                        Console.WriteLine("Goodbye.");
                        return;
                    default:
                        // Invalid
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
            }while(true);
        }

        static void displayMenu()
        {
            Console.WriteLine("\n1. Enter an animal");
            Console.WriteLine("2. Have all animals speak");
            Console.WriteLine("3. Exit");
        }

        static int getInput()
        {
            Console.Write("Input: ");
            string input = Console.ReadLine();
            int choice;
            if (int.TryParse(input, out choice))
            {
                return choice;
            }
            else
            {
                return 0;
            }
        }

        static void addAnimal()
        {
            if (currentAnimals >= MaxAnimals)
            {
                Console.WriteLine("Maximum allowable number of animals reached.");
                return;
            }

            Console.WriteLine("Select an animal type:");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.WriteLine("3. Pig");
            Console.WriteLine("4. Cow");

            int input = getInput();

            Animal newAnimal;

            switch(input)
            {
                case 1:
                    // Dog
                    newAnimal = new Dog();
                    break;
                case 2:
                    // Cat
                    newAnimal = new Cat();
                    break;
                case 3:
                    // Pig
                    newAnimal = new Pig();
                    break;
                case 4:
                    // Cow
                    newAnimal = new Cow();
                    break;
                default:
                    // Invalid
                    Console.WriteLine("Invalid animal choice. Please try again.");
                    return;
            }

            Console.Write("Enter the animal's name: ");
            newAnimal.setName(Console.ReadLine());

            animals[currentAnimals++] = newAnimal;
        }

        static void animalsSpeak()
        {
            if (currentAnimals == 0)
            {
                Console.WriteLine("There are no animals in the animal farm.");
            }
            else
            {
                Console.WriteLine("The animals all speak:");
                for (int i = 0; i < currentAnimals; i++)
                {
                    animals[i].Speak();
                }
            }
        }
    }
}