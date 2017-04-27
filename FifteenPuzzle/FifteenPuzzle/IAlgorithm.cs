using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public interface IAlgorithm
    {
        int MaxDepthOfRecursion { get; set; }

        Solution Search(string moves);
    }
}
