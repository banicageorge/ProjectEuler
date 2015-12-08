using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    class Problem_01 : IProblems
    {
        public string Output { get; set; }

        public string Input { get; set; }

        public void run()
        {
            System.Diagnostics.Debug.WriteLine("running problem 01");
            run_solution01();
        }

        private void run_solution01()
        {
            int n = Int32.Parse(Input);
            int sum = 0;
            for (int i = 0; i < n; i++)
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;

            Output = sum.ToString();
        }

    }
}
