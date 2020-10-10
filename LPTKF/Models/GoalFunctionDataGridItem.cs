using System;
using System.Collections.Generic;
using System.Text;

namespace LPTKF.Models {
    class GoalFunctionDataGridItem {
        private GoalFunction goalFunction;

        public List<double> Vars {
            get => goalFunction.Vars;
            set => goalFunction.Vars = value;
        }

        
    }
}
