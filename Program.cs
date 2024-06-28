﻿internal class Program
{
    public class Singleton
    {
        // Tạo một biến static để lưu trữ thể hiện duy nhất của lớp Singleton
        private static Singleton instance;

        // Không cho tạo thể hiện từ bên ngoài
        private Singleton() { }

        // Cung cấp một phương thức static để lấy thể hiện duy nhất của lớp Singleton
        //(vì ko thể tạo obj nên để static)
        public static Singleton getInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
        public void showMessage()
        {
            System.Console.WriteLine("hello");
        }
    }

    private static void Main(string[] args)
    {
        //Sai vì không có hàm tạo public
        // Singleton s = new Singleton();
        //Chỉ có thể tạo thông qua chính lớp đấy gọi tới phương thức static đã định sẵn
        Singleton s = Singleton.getInstance();
        s.showMessage();
    }
}