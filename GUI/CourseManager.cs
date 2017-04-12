using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class CourseManager
    {
        public string Name;
        public List<string> Members;
        public int Lenght
        {
            get
            {
                return Members.Count;
            }
        }

        public CourseManager(string Name)
        {
            this.Name = Name;
            Members = new List<string>();
        }

        public bool Recorded(string member)
        {
            return Members.Contains(member);
        }

        public void AddMember(string member)
        {
            Members.Add(member);
        }
        public void RemoveMember(string member)
        {
            Members.Remove(member);
        }
    }
}
