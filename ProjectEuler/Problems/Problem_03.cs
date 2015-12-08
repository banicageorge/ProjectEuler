using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem_03 : IProblems
    {
        public string Output { get; set; }

        public string Input { get; set; }

        public void run()
        {
            System.Diagnostics.Debug.WriteLine("running problem 03");
            run_solution01();
        }

        private void run_solution01()
        {
            long n = Int64.Parse(Input);
            List<long> primes = new List<long>();
            List<long> factors = new List<long>();
            primes.Add(2);
            if(n%2==0)
                factors.Add(2);

            //sketchy idea: test only factors up to n/2+1
            for (long i = 3; i < n/2+1; i++)
            {
                bool isPrime = true;
                foreach (long  prime in primes)
                {
                    //long prime = Convert.ToInt64(prime_);
                    if (i%prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                };
                if (isPrime == true)
                {
                    primes.Add(i);
                    if (n % i == 0)
                        factors.Add(i);
                }
                long product = 1;

                //this loop fails for factors that are raised to a power
                //e.g. for n=360 (2^3*3^2*5) it will test all primes up to n/2, it won't stop after 5
                foreach (long factor in factors)
                {
                    product*= factor;
                }
                if (product >= n)
                    break;
            
            }
            Output = Convert.ToString(factors[factors.Count-1]);
            
        }

    }
}

