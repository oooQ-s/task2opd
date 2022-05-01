namespace lab2_2
{
    public interface IObserver//интерфейс отклика на обновление
    {
        public void Update(ISubject subject, int del, int count);
        public static void Updated(ISubject subject, int _delay, int _count)
        {
            Thread.Sleep(100);
            for (int i = 0; i < _delay * _count; i++)
            {
                Console.Write(". ");
                Thread.Sleep(1000);
            }

            Console.WriteLine($"\nПодписчик {_count}: Я реагирую на произошедшее.");
        }

    }
    public interface ISubject
    {
        // Присоединяет наблюдателя к издателю.
        void Attach(IObserver observer);

        // Отсоединяет наблюдателя от издателя.
        void Detach(IObserver observer);

        // Уведомляет всех наблюдателей о событии.
        void Notify();
    }
  //функция рассылки
    public class CountDown : ISubject
    {
        public int State { get; set; } = 0;
        private int _count = 0;
        private int _del = 0;

        private List<IObserver> _observers = new List<IObserver>();//список подписчиков

        public void Attach(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void Notify()//уведомление всех подписчиков
        {
            foreach (var observer in _observers)
            {
                observer.Update(this, _del, _count);
            }
        }
        public void CountDownEvent()//ивент с обновлением и вызовом уведомления
        {
            Console.WriteLine("\nОбъект наблюдения: делаю своё дело.");
            this.State = this.State + 1;
            
            Console.WriteLine("Объект наблюдения: моё состояние изменилось на: " + this.State);
            this.Notify();
        }
        
    }
    //функция определённого подписчика
    public class Subscriber1 : IObserver
    {
        public int _delay = 0;
        public int _count = 1;
        public Subscriber1(int delay)
        {
            this._delay = delay;
        }
        public void Update(ISubject subject, int _delay, int _count)
        {
            _delay = this._delay;//меняем задержку и номер под конкретный класс
            _count =this._count;
            IObserver.Updated(subject, _delay, _count);// вызываем функцию отклика
            Console.WriteLine("ВАу!");
        }
    }
    public class Subscriber2 : IObserver
    {
        private int _delay = 0;
        private int _count = 2;
        public Subscriber2(int delay)
        {
            _delay = delay;
        }
        public new void Update(ISubject subject, int _delay, int _count)
        {
            _delay = this._delay;//меняем задержку и номер под конкретный класс
            _count = this._count;
            IObserver.Updated(subject, _delay, _count);//вызываем функцию отклика
            Console.WriteLine("КРУТо!");
        }
    }

    public class Subscriber3 : IObserver
    {
        public int _delay = 0;
        public int _count = 3;
        public Subscriber3(int delay)
        {
            _delay = delay;
        }
        public new void Update(ISubject subject, int _delay, int _count)
        {
            _delay = this._delay;
            _count = this._count;
            IObserver.Updated(subject, _delay, _count);
            Console.WriteLine("КАПЕц!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int ms;
            Console.WriteLine("Введите задежрку в секундах:");
            while (!int.TryParse(Console.ReadLine(), out ms))
            {
                Console.WriteLine("Ошибка ввода, повторите попытку");
                Console.WriteLine("Введите задежрку в секундах:");
            }
            CountDown cd = new CountDown();
            Console.WriteLine("Выберите 1/2/3 subscriber. press q/w/e");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.E:
                    Subscriber3 thirdSubscriber = new Subscriber3(ms);
                    cd.Attach(thirdSubscriber);
                    break;
                case ConsoleKey.Q:
                    Subscriber1 firstSubscriber = new Subscriber1(ms);
                    cd.Attach(firstSubscriber);
                    break;
                case ConsoleKey.W:
                    var secondSubscriber = new Subscriber2(ms);
                    cd.Attach(secondSubscriber);
                    break;
                default:
                    break;
            }
            cd.CountDownEvent();
            Console.WriteLine("\n\nНажмите любую клавишу чтобы выйти");
            Console.ReadKey();
        }
    }
}