using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPTKF.Models.Exceptions
{
    class MatrixException : Exception
    {
        public MatrixException() : base() { }
        public MatrixException(string message) : base(message) { }
    }
}
