using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class TechSupport
    {
        public List<string> TechSupportList;

        public TechSupport()
        {
            TechSupportList = new List<string>();
        }

        public bool Recorded(string Name)
        {
            return TechSupportList.Contains(Name);
        }

        public void AddSupport(string value)
        {
            TechSupportList.Add(value);
        }
    }
}
