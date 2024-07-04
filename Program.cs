internal class Program
{
    //Abstract Factory cung cấp interface để tạo ra toàn bộ họ các đối tượng liên quan
    //Gồm 5 thành phần chính : 
    //1. Abstract factory : Khai báo một giao diện với các phương thức tạo ra các sản phẩm khác nhau.
    //2. Concrete factory : Thực thi giao diện AbstractFactory để tạo ra các đối tượng cụ thể của các sản phẩm.
    //3. Abstract product : khai báo 1 interface cho 1 product 
    //4. Concrete product : Thực thi giao diện AbstractProduct để định nghĩa các sản phẩm cụ thể.
    //5. Client           : Sử dụng các đối tượng được tạo ra bởi ConcreteFactory.


    //định nghĩa các abstract factory
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    //định nghĩa các concrete factory
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox();
        }
    }

    public class MacOSFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new MacOSButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacOSCheckbox();
        }
    }
    //định nghĩa các Product interface
    public interface IButton
    {
        void Paint();
    }

    public interface ICheckbox
    {
        void Paint();
    }
    //định nghĩa các Concrete product 
    public class WindowsButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a button in a Windows style.");
        }
    }

    public class MacOSButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a button in a macOS style.");
        }
    }

    public class WindowsCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a checkbox in a Windows style.");
        }
    }

    public class MacOSCheckbox : ICheckbox
    {
        public void Paint()
        {
            Console.WriteLine("Rendering a checkbox in a macOS style.");
        }
    }
    //

    public class ApplicationService
    {
        private readonly IButton _button;
        private readonly ICheckbox _checkbox;

        public ApplicationService(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
        }

        public void Paint()
        {
            _button.Paint();
            _checkbox.Paint();
        }
    }

    private static void Main(string[] args)
    {
        IGUIFactory factory;
        ApplicationService app;

        Console.WriteLine("Enter the OS (windows/macos): ");
        string os = Console.ReadLine();

        if (os.Equals("windows", StringComparison.OrdinalIgnoreCase))
            factory = new WindowsFactory();
        else if (os.Equals("macos", StringComparison.OrdinalIgnoreCase))
            factory = new MacOSFactory();
        else
        {
            Console.WriteLine("Invalid OS type.");
            return;
        }

        app = new ApplicationService(factory);
        app.Paint();
    }
}