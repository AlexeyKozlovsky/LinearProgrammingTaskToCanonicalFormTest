using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPTKF.Models.Exceptions {
    class SolutionPreciseException : Exception {
        public SolutionPreciseException() : base() { }
        public SolutionPreciseException(string message) : base(message) { }
    }
}
