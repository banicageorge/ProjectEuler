using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem_05 : IProblems
    {
        public string Output { get; set; }

        public string Input { get; set; }

        public void run()
        {
            System.Diagnostics.Debug.WriteLine("running problem 05");
            run_solution01();
            System.Diagnostics.Debug.WriteLine("ended problem 05");
        }

        private void run_solution01()
        {
            int n = Int32.Parse(Input);
            bool found = false;
            long i = 2*3*5*7*11*13*17*19; 

            while (found == false)
            {
                bool all = true;
                for (int k = 2; k < 21; k++)
                    if (i % k != 0)
                    {
                        all = false;
                        break;
                    }
                i += 2; 
                found = all;
            }

            Output = (i-2).ToString();
        }

    }
}
