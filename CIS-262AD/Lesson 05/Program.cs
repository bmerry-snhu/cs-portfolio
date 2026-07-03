using System;
using System.Threading;

namespace Lesson_05
{
    class Program
    {
        static bool keepCounting = true;
        static void Main(string[] args)
        {
            Console.WriteLine("Upon pressing enter, this application will count as high as it can until you press enter again.");

            Console.ReadLine();
            Console.WriteLine("(User pressed Enter)");

            long count1 = 0;
            long count2 = 0;

            Thread thread1 = new Thread(() => Count(ref count1));
            Thread thread2 = new Thread(() => Count(ref count2));

            thread1.Start();
            thread2.Start();

            Console.ReadLine();
            Console.WriteLine("(User pressed Enter)");

            keepCounting = false;

            thread1.Join();
            thread2.Join();

            Console.WriteLine(count1);
            Console.WriteLine(count2);
        }
        static void Count(ref long counter)
        {
            while (keepCounting)
                counter++;
        }
    }
}