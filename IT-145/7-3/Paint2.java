import java.util.Scanner;

public class Paint2 {

    public static void main(String[] args) {

        Scanner scnr = new Scanner(System.in);
        double wallHeight = 0.0;
        double wallWidth = 0.0;
        double wallArea = 0.0;
        double gallonsPaintNeeded = 0.0;
        double cansNeeded;

        final double squareFeetPerGallons = 350.0;
        final double gallonsPerCan = 1.0;

        // Prompt user to input wall's height
        System.out.println("Enter wall height (feet): ");
        wallHeight = scnr.nextDouble();


        // Prompt user to input wall's width
        System.out.println("Enter wall width (feet): ");
        wallWidth = scnr.nextDouble();

        // Calculate and output wall area
        wallArea = wallHeight * wallWidth;
        System.out.println("Wall area:  " + wallArea + " square feet");

        // Calculate and output the amount of paint in gallons needed to paint the wall
        gallonsPaintNeeded = wallArea / squareFeetPerGallons;
        System.out.println("Paint needed: " + gallonsPaintNeeded + " gallons");

        // Calculate and output the number of paint cans needed to paint the wall,
        // rounded up to nearest integer
        
        //  ADDED 20260220 (bmerry): Using Math.ceil() to round up to the nearest whole number
        cansNeeded = Math.ceil(gallonsPaintNeeded);

        //  Output correct form, singular "can" or plural "cans"
        if (cansNeeded == 1.0) {
            System.out.println("Cans needed: " + cansNeeded + " can");
        }
        else {
            System.out.println("Cans needed: " + cansNeeded + " cans");
        }

        //  Industry best practice, close the scanner
        scnr.close();
    }
}
