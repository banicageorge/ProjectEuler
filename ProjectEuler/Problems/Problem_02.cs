using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem_02 : IProblems
    {
        public string Output { get; set; }

        public string Input { get; set; }

        public void run()
        {
            System.Diagnostics.Debug.WriteLine("running problem 02");
            run_solution01();
        }

        //will not use recursion for solution_01
        private void run_solution01()
        {
            int n = Int32.Parse(Input);
            int sum = 0;
            int last_term_1 = 0;
            int last_term_2 = 1;
            
            while (last_term_2<n)
            {
                int current = last_term_1 + last_term_2;
                if (current%2 == 0)
                    sum += current;
                last_term_1 = last_term_2;
                last_term_2 = current;
                   
            }

            Output = sum.ToString();
        }

    }
}
