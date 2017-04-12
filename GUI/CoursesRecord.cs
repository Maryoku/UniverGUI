using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class CoursesRecord
    {
        public List<CourseManager> Courses;
        public delegate void MethodContainer();
        public event MethodContainer Update;

        public int Lenght
        {
            get
            {
                return Courses.Count;
            }
        }

        public CoursesRecord()
        {
            Courses = new List<CourseManager>();
        }

        public CourseManager this[int index]
        {
            get
            {
                return Courses[index];
            }
        }

        public bool Recorded(string value)
        {
            foreach (var tmp in Courses)
                if (tmp.Name == value) return true;
            return false;
        }

        public void AddCourse(string value)
        {
            CourseManager tmp = new CourseManager(value);
            Courses.Add(tmp);
            Update();
        }

        public void RemoveCourse(string value)
        {
            foreach (var tmp in Courses)
            {
                if (tmp.Name == value)
                {
                    Courses.Remove(tmp);
                    Update();
                    break;
                }       
            }
        }

        
    }
}
