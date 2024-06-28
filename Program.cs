using System.Data.Common;
using System.Runtime.CompilerServices;

internal class Program
{

    public abstract class Animal
    {
        public abstract void Speak();
    }
    public class Cat : Animal
    {
        public override void Speak()
        {
            System.Console.WriteLine("Meo meo meo .....");
        }
    }

    public class Dog : Animal
    {
        public override void Speak()
        {
            System.Console.WriteLine("Gau Gau Gau .....");
        }
    }

    public abstract class AnimalFactory
    {
        public abstract Animal CreateAnimal();

        public void SpeakAnimal()
        {
            Animal animal = CreateAnimal();
            animal.Speak();
        }
    }

    public class CatFactory : AnimalFactory
    {
        public override Animal CreateAnimal()
        {
            return new Cat();
        }
    }

    public class DogFactory : AnimalFactory
    {
        public override Animal CreateAnimal()
        {
            return new Dog();
        }
    }
    private static void Main(string[] args)
    {
        //tạo nhà máy mèo
        AnimalFactory catFactory = new CatFactory();   
        //tạo nhà máy chó
        AnimalFactory dogFactory = new DogFactory();
    
        //tạo đối tượng từ method của nhà máy
        //tạo mà không cần biết rõ nó là loại nào
        //tuân thủ nguyên tắc Solid : Open closed principle
        Animal cat = catFactory.CreateAnimal();
        Animal dog = dogFactory.CreateAnimal(); 
        //
        cat.Speak();
        dog.Speak();
    }
}