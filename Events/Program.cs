using System;

namespace Events
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Publish - Subscriber relationship, we are notified by subscribing to our event outside the target class.
            Car c = new Car();
            // We are subscribing to our event.
            c.OnChange += c_OnChange;

            c.Speed = 55; // Nothing happens...
            c.Speed = 70; // Event fired.
        }

        static void c_OnChange()
        {
            Console.WriteLine("Event fired, car speed >= 60mph!");
        }
    }
}
