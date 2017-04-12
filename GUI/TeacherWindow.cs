using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class TeacherWindow : Form
    {
        CoursesRecord Courses;
        Label ListLabel;
        TreeView CoursesList;

        public TeacherWindow(CoursesRecord Courses)
        {
            this.Courses = Courses;

            ListLabel = new Label
            {
                Location = new Point(5, 5),
                Size = new Size(ClientSize.Width - 10, 15),
                Text = "Список студентов подписанных на курсы:"
            };
            CoursesList = new TreeView
            {
                Location = new Point(5, ListLabel.Bottom + 5),
                Size = new Size(ClientSize.Width - 10, 100)
            };

            Controls.Add(ListLabel);
            Controls.Add(CoursesList);

            AddNodes();
        }

        private void AddNodes()
        {
            for (int i = 0; i < Courses.Lenght; i++)
            {
                TreeNode driveNode = new TreeNode { Text = Courses[i].Name };
                AddChildList(driveNode, Courses[i].Name);
                CoursesList.Nodes.Add(driveNode);
            }
        }

        private void AddChildList(TreeNode driveNode, string course)
        {
            foreach (var tmp in Courses.Courses)
            {
                if (tmp.Name == course)
                {
                    for (int i = 0; i < tmp.Lenght; i++)
                    {
                        TreeNode ChildList = new TreeNode();
                        ChildList.Text = tmp.Members[i];
                        driveNode.Nodes.Add(ChildList);
                    }
                }
            }
        }

    }
}
