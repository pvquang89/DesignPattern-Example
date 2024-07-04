internal class Program
{
    //obj muốn xây dựng
    public class House
    {
        private string _foundation;
        private string _walls;
        private string _roof;

        //setter
        public void setFoundation(string foundation)
        {
            _foundation = foundation;
        }
        public void setWalls(string walls)
        {
            _walls = walls;
        }
        public void setRoof(string roof)
        {
            _roof = roof;
        }

        //show details
        public void showDetails()
        {
            System.Console.WriteLine("---House details---");
            System.Console.WriteLine("Foundation: " + _foundation);
            System.Console.WriteLine("Walls: " + _walls);
            System.Console.WriteLine("Roof: " + _roof);
        }
    }

    //builder interface
    //xác định các bước cần thiết để xây dựng House
    public interface IHouseBuilder
    {
        void buildFoundation();
        void buildWalls();
        void buildRoof();
        //trả về obj House
        House getResult();
    }

    //concrete builder
    //triển khai cụ thể các bước để xây dựng House
    public class ConcreteHouseBuilder : IHouseBuilder
    {
        private readonly House _house;
        public ConcreteHouseBuilder()
        {
            _house = new House();
        }
        public void buildFoundation()
        {
            _house.setFoundation("Concrete foundation");
        }

        public void buildRoof()
        {
            _house.setRoof("Concrete roof");
        }

        public void buildWalls()
        {
            _house.setWalls("Concrete walls");
        }

        House IHouseBuilder.getResult()
        {
            return _house;
        }
    }

    //class này chịu trách nhiệm điều phối quá trình xây dựng
    public class HouseDirector
    {
        private IHouseBuilder _builder;
        public HouseDirector(IHouseBuilder builder)
        {
            _builder = builder;
        }
        public void constructHouse()
        {
            _builder.buildFoundation();
            _builder.buildWalls();
            _builder.buildRoof();
        }

    }
    private static void Main(string[] args)
    {
        // Tạo một đối tượng ConcreteHouseBuilder
        IHouseBuilder builder = new ConcreteHouseBuilder();
        // Tạo một đối tượng HouseDirector và kết nối với builder
        HouseDirector director = new HouseDirector(builder);
        // Xây dựng nhà
        director.constructHouse();
        // Lấy kết quả
        House house = builder.getResult();
        //Hiện thông tin
        house.showDetails();
    }
}