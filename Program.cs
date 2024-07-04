internal class Program
{

    public class Car
    {
        private string Engine { get; set; }
        private int Wheels { get; set; }
        private string Color { get; set; }
        private int Seats { get; set; }

        private Car() { }

        //khởi tạo class builder bên trong Car
        public class Builder
        {
            private readonly Car _car;

            public Builder()
            {
                _car = new Car();
            }

            public Builder SetEngine(string engine)
            {
                _car.Engine = engine;
                return this;
            }
            public Builder SetWheels(int wheels)
            {
                _car.Wheels = wheels;
                return this;
            }

            public Builder SetColor(string color)
            {
                _car.Color = color;
                return this;
            }

            public Builder SetSeats(int seats)
            {
                _car.Seats = seats;
                return this;
            }

            public Car Build()
            {
                return _car;
            }

        }
        public void ShowDetails()
        {
            Console.WriteLine("--- Car Details ---");
            Console.WriteLine("Engine: " + Engine);
            Console.WriteLine("Wheels: " + Wheels);
            Console.WriteLine("Color: " + Color);
            Console.WriteLine("Seats: " + Seats);
        }
    }


    private static void Main(string[] args)
    {
        var car = new Car.Builder()
        .SetEngine("V8")
        .SetWheels(4)
        .SetColor("Red")
        .SetSeats(2)
        .Build();

        car.ShowDetails();
    }
}