namespace Lesson_11
{
    abstract public class Animal
    {
        private string Name = "Unnamed Animal";
        
        public void setName(string name)
        {
            Name = name;
        }

        public string getName()
        {
            return Name;
        }

        public abstract void Speak();
    }

    public class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine($"The dog named {getName()} barks.");
        }
    }

    public class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine($"The cat named {getName()} meows.");
        }
    }

    public class Pig : Animal
    {
        public override void Speak()
        {
            Console.WriteLine($"The pig named {getName()} oinks.");
        }
    }

    public class Cow : Animal
    {
        public override void Speak()
        {
            Console.WriteLine($"The cow named {getName()} moos.");
        }
    }
}