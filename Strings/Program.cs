using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            //Concat method
            string text = "This is an example ";
            string concatenatedText = String.Concat(text, "with concatenated strings.");
            Console.WriteLine(concatenatedText);

            //Split() method
            Console.WriteLine("\nEnter your last name and first name:");
            string fullName = Console.ReadLine();
            if (fullName != "")
            {
                string[] splitName = fullName.Split(' ');
                string lastName = splitName[0];
                Console.WriteLine("Last name: " + lastName);

                string firstName;
                Console.Write("First name: ");
                for (int i = 1; i < splitName.Length; i++)
                {
                    firstName = splitName[i];
                    Console.Write(firstName + ' ');
                }
            }

            //Trim() method
            string untrimmedText = "***/.This is a trimmed text example!,***";
            char[] charactersToTrim = { '.', '*', ',', '/', '!' };
            string trimmedText = untrimmedText.Trim(charactersToTrim);
            Console.WriteLine("\n\n" + trimmedText);

            //ToUpper() and ToLower() methods
            Console.WriteLine("\nUppercase text: " + text.ToUpper());
            Console.WriteLine("Lowercase text: " + concatenatedText.ToLower());

            //Contains(substring) method
            if (concatenatedText.Contains(text))
                Console.WriteLine("\nThis ' {0} ' is a substring of this string ' {1} '.", text, concatenatedText);

            //Compare(string1, string2) method
            Console.WriteLine("\nEnter the first text");
            string firstText = Console.ReadLine();
            Console.WriteLine("Enter the second text");
            string secondText = Console.ReadLine();
            int result = string.Compare(firstText, secondText);
            if (result == 0)
                Console.WriteLine("This texts are identical.");
            else
                Console.WriteLine("This texts are different.");

            //Replace(string1, string2) method
            string list = "red yellow green blue violet";
            Console.WriteLine("\nThis is a list of colors: {0}.", list.Replace(" ", ", "));
        }
    }
}
