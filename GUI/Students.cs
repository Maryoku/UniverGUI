using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class Students
    {
        public List<string> StudentsList;

        public Students()
        {
            StudentsList = new List<string>();
        }

        public bool Recorded(string Name)
        {
            return StudentsList.Contains(Name);
        }

        public void AddStudent(string value)
        {
            StudentsList.Add(value);
        }
    }
}
