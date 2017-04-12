using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Teachers
    {
        public List<string> TeachersList;

        public Teachers()
        {
            TeachersList = new List<string>();
        }

        public bool Recorded(string Name)
        {
            return TeachersList.Contains(Name);
        }

        public void AddTeacher(string value)
        {
            TeachersList.Add(value);
        }
    }
}
