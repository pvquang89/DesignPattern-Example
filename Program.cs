﻿
//Bối cảnh : Bạn có một hệ thống thanh toán cũ (OldPaymentSystem) 
//mà bạn muốn tích hợp vào hệ thống mới sử dụng một interface khác (IPaymentProcessor).
//Bạn không muốn thay đổi mã nguồn của hệ thống cũ
internal class Program
{

    //target interface : interface mà client muốn làm việc
    public interface IPaymentProcessor
    {
        void ProcessPayment(string paymentType, double amount);
    }

    //interface hiện có
    public interface IOldPaymentSystem
    {
        void MakeOldPayment(string type, double amount);
    }

    //Adaptee -  hệ thống hiện có muốn tích hợp vào target interface
    public class OldPaymentSystem : IOldPaymentSystem
    {
        public void MakeOldPayment(string type, double amount)
        {
            Console.WriteLine($"Payment of {amount} using {type} processed.");
        }
    }

    //class Adapter
    public class PaymentAdapter : IPaymentProcessor
    {
        //Composition : trong classA chứa tham chiếu đến obj của classB và sd các phương thức của classB
        private readonly IOldPaymentSystem _oldPaymentSystem;

        public PaymentAdapter(IOldPaymentSystem oldPaymentSystem)
        {
            _oldPaymentSystem = oldPaymentSystem;
        }
        // Implement phương thức ProcessPayment từ interface IPaymentProcessor
        public void ProcessPayment(string paymentType, double amount)
        {
            // Gọi phương thức MakeOldPayment của OldPaymentSystem
            _oldPaymentSystem.MakeOldPayment(paymentType, amount);
        }
    }

    //client
    private static void Main(string[] args)
    {
        IOldPaymentSystem oldPaymentSystem = new OldPaymentSystem();
        // Tạo đối tượng Adapter và truyền vào đối tượng OldPaymentSystem
        IPaymentProcessor paymentProcessor = new PaymentAdapter(oldPaymentSystem);

        // Sử dụng phương thức của interface mục tiêu (IPaymentProcessor)
        System.Console.WriteLine("New system");
        paymentProcessor.ProcessPayment("Credit Card", 100.0);
        paymentProcessor.ProcessPayment("PayPal", 200.0);

        //Kết quả : logic của hệ thống cũ đã được tích hợp vào target interface
    }
}