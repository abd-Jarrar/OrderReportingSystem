using System;
using System.Collections.Generic;
using System.Text;

namespace Asal.OrderReportingSystem.Utilities
{
    public class MyUtilities
    {
        public static bool GetSortType()
        {
            while (true)
            {
                Console.WriteLine("[1] Ascending");
                Console.WriteLine("[2] Descending");
                Console.Write("Choose: ");

                var choice = Console.ReadLine();

                if (choice == "1")
                    return true;

                if (choice == "2")
                    return false;

                Console.WriteLine("Invalid choice. Please choose 1 or 2.");
            }
        }
    }
}
