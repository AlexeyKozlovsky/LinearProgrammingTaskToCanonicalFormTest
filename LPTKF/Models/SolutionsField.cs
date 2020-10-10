using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LPTKF.Models
{
    class SolutionsField
    {
        private List<Solution> solutions;

        public Solution this[int index] {
            get {
                return this.solutions[index];
            }
            set {
                this.solutions[index] = value;
            }
        }

        public int BasisSolutions {
            get {
                return this.solutions.Count;
            }
        }

        public int NonNegativeSolutions {
            get {
                int count = 0;
                foreach (Solution solution in this.solutions)
                    if (solution.IsNonNegative) count++;

                return count;
            }
        }

        public SolutionsField(params Solution[] solutions) {
            this.solutions = solutions.ToList<Solution>();
        }

        public SolutionsField(List<Solution> solutions) {
            this.solutions = solutions;
        }

        public void Add(Solution solution) => this.solutions.Add(solution);
    }
}
