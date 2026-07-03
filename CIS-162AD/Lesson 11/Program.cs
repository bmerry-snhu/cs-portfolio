namespace Lesson_11
{
    delegate void Noise();
    
    class Program
    {
        static List<Animal> animals = new List<Animal>();
        static List<Noise> animalSounds = new List<Noise>();
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Animal Farm: Delegate Edition!");
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
#pragma warning disable 8600
            string input = Console.ReadLine();
#pragma warning restore 8600
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
            Console.WriteLine("Select an animal type:");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.WriteLine("3. Pig");
            Console.WriteLine("4. Cow");

            int input = getInput();

            Animal newAnimal;
            Noise newAnimalNoise;

            switch(input)
            {
                case 1:
                    // Dog
                    newAnimal = new Dog();
                    newAnimalNoise = newAnimal.Speak;
                    break;
                case 2:
                    // Cat
                    newAnimal = new Cat();
                    newAnimalNoise = newAnimal.Speak;
                    break;
                case 3:
                    // Pig
                    newAnimal = new Pig();
                    newAnimalNoise = newAnimal.Speak;
                    break;
                case 4:
                    // Cow
                    newAnimal = new Cow();
                    newAnimalNoise = newAnimal.Speak;
                    break;
                default:
                    // Invalid
                    Console.WriteLine("Invalid animal choice. Please try again.");
                    return;
            }

            Console.Write("Enter the animal's name: ");
#pragma warning disable 8604
            newAnimal.setName(Console.ReadLine());
#pragma warning restore 8604

            animals.Add(newAnimal);
            animalSounds.Add(newAnimalNoise);
        }

        static void animalsSpeak()
        {
            if (animals.Count == 0)
            {
                Console.WriteLine("There are no animals in the animal farm.");
            }
            else
            {
                Console.WriteLine("The animals all speak:");
                foreach (Noise speak in animalSounds)
                    speak();
            }
        }
    }
}