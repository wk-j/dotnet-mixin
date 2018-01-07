using System;
using static AgeProvider;

namespace Mixin
{
    class Program
    {
        static void Main(string[] args)
        {
            var h = new Human("Jim");
            h.SetBirthDate(new DateTime(1980, 1, 1));
            Console.WriteLine("Name {0}, Age = {1}", h.Name, h.GetAge());

            var h2 = new Human("Fred");
            h2.SetBirthDate(new DateTime(1960, 6, 1));
            Console.WriteLine("Name {0}, Aage = {1}", h2.Name, h2.GetAge());
        }
    }
}
