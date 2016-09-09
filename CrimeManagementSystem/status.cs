using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeManagementSystem
{
    public static class status
    {
        private static bool stsa = false;
        public static void setstatus(bool sts){
            stsa = sts;
        }
        public static bool getstatus()
        {
            return stsa;
        }
    }
}
