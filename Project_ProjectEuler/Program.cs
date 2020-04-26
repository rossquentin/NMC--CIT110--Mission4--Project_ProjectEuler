using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProjectEuler
{

    class Problems
    {
        #region PROJECT EULER PROBLEMS

        public int P001(int num)
        {
            int sum = 0;

            for (int i = 1; i < num; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }

        public int P002(int num)
        {
            int[] fibArray = new int[2];
            int sum = 0;

            fibArray[0] = 1;
            fibArray[1] = 2;
            int sub;

            while (fibArray[1] < num)
            {

                if (fibArray[1] % 2 == 0)
                {
                    sum += fibArray[1];
                }
                sub = fibArray[0];
                fibArray[0] = fibArray[1];
                fibArray[1] += sub;
            }

            return sum;
        }

        public long P003(long num)
        {

            while (true)
            {
                long primeFactor = P003SmallestPrimeFactor(num);

                if (primeFactor < num)
                {
                    num /= primeFactor;
                }
                else
                {
                    return num;
                }

            }
        }

        static long P003SmallestPrimeFactor(long num)
        {
            for (long i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return i;
                }
            }
            return num;
        }

        public String P004()
        {
            string message = "Currently, the author has not figured out a method to solve this problem. Please try another problem.";
            return message;
        }

        // Solution credits to Kristian at mathblog.dk
        // Method uses prime factorization
        // Max is ~ 40 before overflow
        public long P005(int divisorMax)
        {
            long[] primes = P005GeneratePrimes(divisorMax);
            long result = 1;

            for (int i = 0; i < primes.Length; i++)
            {
                long a = (long) Math.Floor(Math.Log(divisorMax) / Math.Log(primes[i]));
                result = result * ((long)Math.Pow(primes[i], a));
            }
            return result;
        }

        public long[] P005GeneratePrimes(int limit)
        {
            List<long> primes = new List<long>();
            bool isPrime;
            int j;

            primes.Add(2);

            for (int i = 3; i <= limit; i++)
            {
                j = 0;
                isPrime = true;
                while (primes[j] * primes[j] <= i)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    j++;
                }
                if (isPrime)
                {
                    primes.Add(i);
                }
            }

            return primes.ToArray<long>();
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            Problems problems = new Problems();

            Console.WriteLine(problems.P005(40));

            Console.ReadKey();
        }
    }
}
