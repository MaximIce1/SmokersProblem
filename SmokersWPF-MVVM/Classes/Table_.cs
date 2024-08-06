using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokersWPF_MVVM.Classes
{
    class Table_
    { 
        public static Semaphore sem = new(2, 4);
        public static byte res1, res2, res3 = 0;
        public static bool smokingState = false;
    }
}
