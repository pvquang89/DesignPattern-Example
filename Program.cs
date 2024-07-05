internal class Program
{
    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            IdNumber = idNumber;
        }
    }
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        //shallow clone 
        public Person ShallowClone()
        {
            return (Person)this.MemberwiseClone();
        }

        //deep clone 
        public Person DeepClone()
        {
            Person clone = (Person)this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            //vì string Name là bất biến nên nếu ko làm như này sẽ không tách biệt dữ liệu
            // => ko đúng với deepclone
            clone.Name = String.Copy(Name);
            return clone;
        }
    }
    private static void Main(string[] args)
    {
        Person p1 = new Person();
        p1.Age = 42;
        p1.BirthDate = Convert.ToDateTime("1977-01-01");
        p1.Name = "Pham Van Quang";
        p1.IdInfo = new IdInfo(666);

        Person p2 = p1.ShallowClone();
        Person p3 = p1.DeepClone();

        //
        Console.WriteLine("Original values of p1, p2, p3:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values:");
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values:");
        DisplayValues(p3);

        // Thay đổi giá trị của thuộc tính P1 và hiển thị giá trị P1, P2, P3
        p1.Age = 32;
        p1.BirthDate = Convert.ToDateTime("1900-01-01");
        p1.Name = "Quang da thay doi";
        p1.IdInfo.IdNumber = 7878;
        System.Console.WriteLine("----------------------------------------------------------------");
        Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
        Console.WriteLine("   p1 instance values: ");
        DisplayValues(p1);
        Console.WriteLine("   p2 instance values (reference values have changed):");
        //p2 thay đổi giá trị của field reference 
        DisplayValues(p2);
        Console.WriteLine("   p3 instance values (everything was kept the same):");
        DisplayValues(p3);
    }
    public static void DisplayValues(Person p)
    {
        Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
            p.Name, p.Age, p.BirthDate);
        Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
    }
}