using System;
using System.Threading;
using System.IO;

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
            Console.WriteLine("Insert path to open file");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string textFile = file.ReadToEnd();

                // Need to handle a problem to write all lines inside the file
                // Not working correctly
                for (int i = 0; i < textFile.Length - 1; i++)
                {
                    if (textFile[i] != '\n')
                        Console.Write(textFile[i]);
                        
                    Console.WriteLine("\n");
                }
            }

            Console.WriteLine("");
            Console.WriteLine("Press any key to exit to Menu");

            switch (Console.ReadLine())
            {
                default: Thread.Sleep(2000); Menu(); break;
            }
        }

        static void EditFile()
        {
            Console.Clear();
            Console.WriteLine("Type your text below and ESC to quit\n");

            string text = "";
            ConsoleKeyInfo inputedKey; //create new ConsoleKeyInfo struct 

            do
            {
                inputedKey = Console.ReadKey();

                // Needed to verify to not overwrite inputed text
                if (inputedKey.Key == ConsoleKey.Enter)
                    Console.WriteLine("");

                text += inputedKey.KeyChar;
                //text += Environment.NewLine;
            }
            while(inputedKey.Key != ConsoleKey.Escape);

            Console.WriteLine("");
            Console.WriteLine("Do you wish to save your file? Y/N");
            char response = char.Parse(Console.ReadLine().ToLower());

            switch(response)
            {
                case 'y': SaveFile(text); break;
                default: Menu(); break;
            }
        }

        static void SaveFile(string text)
        {
            Console.Clear();
            Console.WriteLine("Write a path to save the file:");
            var path = Console.ReadLine();

            // StreamWriter saves, imported by System.IO used combined with using to help us
            // to not forget the file opened.
            using(var file = new StreamWriter(path))
            {
                file.Write(text); // Here we are saving the inputed string into the file
            }

            Console.WriteLine($"File saved at {path}");
            Thread.Sleep(2000);
            Menu();
        }
    }
}