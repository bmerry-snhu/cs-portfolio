public class Dog extends Pet {
    private int dogSpaceNumber;
    private double dogWeight;
    private boolean grooming;

    //  No-args constructor
    public Dog() {
        this.dogSpaceNumber = 0;
        this.dogWeight = 0.0;
        this.grooming = false;
    }

    /* 
        Constructor w/ args:
            dogSpaceNumber is the assigned space number
            dogWeight is the dog's weight
            grooming is whether grooming is requested
    */
    public Dog(int inDogSpaceNumber, double inDogWeight, boolean inGrooming) {
        this.dogSpaceNumber = inDogSpaceNumber;
        this.dogWeight = inDogWeight;
        this.grooming = inGrooming;
    }

    //  Gets the dog's assigned space number
    public int getDogSpaceNumber() {
        return dogSpaceNumber;
    }

    //  Sets the dog's assigned space number
    public void setDogSpaceNumber(int inDogSpaceNumber) {
        this.dogSpaceNumber = inDogSpaceNumber;
    }

    //  Gets the dog's weight
    public double getDogWeight() {
        return dogWeight;
    }

    //  Sets the dog's weight
    public void setDogWeight(double inDogWeight) {
        this.dogWeight = inDogWeight;
    }

    //  Gets the grooming decision
    public boolean getGrooming() {
        return grooming;
    }

    //  Sets the grooming decision; true = yes, false = no
    public void setGrooming(boolean inGrooming) {
        this.grooming = inGrooming;
    }
}