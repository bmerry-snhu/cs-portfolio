public class Pet {
    private String petType;
    private String petName;
    private int petAge;
    private int dogSpaces;
    private int catSpaces;
    private int daysStay;
    private double amountDue;

    //  No-args constructor
    public Pet() {
        this.petType = "NoType";
        this.petName = "NoName";
        this.petAge = -1;
        this.dogSpaces = 0;
        this.catSpaces = 0;
        this.daysStay = 0;
        this.amountDue = 0.0;
    }

    /*
        Constructor w/ args:
            First, defaults are set with the no-args construtor, then...
            petType is the pet's type
            petName is the pet's name
            petAge is the pet's age
    */
    public Pet(String inPetType, String inPetName, int inPetAge) {
        this();
        this.petType = inPetType;
        this.petName = inPetName;
        this.petAge = inPetAge;
    }

    //  Get the Pet's type
    public String getPetType() {
        return this.petType;
    }

    //  Set the Pet's type
    public void setPetType(String inPetType) {
        this.petType = inPetType;
    }

    //  Get the Pet's name
    public String getPetName() {
        return this.petName;
    }

    //  Set the Pet's name
    public void setPetName(String inPetName) {
        this.petName = inPetName;
    }

    //  Get the Pet's age
    public int getPetAge() {
        return this.petAge;
    }

    //  Set the Pet's age
    public void setPetAge(int inPetAge) {
        this.petAge = inPetAge;
    }

    //  Get the number of Dog spaces
    public int getDogSpaces() {
        return this.dogSpaces;
    }

    //  Set the number of Dog spaces
    public void setDogSpaces(int inDogSpaces) {
        this.dogSpaces = inDogSpaces;
    }

    //  Get the number of Cat spaces
    public int getCatSpaces() {
        return this.catSpaces;
    }

    //  Set the number of Cat spaces
    public void setCatSpaces(int inCatSpaces) {
        this.catSpaces = inCatSpaces;
    }

    //  Get the number of days in the stay
    public int getDaysStay() {
        return this.daysStay;
    }

    //  Set the number of days in the stay
    public void setDaysStay(int inDaysStay) {
        this.daysStay = inDaysStay;
    }

    //  Get the amount due
    public double getAmountDue() {
        return this.amountDue;
    }

    //  Set the amount due
    public void setAmountDue(double inAmountDue) {
        this.amountDue = inAmountDue;
    }
}