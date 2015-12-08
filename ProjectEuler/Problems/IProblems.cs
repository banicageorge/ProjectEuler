using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler.Problems
{
    interface IProblems
    {


        void run();
        string Output { get; set; }

        string Input { get; set; }

    };

}
