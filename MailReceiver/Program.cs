using System;
using static System.Console;

namespace MailReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            new Consumer().Start();
            WriteLine("Application running... press [enter] to exit");
            ReadLine();
        }
    }
}
