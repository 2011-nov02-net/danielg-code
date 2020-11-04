using System;

namespace acronym_project
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter a mulitple word entry please: ");

            string input = Console.ReadLine();
            string[] split = input.Split();
            
            string output = "";

            for (int i = 0; i < split.Length; i++)
            {
                string thisWord = split[i];
                output += thisWord[0];
            }

            Console.WriteLine("Here is your Acronym: (" + output + ")");
           
            Console.WriteLine();
        }
    }
}
