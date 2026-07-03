public class Monkey extends RescueAnimal {
    private String tailLength;
    private String height;
    private String bodyLength;
    private String species;

    //  Default constructor
    public Monkey() {
        setAnimalType("monkey");
    }

    //  Detailed constructor
    public Monkey(String inName, String inSpecies, String inGender, String inAge,
                    String inWeight, String inAcquisitionDate, String inAcquisitionCountry,
                    String inTrainingStatus, boolean inReserved, String inInServiceCountry,
                    String inTailLength, String inHeight, String inBodyLength) {
        //  Inherited fields
        setName(inName);
        setGender(inGender);
        setAge(inAge);
        setWeight(inWeight);
        setAcquisitionDate(inAcquisitionDate);
        setAcquisitionLocation(inAcquisitionCountry);
        setTrainingStatus(inTrainingStatus);
        setReserved(inReserved);
        setInServiceCountry(inInServiceCountry);
        setAnimalType("monkey");

        //  Monkey-specific fields
        setSpecies(inSpecies);
        setTailLength(inTailLength);
        setHeight(inHeight);
        setBodyLength(inBodyLength);
    }

    //  Get tailLength
    public String getTailLength() {
        return tailLength;
    }

    //  Set tailLength
    public void setTailLength(String inTailLength) {
        this.tailLength = inTailLength;
    }

    //  Get height
    public String getHeight() {
        return height;
    }

    //  Set height
    public void setHeight(String inHeight) {
        this.height = inHeight;
    }

    //  Get bodyLength
    public String getBodyLength() {
        return bodyLength;
    }

    //  Set bodyLength
    public void setBodyLength(String inBodyLength) {
        this.bodyLength = inBodyLength;
    }

    //  Get species
    public String getSpecies() {
        return species;
    }

    //  Set species
    public void setSpecies(String inSpecies) {
        this.species = inSpecies;
    }
}