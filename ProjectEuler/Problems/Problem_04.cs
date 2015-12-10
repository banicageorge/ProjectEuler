using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem_04 : IProblems
    {
        public string Output { get; set; }

        public string Input { get; set; }

        public void run()
        {
            System.Diagnostics.Debug.WriteLine("running problem 04");
            run_solution01();
            System.Diagnostics.Debug.WriteLine("ended problem 04");
        }

        private void run_solution01()
        {
            int n = Int32.Parse(Input);
            int product = 1;
            int result = 1;
            //Quick and dirty, but works (quickly and dirty)
            for (int i = 999; i > 99; i--)
                for (int j = 999; j > 99; j--)
                {
                    product = i * j;
                    String s = product.ToString();
                    if (s[0] == s[s.Length - 1])
                        if (s[1] == s[s.Length - 2])
                            if (s[2] == s[s.Length - 3])
                                if (product > result)
                                    result = product;
                }

            Output = result.ToString();
        }

    }
}
