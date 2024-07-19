﻿internal class Program
{
    //subject(publisher) - khi có sự kiện sẽ thông báo cho Observer(Subscriber)
    public interface ISubject
    {
        //đăng ký 1 observer
        void Attach(IObserver observer);
        //huỷ 1 observer
        void Detach(IObserver observer);
        void Notify();
    }

    //ConcreteSubject
    public class ConcreteSubject : ISubject
    {
        //list observer đã đăng ký
        private List<IObserver> listObserver = new List<IObserver>();
        private int state;

        public int State
        {
            get { return state; }
            set
            {
                state = value;
                //gọi notify() khi state thay đổi 
                Notify();
            }
        }
        public void Attach(IObserver observer)
        {
            listObserver.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            listObserver.Remove(observer);
        }

        //thông báo cho các observer trong list khi có sự thay đổi state
        public void Notify()
        {
            foreach (var observer in listObserver)
            {
                //this : tham chiếu đến obj Subject hiện tại
                observer.Update(this);
            }
        }
    }

    //Observer(Subscriber) - quan sát subject, đăng ký theo dõi Subject và cập nhật khi nhận được thông báo từ Subject
    public interface IObserver
    {
        //Update() được gọi khi subject thay đổi
        void Update(ISubject subject);
    }
    // ConcreteObserver
    public class ConcreteObserver : IObserver
    {
        private string name;

        public ConcreteObserver(string name)
        {
            this.name = name;
        }

        public void Update(ISubject subject)
        {
            //kiểm tra xem subject có phải 1 đối tượng của class ConcreteSubject
            //nếu đúng thì cast subject thành ConcreteSubject và gán cho concreteSubject
            if (subject is ConcreteSubject concreteSubject)
            {
                Console.WriteLine($"{name} nhận được thông báo: State của Subject đã thay đổi thành {concreteSubject.State}");
            }
        }
    }

    private static void Main(string[] args)
    {
        ConcreteSubject subject = new ConcreteSubject();

        ConcreteObserver observer1 = new ConcreteObserver("Observer 1");
        ConcreteObserver observer2 = new ConcreteObserver("Observer 2");

        subject.Attach(observer1);
        subject.Attach(observer2);

        subject.State = 10; // Thay đổi trạng thái của Subject
        subject.State = 20; // Thay đổi trạng thái của Subject

        //ví dụ thêm 1 thằng
        ConcreteObserver observer3 = new ConcreteObserver("Observer 3");
        subject.State = 30; //Thay đổi trạng thái Subject, các observer 1 2 3 đều nhận được thông báo


    }
}