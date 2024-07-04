using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

internal class Program
{

    //Ví dụ 1 -------------------------------------------------------------
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

    //Ví dụ 2 -------------------------------------------------------------
    public interface IShape
    {
        void Draw();
    }
    public class Circle : IShape
    {
        public void Draw()
        {
            System.Console.WriteLine("Drawing a circle...");
        }
    }

    public class Rectangle : IShape
    {
        public void Draw()
        {
            System.Console.WriteLine("Drawing a retangle...");
        }
    }

    public abstract class ShapeFactory
    {
        public abstract IShape CreateShape();

    }

    public class CircleFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            return new Circle();
        }
    }

    public class RectangleFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            return new Rectangle();
        }
    }

    private static void Main(string[] args)
    {
        //ví dụ 1 -----------------------------------------------------
        //create cat factory
        AnimalFactory catFactory = new CatFactory();
        //create dog factory
        AnimalFactory dogFactory = new DogFactory();
        
        //tạo đối tượng từ method của nhà máy
        //tạo mà không cần biết rõ nó là loại nào
        //tuân thủ nguyên tắc Solid : Open closed principle
        Animal cat = catFactory.CreateAnimal();
        Animal dog = dogFactory.CreateAnimal();
        //
        cat.Speak();
        dog.Speak();

        //ví dụ 2 ----------------------------------------------------
        //create circle factory
        ShapeFactory circleFactory = new CircleFactory();
        //create rectangle factory
        ShapeFactory rectangleFactory = new RectangleFactory();

        IShape circle = circleFactory.CreateShape();
        IShape rectangle = rectangleFactory.CreateShape();

        circle.Draw();
        rectangle.Draw();
    }
}