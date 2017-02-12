using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOS.Models;

namespace ECOS.Booker
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

        public static bool test_student(Student student)
        {
            if (student.First_name != null && student.Last_name != null && student.Album_number>0)
                return true;
            else
                return false;
        }
    }
}