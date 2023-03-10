using System;
using System.Threading;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Text Editor\n");
            Console.WriteLine("What do you wish?");
            Console.WriteLine("1 - Open File");
            Console.WriteLine("2 - New file");
            Console.WriteLine("Any other key to quit application");

            char option = Console.ReadLine()[0];

            switch (option)
            {
                case '1': OpenFile(); break;
                case '2': EditFile(); break;
                default:  
                    Console.WriteLine("Thanks for using");
                    Thread.Sleep(1000); Console.Clear();
                    System.Environment.Exit(1); 
                    break;
            }
        }

        static void OpenFile()
        {
            Console.Clear();
            Menu();
        }

        static void EditFile()
        {
            Console.Clear();
            Console.WriteLine("Type your text below and ESC to quit\n");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);

            Console.Write($"{text}");
            Thread.Sleep(1000);
            Console.WriteLine("Enter any key to continue");

            switch(Console.ReadLine())
            {
                default: Menu(); break;
            }
        }

        static void SaveFile(string text)
        {
            Console.Clear();
            Console.WriteLine("Select a path to save the file");
            var path = Console.ReadLine();

            
            Menu();
        }
    }
}