using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica.TinyURL
{
    public class NumberGenerator
    {
        public IEnumerable<int> Generate(int from, int to)
        {
            int totalMax = to - from;
            int finalSize = (int) totalMax / 3;

            // Create an ArrayList object that will hold the numbers
            List<int> lstNumbers = new List<int>();
            // The Random class will be used to generate numbers
            Random rndNumber = new Random();

            // Generate a random number between 1 and the Max
            int number = rndNumber.Next(from, to);
            // Add this first random number to the list
            lstNumbers.Add(number);
            // Set a count of numbers to 0 to start
            int count = 0;

            do // Repeatedly...
            {
                // ... generate a random number between 1 and the Max
                number = rndNumber.Next(from, to);

                // If the newly generated number in not yet in the list...
                if (!lstNumbers.Contains(number))
                {
                    // ... add it
                    lstNumbers.Add(number);
                }

                // Increase the count
                count++;
            } while (lstNumbers.Count() < finalSize); // Do that again

            // Once the list is built, return it
            return lstNumbers;
        }
    }
}
