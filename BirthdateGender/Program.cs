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
            Console.WriteLine("Enter your birthdate: ");
            DateTime birthdate = ReadBirthDate();
            int age = GetAge(birthdate);
            Console.WriteLine("If your birthdate is " + birthdate.ToString("dd-MM-yyyy") + " you are " + age + " years old.");

            Console.WriteLine("Enter the first letter of your gender: ");
            GenderCheck(age);
        }

        static int GetAge(DateTime birthdate)
        {
            int years = DateTime.Now.Year - birthdate.Year;
            if ((birthdate.Month > DateTime.Now.Month) || (birthdate.Day > DateTime.Now.Day))
                years--;
            return years;
        }
        static DateTime ReadBirthDate()
        {

            Console.WriteLine("Day: ");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Month: ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Year: ");
            int year = int.Parse(Console.ReadLine());

            if (!IsValid(day, month, year))
            {
                do
                {
                    Console.WriteLine("Invalid date. Try again.");
                    Console.WriteLine("Day: ");
                    day = int.Parse(Console.ReadLine());
                    Console.WriteLine("Month: ");
                    month = int.Parse(Console.ReadLine());
                    Console.WriteLine("Year: ");
                    year = int.Parse(Console.ReadLine());
                } while (!IsValid(day, month, year));
            }

            DateTime date = new DateTime(year, month, day);
            return date;
        }
        static bool IsLeap(int year)
        {
            return (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0));
        }
        static bool IsValid(int day, int month, int year)
        {
            //check if date is not out of range
            if (year > DateTime.Now.Year || year <= 0)
                return false;
            if (month < 1 || month > 12)
                return false;
            if (day < 1 || day > 31)
                return false;
            //check for April, June, September, November
            if (month == 4 || month == 6 || month == 9 || month == 10)
                return day <= 30;
            //check Leap Day / Leap Year
            if(month == 2)
            {
                if (IsLeap(year))
                    return day <= 29;
                else
                    return day <= 28;
            }

            return true;
        }
        static bool ValidGender(char genderInput)
        {
            if ((genderInput != 'F') && (genderInput != 'f') && (genderInput != 'M') && (genderInput != 'm'))
                return false;
            return true;
        }
        static void GenderCheck(int age)
        {

            char genderInput = char.Parse(Console.ReadLine());
            Gender? genderOutput;

            if (!ValidGender(genderInput))
            {
                do
                {
                    Console.WriteLine("Try again:");
                    genderInput = char.Parse(Console.ReadLine());
                } while (!ValidGender(genderInput));
            }

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
        }
        public enum Gender { Female, Male }
    }
}
