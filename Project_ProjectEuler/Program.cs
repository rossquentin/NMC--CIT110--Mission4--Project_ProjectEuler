using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_ProjectEuler
{
    class Problems
    {
        #region PROJECT EULER PROBLEM CALCULATIONS

        /// <summary>
        /// Calculates the sum of all multiples of 3 and 5 below a specified max
        /// </summary>
        /// <param name="max">Maximum number to calculate sum to</param>
        /// <returns></returns>
        public int CalculateP001(int max)
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
        public int CalculateP002(int max)
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
        public long CalculateP003(long num)
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
        public int CalculateP004(int numOfDigits)
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
        public long CalculateP005(int divisorMax)
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
        public long CalculateP006(int max)
        {
            long sumOfSquares = 0;
            long squareOfSums = 0;
            long difference;

            for (int i = 0; i <= max; i++)
            {
                sumOfSquares += (long) Math.Pow(i, 2);
            }

            for (int i = 0; i <= max; i++)
            {
                squareOfSums += i;
            }

            squareOfSums = (long) Math.Pow(squareOfSums, 2);

            difference = (long) Math.Abs(sumOfSquares - squareOfSums);

            return difference;
        }

        /// <summary>
        /// Calculates the nth prime given
        /// </summary>
        /// <param name="numOfPrimes">nth prime</param>
        /// <returns></returns>
        public double CalculateP007(int numOfPrimes)
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
                i += 500000;
            } while (primeArray.Count <= numOfPrimes);

            return largestPrime;
        }

        /// <summary>
        /// Calculates the largest product given an 1000-digit number in n consecutive digits
        /// </summary>
        /// <param name="numOfDigits">n consecutive digits</param>
        /// <returns></returns>
        public double CalculateP008(int numOfDigits)
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
        /// <returns>-1 if none exist, otherwise returns the value</returns>
        public double CalculateP009(double abcSum)
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
        public long CalculateP010(int maxPrimes)
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
        static Problems problems = new Problems();

        #region MAIN

        static void Main(string[] args)
        {
            SetTheme();

            DisplayMainMenu();
        }

        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;

            Console.Clear();
        }

        static void DisplayMainMenu()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Select a problem");
                Console.WriteLine("\tb) About the application");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        ProblemDisplayMenuScreen();
                        break;

                    case "b":
                        DisplayAboutApplication();
                        break;

                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }
        #endregion

        #region PROJECT EULER MAIN MENU

        static void ProblemDisplayMenuScreen()
        {
            Console.CursorVisible = true;

            Problems problems = new Problems();
            bool quitApplication = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Problem Selection");

                //
                // get user menu choice
                //
                Console.WriteLine("\t1) Multiples of 3 and 5");
                Console.WriteLine("\t2) Even Fibonacci numbers");
                Console.WriteLine("\t3) Largest prime factor");
                Console.WriteLine("\t4) Largest palindrome product");
                Console.WriteLine("\t5) Smallest multiple");
                Console.WriteLine("\t6) Sum square difference");
                Console.WriteLine("\t7) 10,001st prime");
                Console.WriteLine("\t8) Largest product in a series");
                Console.WriteLine("\t9) Special Pythagorean triplets");
                Console.WriteLine("\t10) Summation of primes");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "1":
                        ProblemDisplayP001();
                        break;

                    case "2":
                        ProblemDisplayP002();
                        break;

                    case "3":
                        ProblemDisplayP003();
                        break;

                    case "4":
                        ProblemDisplayP004();
                        break;

                    case "5":
                        ProblemDisplayP005();
                        break;

                    case "6":
                        ProblemDisplayP006();
                        break;

                    case "7":
                        ProblemDisplayP007();
                        break;

                    case "8":
                        ProblemDisplayP008();
                        break;

                    case "9":
                        ProblemDisplayP009();
                        break;
                        
                    case "10":
                        ProblemDisplayP010();
                        break;

                    case "q":
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a correct menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #endregion

        #region PROJECT EULER PROBLEM MENU

        static void ProblemDisplayP001()
        {
            int userNum;
            int sum;
            bool continueProblem = false;

            do
            {
                DisplayScreenHeader("Problem 1: Multiples of 3 and 5");

                Console.WriteLine("\tIf we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9." +
                    "\n\tThe sum of these multiples is 23.");
                GetValidInteger("\n\tEnter a maximum value to calculate the sum of multiples" +
                    "\n\tof 3 and 5 from 1 until the value you enter: ", 1, 2147483647, out userNum);

                sum = problems.CalculateP001(userNum);
                Console.WriteLine("\tSum of all multiples of 3 and 5 between 1 and {0} is: {1}", userNum, sum);

                DisplayContinuePrompt();

                DisplayScreenHeader("Problem 1: Multiples of 3 and 5");
                continueProblem = GetContinueProblem();
            } while (continueProblem);
            DisplayContinuePrompt();
        }

        static void ProblemDisplayP002()
        {
            int userNum;
            int sum;
            bool continueProblem = false;

            do
            {
                DisplayScreenHeader("Problem 2: Even Fibonacci numbers");

                Console.WriteLine("\tEach new term in the Fibonacci sequence is generated by adding the previous two terms. " +
                    "\n\tBy starting with 1 and 2, the first 10 terms will be:" +
                    "\n\t\t1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...");
                GetValidInteger("\n\tEnter a maximum value to calculate the sum of even-valued terms: ", 1, 2147483647, out userNum);

                sum = problems.CalculateP002(userNum);
                Console.WriteLine("\tSum of all even Fibonacci numbers between 1 and {0} is: {1}", userNum, sum);

                DisplayContinuePrompt();

                DisplayScreenHeader("Problem 2: Even Fibonacci Numbers");
                continueProblem = GetContinueProblem();
            } while (continueProblem);
            DisplayContinuePrompt();
        }

        static void ProblemDisplayP003()
        {
            long userNum;
            long largestFactor;
            bool continueProblem = false;

            do
            {
                DisplayScreenHeader("Problem 3: Largest prime factor");

                Console.WriteLine("\tThe prime factors of 13195 are 5, 7, 13 and 29, and thus the largest prime factor is 29.");
                GetValidLong("\n\tEnter a value to find the largest prime factor of: ", 1, 9223372036854775807, out userNum);

                largestFactor = problems.CalculateP003(userNum);
                Console.WriteLine("\tLargest prime factor of {0} is: {1}", userNum, largestFactor);

                DisplayContinuePrompt();

                DisplayScreenHeader("Problem 3: Largest prime factor");
                continueProblem = GetContinueProblem();
            } while (continueProblem);
            DisplayContinuePrompt();
        }

        static void ProblemDisplayP004()
        {
            int userNum;
            int product;
            bool continueProblem = false;

            do
            {
                DisplayScreenHeader("Problem 4: Largest palindrome product");

                Console.WriteLine("\tA palindromic number reads the same both ways. " +
                    "\n\tThe largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.");
                GetValidInteger("\n\tEnter the number of digits (1-4) to find the largest palidromic product of two numbers: ", 1, 4, out userNum);

                product = problems.CalculateP004(userNum);
                Console.WriteLine("\tLargest palidromic product given two {0}-digit numbers is: {1}", userNum, product);

                DisplayContinuePrompt();

                DisplayScreenHeader("Problem 4: Largest palindrome product");
                continueProblem = GetContinueProblem();
            } while (continueProblem);
            DisplayContinuePrompt();
        }

        static void ProblemDisplayP005()
        {
            int userNum;
            long smallestMultiple;
            bool continueProblem = false;

            do
            {
                DisplayScreenHeader("Problem 5: Smallest multiple");

                Console.WriteLine("\t2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.");
                GetValidInteger("\n\tEnter a value for the range from 1 to n to find the smallest evenly divisible number: ", 1, 40, out userNum);

                smallestMultiple = problems.CalculateP005(userNum);
                Console.WriteLine("\tSmallest evenly divisible number of numbers 1 to {0} is: {1}", userNum, smallestMultiple);

                DisplayContinuePrompt();

                DisplayScreenHeader("Problem 5: Smallest multiple");
                continueProblem = GetContinueProblem();
            } while (continueProblem);
            DisplayContinuePrompt();
        }

        static void ProblemDisplayP006()
        {
            int userNum;
            long difference;
            bool continueProblem = false;

            do
            {
                DisplayScreenHeader("Problem 6: Sum square difference");

                Console.WriteLine("\tThe sum of the squares of the first ten natural numbers is:" +
                    "\n\t\t1^2 + 2^2 + ... + 10^2 = 385" +
                    "\n\tThe square of the sum of the first ten natural numbers is:" +
                    "\n\t\t(1 + 2 + ... + 10)^2 = 3025" +
                    "\n\tHence the difference between the sum of the squares of the first ten natural numbers" +
                    "\n\tand the square of the sum is 3025−385=2640.");
                GetValidInteger("\n\tEnter a value to find the difference between the sum of squares and square of sums: ", 1, 40000, out userNum);

                difference = problems.CalculateP006(userNum);
                Console.WriteLine("\tDifference of sum of squares and square of sums from 1 to {0} is: {1}", userNum, difference);

                DisplayContinuePrompt();

                DisplayScreenHeader("Problem 6: Sum square difference");
                continueProblem = GetContinueProblem();
            } while (continueProblem);
            DisplayContinuePrompt();
        }

        static void ProblemDisplayP007()
        {
            int userNum;
            double prime;
            bool continueProblem = false;

            do
            {
                DisplayScreenHeader("Problem 7: 10001st prime");

                Console.WriteLine("\tBy listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.");
                GetValidInteger("\n\tEnter a value to find the nth prime: ", 1, 100000, out userNum);

                prime = problems.CalculateP007(userNum);
                Console.WriteLine("\tThe {0}th prime is: {1}", userNum, prime);

                DisplayContinuePrompt();

                DisplayScreenHeader("Problem 7: 10001st prime");
                continueProblem = GetContinueProblem();
            } while (continueProblem);
            DisplayContinuePrompt();
        }

        static void ProblemDisplayP008()
        {
            int userNum;
            double product;
            bool continueProblem = false;

            do
            {
                DisplayScreenHeader("Problem 8: Largest product in a series");

                Console.WriteLine("\tThe four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832." +
                "\n\t7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843" +
                "\n\t8586156078911294949545950173795833195285320880551112540698747158523863050715693290963295227443043557" +
                "\n\t6689664895044524452316173185640309871112172238311362229893423380308135336276614282806444486645238749" +
                "\n\t3035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776" +
                "\n\t6572733300105336788122023542180975125454059475224352584907711670556013604839586446706324415722155397" +
                "\n\t5369781797784617406495514929086256932197846862248283972241375657056057490261407972968652414535100474" +
                "\n\t8216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586" +
                "\n\t1786645835912456652947654568284891288314260769004224219022671055626321111109370544217506941658960408" +
                "\n\t0719840385096245544436298123098787992724428490918884580156166097919133875499200524063689912560717606" +
                "\n\t0588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450");
                GetValidInteger("\n\tEnter a value to find the greatest product of any n consecutive digits: ", 1, 1000, out userNum);

                product = problems.CalculateP008(userNum);
                Console.WriteLine("\tThe greatest product of {0} consecutive digits is: {0}", userNum, product);

                DisplayContinuePrompt();

                DisplayScreenHeader("Problem 8: Largest product in a series");
                continueProblem = GetContinueProblem();
            } while (continueProblem);
            DisplayContinuePrompt();
        }

        static void ProblemDisplayP009()
        {
            int userNum;
            double sum;
            bool continueProblem = false;

            do
            {
                DisplayScreenHeader("Problem 9: Special Pythagorean triplet");

                Console.WriteLine("\tA Pythagorean triplet is a set of three natural numbers, a < b < c, for which: " +
                    "\n\t\ta^2 + b^2 = c^2");
                GetValidInteger("\n\tEnter a value to find the product, if any, of a, b, and c where" +
                    "\n\ta + b + c = n: ", 1, 10000, out userNum);

                sum = problems.CalculateP009(userNum);
                if(sum == -1)
                {
                    Console.WriteLine("\tThere exists no value for a, b, and c where a + b + c = n.");
                }else
                {
                    Console.WriteLine("\tThe value of a*b*c given a + b + c = {0} is: {1}", userNum, sum);
                }

                DisplayContinuePrompt();

                DisplayScreenHeader("Problem 9: Special Pythagorean triplet");
                continueProblem = GetContinueProblem();
            } while (continueProblem);
            DisplayContinuePrompt();
        }

        static void ProblemDisplayP010()
        {
            int userNum;
            long prime;
            bool continueProblem = false;

            do
            {
                DisplayScreenHeader("Problem 10: Summation of primes");

                Console.WriteLine("\tThe sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.");
                GetValidInteger("\n\tEnter a value to find the sum of all primes below n: ", 1, 10000000, out userNum);

                prime = problems.CalculateP010(userNum);
                Console.WriteLine("\tThe sum of all primes below {0} is: {1}", userNum, prime);

                DisplayContinuePrompt();

                DisplayScreenHeader("Problem 10: Summation of primes");
                continueProblem = GetContinueProblem();
            } while (continueProblem);
            DisplayContinuePrompt();
        }

        #endregion

        #region ABOUT APPLICATION MENU

        private static void DisplayAboutApplication()
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("About Application");

            Console.WriteLine("\t\tThis application aims to extend on what the website projecteuler.net");
            Console.WriteLine("\tprovides. Currently available are 10 problems that allow the user to select");
            Console.WriteLine("\tone and get a brief description on the problem as well as an example solution. \n");

            Console.WriteLine("\t\tThe user will then be able to input their own data that is relevant to");
            Console.WriteLine("\tthe problem given to the user. This will run the calculation of the problem and");
            Console.WriteLine("\tpresent the new solution to the user.\n");

            Console.WriteLine("\t\tOnce this is complete, the program will ask the user if they wish to");
            Console.WriteLine("\trun another calculation or return to the problem menu to select a new one.\n");

            Console.WriteLine("\t\tIf the user decides that they are finished, they will have the option to");
            Console.WriteLine("\treturn to the main menu to where they can exit the application.\n");

            DisplayContinuePrompt();
        }
        #endregion

        #region USER INTERFACE

        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tProject Euler Calculator");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using the Project Euler Calculator!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }
            
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName}.");
            Console.ReadKey();
        }

        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        static bool GetContinueProblem()
        {
            bool continueProblem = false;
            bool isValid;
            string userResponse;

            do
            {
                isValid = true;
                Console.Write("\tDo you wish to redo the problem [yes | no]? ");
                userResponse = Console.ReadLine();

                if(userResponse.ToLower() == "yes")
                {
                    continueProblem = true;
                    
                }else if(userResponse.ToLower() == "no")
                {
                    continueProblem = false;
                    
                }else
                {
                    isValid = false;
                    Console.WriteLine("\tPlease enter yes or no.");
                    DisplayContinuePrompt();
                }
            } while (!isValid);
            return continueProblem;
        }

        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }
        #endregion

        #region HELPER METHODS

        private static int GetValidInteger(string prompt, int minimumValue, int maximumValue, out int validInteger)
        {
            bool isValid;

            do
            {
                Console.Write(prompt);
                if ((minimumValue == 0 && maximumValue == 0) || maximumValue - minimumValue == 0)
                {
                    isValid = int.TryParse(Console.ReadLine(), out validInteger);
                    if (!isValid)
                    {
                        Console.WriteLine("\tPlease enter a valid integer value.");
                    }
                }
                else
                {
                    isValid = int.TryParse(Console.ReadLine(), out validInteger);
                    if (!isValid)
                    {
                        Console.WriteLine("\tPlease enter a valid integer value");
                    }
                    else if (validInteger < minimumValue)
                    {
                        isValid = false;
                        Console.WriteLine("\tPlease enter a valid integer greater than or equal to {0}.", minimumValue);

                    }
                    else if (validInteger > maximumValue)
                    {
                        isValid = false;
                        Console.WriteLine("\tPlease enter a valid integer less than or equal to {0}.", maximumValue);
                    }
                }
            } while (!isValid);

            return validInteger;
        }

        private static long GetValidLong(string prompt, long minimumValue, long maximumValue, out long validInteger)
        {
            bool isValid;

            do
            {
                Console.Write(prompt);
                if ((minimumValue == 0 && maximumValue == 0) || maximumValue - minimumValue == 0)
                {
                    isValid = long.TryParse(Console.ReadLine(), out validInteger);
                    if (!isValid)
                    {
                        Console.WriteLine("Please enter a valid value.");
                    }
                }
                else
                {
                    isValid = long.TryParse(Console.ReadLine(), out validInteger);
                    if (!isValid)
                    {
                        Console.WriteLine("Please enter a valid value");
                    }
                    else if (validInteger < minimumValue)
                    {
                        isValid = false;
                        Console.WriteLine("Please enter a valid value greater than or equal to {0}.", minimumValue);

                    }
                    else if (validInteger > maximumValue)
                    {
                        isValid = false;
                        Console.WriteLine("Please enter a valid value less than or equal to {0}.", maximumValue);
                    }
                }
            } while (!isValid);

            return validInteger;
        }

        private static double GetValidDouble(string prompt, double minimumValue, double maximumValue, out double validDouble)
        {
            bool isValid;

            do
            {
                Console.Write(prompt);
                if ((minimumValue == 0 && maximumValue == 0 ) || maximumValue - minimumValue == 0)
                {
                    isValid = double.TryParse(Console.ReadLine(), out validDouble);
                    if (!isValid)
                    {
                        Console.WriteLine("Please enter a valid value.");

                    }
                }
                else
                {
                    isValid = double.TryParse(Console.ReadLine(), out validDouble);
                    if (!isValid)
                    {
                        Console.WriteLine("Please enter a valid value");
                    }
                    else if (validDouble < minimumValue)
                    {
                        isValid = false;
                        Console.WriteLine("Please enter a valid value greater than or equal to {0}.", minimumValue);

                    }
                    else if (validDouble > maximumValue)
                    {
                        isValid = false;
                        Console.WriteLine("Please enter a valid value less than or equal to {0}.", maximumValue);
                    }
                }
            } while (!isValid);

            return validDouble;
        }

        #endregion
    }
}
