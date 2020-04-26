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

        /// <summary>
        /// Calculates the sum of all multiples of 3 and 5 below a specified max
        /// </summary>
        /// <param name="max">Maximum number to calculate sum to</param>
        /// <returns></returns>
        public int P001(int max)
        {
            int sum = 0;

            for (int i = 1; i < max; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            return sum;
        }

        /// <summary>
        /// Calculates the sum of all fibonacci numbers below a specified max
        /// </summary>
        /// <param name="max">Maximum number to calculate sum to</param>
        /// <returns></returns>
        public int P002(int max)
        {
            int[] fibArray = new int[2];
            int sum = 0;

            fibArray[0] = 1;
            fibArray[1] = 2;
            int sub;

            while (fibArray[1] < max)
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

        /// <summary>
        /// Calculates the largest prime factor of a given number
        /// </summary>
        /// <param name="num">Number to calculate the prime factor of</param>
        /// <returns></returns>
        public long P003(long num)
        {

            while (true)
            {
                long primeFactor = SmallestPrimeFactor(num);

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

        /// <summary>
        /// Calculates the largest palidrome product in a specified digit range (2 - 4 digits)
        /// </summary>
        /// <param name="numOfDigits">Number of digits to calculate the largest palindrome product from</param>
        /// <returns></returns>
        public int P004(int numOfDigits)
        {
            int startNum = (int) Math.Pow(10, numOfDigits-1);
            int endNum = (int) Math.Pow(10, numOfDigits);
            int testNum = 0;
            int largestNum = 0;
            string testNumString;

            for (int i = startNum; i < endNum; i++)
            {
                for (int j = startNum; j < endNum; j++)
                {
                    testNum = i * j;
                    testNumString = testNum.ToString();
                    if (CheckPalindrome(testNumString))
                    {
                        if (testNum >= largestNum)
                        {
                            largestNum = testNum;
                        }
                    }
                }
            }
            return largestNum;
        }

        // Solution credits to Kristian at mathblog.dk
        // Method uses prime factorization
        // Max is ~ 40 before overflow

        /// <summary>
        /// Calculates the smallest number that is evenly divisible by a given range of numbers
        /// </summary>
        /// <param name="divisorMax">Range from 1 to the divisorMax to calculat eht smallest number evenly divisible</param>
        /// <returns></returns>
        public long P005(int divisorMax)
        {
            List<long> primes = GeneratePrimes(divisorMax);
            long result = 1;

            for (int i = 0; i < primes.Count; i++)
            {
                long a = (long) Math.Floor(Math.Log(divisorMax) / Math.Log(primes[i]));
                result *= ((long)Math.Pow(primes[i], a));
            }
            return result;
        }

        /// <summary>
        /// Calculates the difference between the sum of squares and the square of sums
        /// </summary>
        /// <param name="max">Maximum natural numbers to calculate from</param>
        /// <returns></returns>
        public int P006(int max)
        {
            int sumOfSquares = 0;
            int squareOfSums = 0;
            int difference;

            for (int i = 0; i <= max; i++)
            {
                sumOfSquares += (int) Math.Pow(i, 2);
            }

            for (int i = 0; i <= max; i++)
            {
                squareOfSums += i;
            }

            squareOfSums = (int) Math.Pow(squareOfSums, 2);

            difference = (int)Math.Abs(sumOfSquares - squareOfSums);

            Console.WriteLine("Sum of Squares = {0}", sumOfSquares);
            Console.WriteLine("Square of Sums = {0}", squareOfSums);
            return difference;
        }

        /// <summary>
        /// Calculates the nth prime given
        /// </summary>
        /// <param name="numOfPrimes">nth prime</param>
        /// <returns></returns>
        public double P007(int numOfPrimes)
        {
            long largestPrime = 0;
            List<long> primeArray;
            int i = 0;

            do
            {
                
                primeArray = GeneratePrimes(i);
                if (primeArray.Count >= numOfPrimes)
                {
                    largestPrime = primeArray.ElementAt(numOfPrimes - 1);
                }
                i += 100;
            } while (primeArray.Count <= numOfPrimes);

            return largestPrime;
        }

        /// <summary>
        /// Calculates the largest product given an 1000-digit number in n consecutive digits
        /// </summary>
        /// <param name="numOfDigits">n consecutive digits</param>
        /// <returns></returns>
        public double P008(int numOfDigits)
        {
            string num = "73167176531330624919225119674426574742355349194934" +
                "96983520312774506326239578318016984801869478851843" +
                "85861560789112949495459501737958331952853208805511" +
                "12540698747158523863050715693290963295227443043557" +
                "66896648950445244523161731856403098711121722383113" +
                "62229893423380308135336276614282806444486645238749" +
                "30358907296290491560440772390713810515859307960866" +
                "70172427121883998797908792274921901699720888093776" +
                "65727333001053367881220235421809751254540594752243" +
                "52584907711670556013604839586446706324415722155397" +
                "53697817977846174064955149290862569321978468622482" +
                "83972241375657056057490261407972968652414535100474" +
                "82166370484403199890008895243450658541227588666881" +
                "16427171479924442928230863465674813919123162824586" +
                "17866458359124566529476545682848912883142607690042" +
                "24219022671055626321111109370544217506941658960408" +
                "07198403850962455444362981230987879927244284909188" +
                "84580156166097919133875499200524063689912560717606" + 
                "05886116467109405077541002256983155200055935729725" +
                "71636269561882670428252483600823257530420752963450";

            double largestProduct = 0;
            string testedNum;
            double currentProduct = 1;

            for (int i = 0; i <= num.Length-numOfDigits; i++)
            {
                testedNum = num.Substring(i, numOfDigits);
                

                for (int j = 0; j < testedNum.ToString().Length; j++)
                {
                   // Console.WriteLine(testedNum.Substring(j,1));
                    currentProduct *= int.Parse(testedNum.Substring(j,1));
                    
                }
                if (currentProduct >= largestProduct)
                {
                    largestProduct = currentProduct;
                }
                currentProduct = 1;
            }

            return largestProduct;
        }

        /// <summary>
        /// Calculates the largest Pythagorean triplet, if any, with a given sum of a, b, and c.
        /// </summary>
        /// <param name="abcSum">Sum of a, b, and c</param>
        /// <returns></returns>
        public double P009(double abcSum)
        {
            double a;
            double b;
            double c;
            double product = -1;

            for (a = 1; a < abcSum-1; a++)
            {
                for (b = 2; b < abcSum; b++)
                {
                    c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

                    if(a+b+c == abcSum)
                    {
                        product = a * b * c;
                    }
                }
            }
            return product;
        }


        /// <summary>
        /// Calculates the sum of n number of primes
        /// </summary>
        /// <param name="maxPrimes">number of primes</param>
        /// <returns></returns>
        public long P010(int maxPrimes)
        {
            List<long> primeArray = GeneratePrimes(maxPrimes);
            long sum;

            sum = primeArray.Sum();

            return sum;
        }
        #endregion

        #region PROJECT EULER PROBLEM HELPERS

        public List<long> GeneratePrimes(int limit)
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

            return primes;
        }

        static long SmallestPrimeFactor(long num)
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

        static bool CheckPalindrome(string input)
        {
            bool checkPalidrome = input.SequenceEqual(input.Reverse());

            return checkPalidrome;
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            Problems problems = new Problems();

            Console.WriteLine(problems.P010(10));

            Console.ReadKey();
        }
    }
}
