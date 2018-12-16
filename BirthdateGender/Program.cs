using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdateGender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your birth day, month and year : ");

            char[] separators = { ' ', ',', '.', '-', ':', '\t' };
            string[] enteredDate = Console.ReadLine().Split(separators);
            int day, month, year;

            day = int.Parse(enteredDate[0]);
            month = int.Parse(enteredDate[1]);
            year = int.Parse(enteredDate[2]);
            DateCheck(ref day, ref month, ref year);

            DateTime birthdate = new DateTime(year, month, day);
            int age = DateTime.Now.Year - birthdate.Year;

            Console.WriteLine("If your birthdate is " + birthdate.ToString("dd-MM-yyyy") + " you are " + age + " years old.");

            Console.WriteLine("Enter the first letter of your gender: ");
            GenderCheck(age);
        }

        static void DateCheck(ref int day, ref int month, ref int year)
        {
        dayLabel:
            if (day > 31 || day <= 0)
            {
                Console.WriteLine("Invalid day! Enter your birth day.");
                day = int.Parse(Console.ReadLine());
                goto dayLabel;
            }

        monthLabel:
            if (month > 12 || month <= 0)
            {
                Console.WriteLine("Invalid month! Enter your birth month.");
                month = int.Parse(Console.ReadLine());
                goto monthLabel;
            }

        yearLabel:
            if (year > DateTime.Now.Year || year <= 0)
            {
                Console.WriteLine("Invalid year! Enter your birth year.");
                year = int.Parse(Console.ReadLine());
                goto yearLabel;
            }
        }

        static void GenderCheck(int age)
        {
        genderLabel:
            char genderInput = char.Parse(Console.ReadLine());
            Gender? genderOutput;

            if (genderInput == 'F' || genderInput == 'f')
            {
                genderOutput = Gender.Female;
                if (age <= 60)
                    Console.WriteLine("You will retire at age 60.");
                else Console.WriteLine("You are retired.");
            }
            else if (genderInput == 'M' || genderInput == 'm')
            {
                genderOutput = Gender.Male;
                if (age <= 65)
                    Console.WriteLine("You will retire at age 65.");
                else Console.WriteLine("You are retired.");
            }
            else
            {
                genderOutput = null;
                Console.WriteLine("Invalid character for gender, enter the letter of your gender again!");
                goto genderLabel;
            }
        }

        public enum Gender { Female, Male }
    }
}
