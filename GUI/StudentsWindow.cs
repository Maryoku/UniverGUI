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
    public partial class StudentsWindow : Form
    {
        CoursesRecord Courses;
        //CourseManager Members;
        Label ListLabel;
        ListBox CoursesList;
        Button FollowCourse;
        Button UnfollowCourse;

        public StudentsWindow(CoursesRecord Courses, string Name)
        {
            this.Courses = Courses;
            this.Name = Name;
            //Members = new CourseMembers();

            ListLabel = new Label
            {
                Location = new Point(5, 5),
                Size = new Size(ClientSize.Width - 10, 15),
                Text = "Список курсов:"
            };
            CoursesList = new ListBox
            {
                Location = new Point(5, ListLabel.Bottom + 5),
                Size = new Size(ClientSize.Width - 10, 100)
            };
            FollowCourse = new Button
            {
                Location = new Point(5, CoursesList.Bottom + 5),
                Size = new Size(ClientSize.Width / 2 - 10, 30),
                Text = "Подписаться на курс"
            };
            UnfollowCourse = new Button
            {
                Location = new Point(FollowCourse.Right + 5, CoursesList.Bottom + 5),
                Size = new Size(ClientSize.Width / 2 - 5, 30),
                Enabled = false,
                Text = "Отписаться от курса"
            };

            Controls.Add(ListLabel);
            Controls.Add(CoursesList);
            Controls.Add(FollowCourse);
            Controls.Add(UnfollowCourse);

            UpdateList();

            FollowCourse.Click += new EventHandler(FollowCourse_Click);
            UnfollowCourse.Click += new EventHandler(UnfollowCourse_Click);
            CoursesList.SelectedIndexChanged += new EventHandler(CoursesList_SelectedIndexChanged);
        }
        public void UpdateList()
        {
            CoursesList.Items.Clear();

            for (int i = 0; i < Courses.Lenght; i++)
            {
                CoursesList.Items.Add(Courses[i].Name);
            }
        }

        private void CoursesList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            foreach (var tmp in Courses.Courses)
            {
                if (tmp.Name == CoursesList.Text && !tmp.Recorded(Name))
                {
                    UnfollowCourse.Enabled = false;
                    FollowCourse.Enabled = true;
                }
                else if (tmp.Name == CoursesList.Text && tmp.Recorded(Name))
                {
                    UnfollowCourse.Enabled = true;
                    FollowCourse.Enabled = false;
                }
            }
        }
        private void FollowCourse_Click(object sender, EventArgs e)
        {
            foreach (var tmp in Courses.Courses)
            {
                if (tmp.Name == CoursesList.Text)
                {
                    tmp.AddMember(Name);
                    UnfollowCourse.Enabled = true;
                    FollowCourse.Enabled = false;
                    MessageBox.Show(this, "Вы подписались на курс " + CoursesList.SelectedItem, "Notification", MessageBoxButtons.OK);
                }
            }
        }
        private void UnfollowCourse_Click(object sender, EventArgs e)
        {
            foreach (var tmp in Courses.Courses)
            {
                if (tmp.Name == CoursesList.Text)
                {
                    tmp.RemoveMember(Name);
                    UnfollowCourse.Enabled = false;
                    FollowCourse.Enabled = true;
                    MessageBox.Show(this, "Вы отписались от курса " + CoursesList.SelectedItem, "Notification", MessageBoxButtons.OK);
                }
            }
        }
    }
}
