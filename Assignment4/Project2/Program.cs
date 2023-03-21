using System;

namespace AlarmClock
{
    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock();
            clock.Tick += Clock_Tick;
            clock.Alarm += Clock_Alarm;
            clock.Start();
        }
        private static void Clock_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Tick...");
        }
        private static void Clock_Alarm(object sender, EventArgs e)
        {
            Console.WriteLine("Alarm!");
        }
    }
    class AlarmClock
    {
        public event EventHandler Tick;
        public event EventHandler Alarm;
        public void Start()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                OnTick();
                if (DateTime.Now.Hour == 7 && DateTime.Now.Minute == 30)
                {
                    OnAlarm();
                }
            }
        }
        protected virtual void OnTick()
        {
            Tick?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnAlarm()
        {
            Alarm?.Invoke(this, EventArgs.Empty);
        }
    }
}
