using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the Day:");
                string dayofweek = Console.ReadLine();
                Day_s day;
                if (Enum.TryParse(dayofweek, out day))
                {

                    Console.WriteLine(day == Day_s.Sunday);
                }

                Console.ReadLine();
            }
            catch (FormatException e )
            {
                Console.WriteLine("Please enter an actual day of the week.",e);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           


        }
            public enum Day_s
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Fiday,
            Saturday
        }
    }
}
