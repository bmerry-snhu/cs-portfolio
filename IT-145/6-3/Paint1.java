import java.util.Scanner;

public class Paint1 {

    public static void main(String[] args) {
        Scanner scnr = new Scanner(System.in);
        double wallHeight = 0.0;
        double wallWidth = 0.0;
        double wallArea = 0.0;
        double gallonsPaintNeeded = 0.0;
        
        final double squareFeetPerGallons = 350.0;
        
        // Implement a do-while loop to ensure input is valid
        // Prompt user to input wall's height
        do {
            System.out.println("Enter wall height (feet): ");

            try {
                if (!scnr.hasNextDouble()) {
                    throw new Exception("Error: Please enter a number.");
                }

                wallHeight = scnr.nextDouble();

                if (wallHeight <= 0) {
                    throw new Exception("Error: Height must be greater than 0.");
                }

                scnr.nextLine();    //  If successful, eat the new line
            }
            catch (Exception e) {
                System.out.println(e.getMessage());
                if (scnr.hasNextLine()) {
                    scnr.nextLine();//  Discard invalid input
                }
                wallHeight = 0.0;   //  Reset and restart loop
            }
        } while (wallHeight <= 0.0);

        // Implement a do-while loop to ensure input is valid
        // Prompt user to input wall's width
        do {
            System.out.println("Enter wall width (feet): ");

            try {
                if (!scnr.hasNextDouble()) {
                    throw new Exception("Error: Please enter a number.");
                }

                wallWidth = scnr.nextDouble();

                if (wallWidth <= 0) {
                    throw new Exception("Error: Width must be greater than 0.");
                }

                scnr.nextLine();    //  If successful, eat the new line
            }
            catch (Exception e) {
                System.out.println(e.getMessage());
                if (scnr.hasNextLine()) {
                    scnr.nextLine();//  Discard invalid input
                }
                wallWidth = 0.0;    //  Reset and restart loop
            }
        } while (wallWidth <= 0.0);

        // Calculate and output wall area
        wallArea = wallHeight * wallWidth;
        System.out.println("Wall area: " + wallArea + " square feet");

        // Calculate and output the amount of paint (in gallons) needed to paint the wall
        gallonsPaintNeeded = wallArea/squareFeetPerGallons;
        System.out.println("Paint needed: " + gallonsPaintNeeded + " gallons");

        scnr.close();
    }
}
