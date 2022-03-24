using System;
using System.Threading;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread current = Thread.CurrentThread;
            //current.Name = "Name";
            //Thread.Sleep(500);
            //Console.WriteLine(current.Name);
            //Thread.Sleep(500);
            //Console.WriteLine(current.IsBackground);
            //Thread.Sleep(500);
            //Console.WriteLine(current.IsAlive);
            //Thread.Sleep(500);
            //Console.WriteLine(current.ManagedThreadId);
            //Thread.Sleep(500);
            //Console.WriteLine(current.Priority);
            //Thread.Sleep(500);
            //Console.WriteLine(current.ThreadState);
            //Thread t1 = new Thread(() => Console.WriteLine(1));
            //t1.Priority = ThreadPriority.Highest;
            //Thread t2 = new Thread(() => Console.WriteLine(2));
            //Thread t3 = new Thread(() => Console.WriteLine(3));
            //t1.Start();
            //t2.Start();
            //t3.Start();
            //Console.WriteLine("end");

            //Thread t4 = new Thread((a) => Console.WriteLine(a));
            //t4.Priority = ThreadPriority.Highest;
            //Thread t5 = new Thread((a) => Console.WriteLine(a));
            //Thread t6 = new Thread((a) => Console.WriteLine(a));
            //t4.Start(4);
            //t5.Start(5);
            //t6.Start(6);
            //Console.WriteLine("end");

            //int x = 0;
            //object locker = new object();
            //for (int i = 0; i < 6; i++)
            //{
            //    Thread thread = new Thread(Print);
            //    thread.Start();
            //}
            //void Print()
            //{
            //    lock (locker)
            //    {
            //        for (int i = 0; i < 6; i++)
            //        {
            //            x++;
            //            Thread.Sleep(100);
            //            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {x}");
            //        }
            //    }
            //}
            //int x = 0;
            //object locker = new object();
            //for (int i = 0; i < 6; i++)
            //{
            //    Thread thread = new Thread(Print);
            //    thread.Start();
            //}
            //void Print()
            //{
            //    bool l = false;
            //    Monitor.Enter(locker, ref l);
            //    for (int i = 0; i < 6; i++)
            //        {
            //            x++;
            //            Thread.Sleep(100);
            //            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {x}");
            //        }
            //    if (l)
            //        Monitor.Exit(locker);
            //}
            //int x = 0;
            //Mutex m = new Mutex();
            //for (int i = 0; i < 6; i++)
            //{
            //    Thread thread = new Thread(Print);
            //    thread.Start();
            //}
            //void Print()
            //{
            //    m.WaitOne();
            //    for (int i = 0; i < 6; i++)
            //    {
            //        x++;
            //        Thread.Sleep(100);
            //        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {x}");
            //    }
            //    m.ReleaseMutex();
            //}

            for (int i = 0; i < 10; i++)
            {
                Visitor visitor = new Visitor(i);
            }

        }
        class Visitor
        {
            static Semaphore sem = new Semaphore(3, 3);
            Thread thread;
            int count = 3;
            public Visitor(int i)
            {
                thread = new Thread(Eat);
                thread.Start();
            }
            public void Eat()
            {
                while (count > 0)
                {
                    sem.WaitOne();
                    Console.WriteLine(count);
                    Console.WriteLine($"{thread.ManagedThreadId} +");
                    Console.WriteLine($"{thread.ManagedThreadId} is eating");
                    Console.WriteLine($"{thread.ManagedThreadId} -");
                    Thread.Sleep(100);
                    sem.Release();
                    count--;
                }
            }
        }
    }
}