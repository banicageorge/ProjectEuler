using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem_51 : IProblems
    {
        public string Output { get; set; }

        public string Input { get; set; }

        public void run()
        {
            System.Diagnostics.Debug.WriteLine("running problem 51");
            run_solution01();
            System.Diagnostics.Debug.WriteLine("ended problem 51");
        }

        private HashSet<long> generateFirstNPrimes(long n,HashSet<long> existingList)
        {
            HashSet<long> result = new HashSet<long>();
            if (existingList.Count >= n)
                return existingList;
            long i = -1;
            if (existingList.Count == 0)
            {
                result.Add(2);
                i = 3;
            }
            else
            {
                result = existingList;
                i = existingList.Last();
            }
            
            while(result.Count<n)
            {
                 if (isPrime(i, result) == true)
                    result.Add(i);

                i+= 1;
            };
            return result;
        }

        private bool isPrime(long number,HashSet<long> primes)
        {
            bool result = true;           
            foreach (long prime in primes)
                if(number%prime==0)
                {
                    result = false;
                    break;
                }

            return result;
        }

        private List<int> buildPattern(Stack<int> stack,int n)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < n; i++)
                if (stack.Contains(i))
                    result.Add(999);
                else
                    result.Add(i);
            return result;
        }

        private bool patternExists(Stack<int> stack, List<List<int>> patterns,int n)
        {
            bool result = false;
            List<int> pattern = buildPattern(stack, n);

            foreach (List<int> pat in patterns)
            {
                if (pattern.SequenceEqual(pat))
                {
                    result = true;
                    break;
                }
                
            }
            return result;
        }

        private List<List<int>> generatePattern(int n)
        {
            List<List<int>> patterns = new List<List<int>>();
            bool done = false;

            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while(done == false)
            {
                if(patternExists(stack,patterns,n)==false)
                        patterns.Add(buildPattern(stack, n));

                if(stack.Count()+1>=n)
                {
                    while(done == false && stack.Peek() + 1 >= n)
                        if (stack.Count() - 1 > 0)
                            stack.Pop();
                        else
                            done = true;
                    if (done == false)
                    {
                        int last = stack.Peek();
                        stack.Pop();
                        stack.Push(last + 1);
                    }

                }
                else
                {
                    if (stack.Peek() + 1 < n)
                            stack.Push(stack.Peek() + 1);
                    else
                    {
                        while (done == false && stack.Peek() + 1 >= n)
                            if (stack.Count() - 1 > 0)
                                stack.Pop();
                            else
                                done = true;
                        if (done == false)
                        {
                            int last = stack.Peek();
                            stack.Pop();
                            stack.Push(last + 1);
                        };
                    }
                }

            }

            return patterns;
            //
        }
        private void run_solution01()
        {
            long n_family = Int64.Parse(Input);
            //Major weakness/bug: the numbers in a family might be bigger than the biggest pre-computed prime. We'll get to them, eventually, but slower.
            //Also, List<T> is VERY VERY slow, HashSet it's a must.
            HashSet<long> primes = generateFirstNPrimes(100000,new HashSet<long>());
           
            Dictionary < int, List<List<int>>> patterns = new Dictionary<int,List<List<int>>>();
            for (int i = 2; i < 9; i++)
            {
                List<List<int>> pattern_= generatePattern(i);
                patterns.Add(i, pattern_);
            }

            bool found = false;

            int primeIndex = 0;
            int nrdigits = -1;
            List<List<int>> pattern = new List<List<int>>();
            while (found == false)
            {
                long prime = primes.ToList()[primeIndex];

                if(prime.ToString().Length!=nrdigits)
                {
                    nrdigits = prime.ToString().Length;
                    if (patterns.TryGetValue(nrdigits, out pattern) == false)
                    {

                        primeIndex += 1;
                        continue;
                    }
                }

                if(pattern == null)
                {
                    primeIndex += 1;
                    continue;
                }

                if (pattern.Count == 0)
                {
                    primeIndex += 1;
                    continue;
                }
                
                
                foreach (List<int> pat in pattern)
                {
                    HashSet<long> family = new HashSet<long>();                   
                    for (int i = 0; i <= 9; i++)
                    {
                        long number = 0;
                        for (int index = 0; index < pat.Count; index++)
                        {
                            int power1 = (int)Math.Pow(10,pat.Count - index);
                            int power2 = (int)Math.Pow(10, pat.Count - index-1);
                            if (pat[index] != 999)
                                number += (prime % power1) - (prime % power2);
                            else                              
                                number += i * (int)Math.Pow(10, pat.Count - index - 1); 

                        }
                        if (primes.Contains(number)&&family.Contains(number) != true&&number.ToString().Length==nrdigits)
                            family.Add(number);
                    }
                      
                    /*if (family.Count >= 8)
                    {
                        System.Diagnostics.Debug.Write(prime.ToString()+" - ");
                        pat.ForEach(familyitem => System.Diagnostics.Debug.Write(familyitem + ","));
                        System.Diagnostics.Debug.Write(" - ");
                        family.ToList().ForEach(familyitem => System.Diagnostics.Debug.Write(familyitem + ","));
                        System.Diagnostics.Debug.WriteLine("");
                    }*/
                    if(family.Count >= 8)
                    {
                        found = true;
                        Output = "";
                        Output+=prime.ToString() + " - ";
                        pat.ForEach(familyitem => Output+=familyitem + ",");
                        Output+=" - ";
                        family.ToList().ForEach(familyitem => Output+=familyitem + ",");                        
                    }


                }

                if (primeIndex + 2 > primes.Count() && found == false)
                    primes = generateFirstNPrimes(primes.Count + 5000, primes);
                primeIndex+=1;
               
            }
        }

    }
}
