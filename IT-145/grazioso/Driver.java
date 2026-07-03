import java.util.ArrayList;
import java.util.Scanner;

public class Driver {
    private static ArrayList<Dog> dogList = new ArrayList<Dog>();
    //  ADDED 20260210 (bmerry): Monkey list required for intakeNewMonkey()
    private static ArrayList<Monkey> monkeyList = new ArrayList<Monkey>();

    //  Instance variables (if needed)

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String selection;

        initializeDogList();
        initializeMonkeyList();

        //  ADDED 20260210 (bmerry): Menu selection w/ input validation
        do {
            displayMenu();
            selection = scanner.nextLine();

            switch(selection) {
                case "1":
                    intakeNewDog(scanner);
                    break;
                case "2":
                    intakeNewMonkey(scanner);
                    break;
                case "3":
                    reserveAnimal(scanner);
                    break;
                case "4":
                    printAnimals("dog");
                    break;
                case "5":
                    printAnimals("monkey");
                    break;
                case "6":
                    printAnimals("available");
                    break;
                case "q":
                case "Q":
                    System.out.println("Goodbye!");
                    break;
                default:
                    System.out.println("Invalid selection. Please choose menu item 1 thru 6 or q to quit.");
                    break;
            }
        } while (!selection.equalsIgnoreCase("q"));
    }

    //  This method prints the menu options
    public static void displayMenu() {
        System.out.println("\n\n");
        System.out.println("\t\t\t\tRescue Animal System Menu");
        System.out.println("[1] Intake a new dog");
        System.out.println("[2] Intake a new monkey");
        System.out.println("[3] Reserve an animal");
        System.out.println("[4] Print a list of all dogs");
        System.out.println("[5] Print a list of all monkeys");
        System.out.println("[6] Print a list of all animals that are not reserved");
        System.out.println("[q] Quit application");
        System.out.println();
        System.out.println("Enter a menu selection");
    }


    //  Adds dogs to a list for testing
    public static void initializeDogList() {
        Dog dog1 = new Dog("Spot", "German Shepherd", "male", "1", "25.6", "05-12-2019", "United States", "intake", false, "United States");
        Dog dog2 = new Dog("Rex", "Great Dane", "male", "3", "35.2", "02-03-2020", "United States", "Phase I", false, "United States");
        Dog dog3 = new Dog("Bella", "Chihuahua", "female", "4", "25.6", "12-12-2019", "Canada", "in service", true, "Canada");

        dogList.add(dog1);
        dogList.add(dog2);
        dogList.add(dog3);
    }


    //  Adds monkeys to a list for testing
    public static void initializeMonkeyList() {
        Monkey monkey1 = new Monkey("Wrinkly Kong", "Capuchin", "female", "99", "12.3", "01-01-1995", "Brazil", "in service", true,
                                    "United States", "18.0", "24.0", "20.0");
        Monkey monkey2 = new Monkey("Donkey Kong", "Macaque", "male", "39", "123.45", "01-01-1994", "Brazil", "in service", false,
                                    "United States", "36.0", "48.0", "40.0");
        Monkey monkey3 = new Monkey("Mankey Kong", "Squirrel Monkey", "male", "41", "23.45", "01-01-1998", "Brazil", "in service", false,
                                    "United States", "27.0", "36.0", "30.0");

        monkeyList.add(monkey1);
        monkeyList.add(monkey2);
        monkeyList.add(monkey3);
    }

    //  Takes the intake details of a new dog
    public static void intakeNewDog(Scanner scanner) {
        System.out.println("What is the dog's name?");
        String name = scanner.nextLine();
        for(Dog dog: dogList) {
            if(dog.getName().equalsIgnoreCase(name)) {
                System.out.println("\n\nThis dog is already in our system\n\n");
                return; //returns to menu
            }
        }

        //  ADDED 20260210 (bmerry): Prompt for remaining dog fields
        System.out.println("What is the dog's breed?");
        String breed = scanner.nextLine();

        System.out.println("What is the dog's gender?");
        String gender = scanner.nextLine();

        System.out.println("What is the dog's age?");
        String age = scanner.nextLine();

        System.out.println("What is the dog's weight?");
        String weight = scanner.nextLine();

        System.out.println("What is the acquisition date?");
        String acquisitionDate = scanner.nextLine();

        System.out.println("What is the acquisition country?");
        String acquisitionCountry = scanner.nextLine();

        System.out.println("What is the training status?");
        String trainingStatus = scanner.nextLine();

        System.out.println("Is the dog reserved? (true/false)");
        boolean reserved = Boolean.parseBoolean(scanner.nextLine());

        System.out.println("What is the in-service country?");
        String inServiceCountry = scanner.nextLine();

        Dog newDog = new Dog(name, breed, gender, age, weight, acquisitionDate, acquisitionCountry, trainingStatus,
                                reserved, inServiceCountry);

        dogList.add(newDog);
        System.out.println(name + " successfully added to the list of dogs.");
    }

    //  ADDED 20260210 (bmerry): Takes the intake details of a new monkey
    public static void intakeNewMonkey(Scanner scanner) {
        System.out.println("What is the monkey's name?");
        String name = scanner.nextLine();
        for (Monkey monkey: monkeyList) {
            if(monkey.getName().equalsIgnoreCase(name)) {
                System.out.println("\n\nThis monkey is already in our system\n\n");
                return; //returns to menu
            }
        }

        System.out.println("What is the monkey's species?");
        String species = scanner.nextLine();

        if (!isValidMonkeySpecies(species)) {
            System.out.println("Invalid species. Please enter one of the following: Capuchin, Guenon, Macaque, Marmoset, Squirrel Monkey, Tamarin.");
            return; //returns to menu
        }

        System.out.println("What is the monkey's gender?");
        String gender = scanner.nextLine();

        System.out.println("What is the monkey's age?");
        String age = scanner.nextLine();

        System.out.println("What is the monkey's weight?");
        String weight = scanner.nextLine();

        System.out.println("What is the acquisition date?");
        String acquisitionDate = scanner.nextLine();

        System.out.println("What is the acquisition country?");
        String acquisitionCountry = scanner.nextLine();

        System.out.println("What is the training status?");
        String trainingStatus = scanner.nextLine();

        System.out.println("Is the monkey reserved? (true/false)");
        boolean reserved = Boolean.parseBoolean(scanner.nextLine());

        System.out.println("What is the in-service country?");
        String inServiceCountry = scanner.nextLine();

        System.out.println("What is the monkey's tail length?");
        String tailLength = scanner.nextLine();

        System.out.println("What is the monkey's height?");
        String height = scanner.nextLine();

        System.out.println("What is the monkey's body length?");
        String bodyLength = scanner.nextLine();

        Monkey newMonkey = new Monkey(name, species, gender, age, weight, acquisitionDate, acquisitionCountry, trainingStatus,
                                reserved, inServiceCountry, tailLength, height, bodyLength);

        monkeyList.add(newMonkey);
        System.out.println(name + " successfully added to the list of monkeys.");
    }

    //  ADDED 20260210 (bmerry): Helper to validate species
    private static boolean isValidMonkeySpecies(String species) {
        String string = species.toLowerCase();
        return string.equals("capuchin")
                        || string.equals("guenon")
                        || string.equals("macaque")
                        || string.equals("marmoset")
                        || string.equals("squirrel monkey")
                        || string.equals("tamarin");
    }

    //  ADDED 20260210 (bmerry): Find an animal by animal type in service country
    public static void reserveAnimal(Scanner scanner) {
        System.out.println("Enter animal type (dog/monkey):");
        String animalType = scanner.nextLine().toLowerCase();

        System.out.println("Enter in-service country:");
        String country = scanner.nextLine();

        boolean reserved = false;

        if (animalType.equals("dog")) {
            for (Dog dog : dogList) {
                if (dog.getTrainingStatus().equalsIgnoreCase("in service")
                        && !dog.getReserved()
                        && dog.getInServiceCountry().equalsIgnoreCase(country)) {
                    
                    dog.setReserved(true);
                    reserved = true;
                    System.out.println("Dog reserved: " + dog.getName());
                    break;
                }
            }
        }
        else if (animalType.equals("monkey")) {
            for (Monkey monkey : monkeyList) {
                if (monkey.getTrainingStatus().equalsIgnoreCase("in service")
                        && !monkey.getReserved()
                        && monkey.getInServiceCountry().equalsIgnoreCase(country)) {
                    
                    monkey.setReserved(true);
                    reserved = true;
                    System.out.println("Monkey reserved: " + monkey.getName());
                    break;
                }
            }
        }
        else {
            System.out.println("Invalid animal type. Please enter either dog or monkey.");
            return;
        }

        if (!reserved) {
            System.out.println("No available " + animalType + " found for " + country);
        }
    }

    //  ADDED 20260210 (bmerry): Print a list of available animals based on animal type
    public static void printAnimals(String listType) {
        //  List of dogs
        if (listType.equalsIgnoreCase("dog")) {
            System.out.println("Dog list:");
            for (Dog dog : dogList) {
                System.out.println(dog.getName() + " : " + dog.getTrainingStatus() + " : " + dog.getAcquisitionLocation() + " : reserved=" + dog.getReserved());
            }
            return; //  Return to menu
        }

        //  List of monkeys
        if (listType.equalsIgnoreCase("monkey")) {
            System.out.println("Monkey list:");
            for (Monkey monkey : monkeyList) {
                System.out.println(monkey.getName() + " : " + monkey.getTrainingStatus() + " : " + monkey.getAcquisitionLocation() + " : reserved=" + monkey.getReserved());
            }
            return; //  Return to menu
        }

        //  List of available animals
        if (listType.equalsIgnoreCase("available")) {
            System.out.println("Available Animals (in service and not reserved):");

            for (Dog dog : dogList) {
                if (dog.getTrainingStatus().equalsIgnoreCase("in service") && !dog.getReserved()) {
                    System.out.println("Dog: " + dog.getName() + " : " + dog.getInServiceCountry() + " : reserved=" + dog.getReserved());
                }
            }
            for (Monkey monkey : monkeyList) {
                if (monkey.getTrainingStatus().equalsIgnoreCase("in service") && !monkey.getReserved()) {
                    System.out.println("Monkey: "+ monkey.getName() + " : " + monkey.getInServiceCountry() + " : reserved=" + monkey.getReserved());
                }
            }
            return; //  return to menu
        }

        //  Default case
        System.out.println("Unknown list type: " + listType);
    }
}

