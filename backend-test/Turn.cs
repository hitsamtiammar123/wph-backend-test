using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_test
{
    internal class Turn
    {
        public int Round { get; set; }
        public string Winner { get; set; }

        public string ChoiceForP1 { get; set; }

        public string ChoiceForP2 { get; set; }

        public int RemainingHealthForP1 { get; set; }

        public int RemainingHealthForP2 { get; set; }
    }
}
