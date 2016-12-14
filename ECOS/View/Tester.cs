using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOS.Models;

namespace ECOS.View
{
    public static class Tester
    {
        public static bool test_worker(Worker worker)
        {
            if (worker.First_name != null && worker.Last_name != null)
                return true;
            else
                return false;
        }
    }
}
