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
    public partial class TechSupportWindow : Form
    {
        CoursesRecord Courses;

        Label ListLabel;
        ListBox CoursesList;
        Label CourseLabel;
        TextBox CourseName;
        Button CreateCourse;
        Button RemoveCourse;

        public TechSupportWindow(CoursesRecord Courses)
        {
            this.Courses = Courses;

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
            CourseLabel = new Label
            {
                Location = new Point(5, CoursesList.Bottom),
                Size = new Size(ClientSize.Width - 10, 15),
                Text = "Введите название курса"
            };
            CourseName = new TextBox
            {
                Location = new Point(5, CourseLabel.Bottom),
                Size = CourseLabel.Size
            };
            CreateCourse = new Button
            {
                Location = new Point(5, CourseName.Bottom + 5),
                Size = new Size(ClientSize.Width / 2 - 10, 30),
                Enabled = false,
                Text = "Создать курс"
            };
            RemoveCourse = new Button
            {
                Location = new Point(CreateCourse.Right + 5, CourseName.Bottom + 5),
                Size = new Size(ClientSize.Width / 2 - 5, 30),
                Enabled = false,
                Text = "Удалить курс"
            };

            Controls.Add(ListLabel);
            Controls.Add(CourseLabel);
            Controls.Add(CourseName);
            Controls.Add(CreateCourse);
            Controls.Add(RemoveCourse);
            Controls.Add(CoursesList);

            UpdateList();

            CourseName.TextChanged += new EventHandler(CourseName_TextChanged);
            CreateCourse.Click += new EventHandler(CreateCourse_Click);
            RemoveCourse.Click += new EventHandler(RemoveCourse_Click);
            Courses.Update += UpdateList;
        }

        public void UpdateList()
        {
            CoursesList.Items.Clear();

            for (int i = 0; i < Courses.Lenght; i++)
            {
                CoursesList.Items.Add(Courses[i].Name);
            }
        }

        private void CourseName_TextChanged(object sender, EventArgs e)
        {
            if (CourseName.Text != String.Empty)
            {
                CreateCourse.Enabled = true;
                RemoveCourse.Enabled = true;
            }
            else
            {
                CreateCourse.Enabled = false;
                RemoveCourse.Enabled = false;
            }
        }

        private void CreateCourse_Click(object sender, EventArgs e)
        {
            if (!Courses.Recorded(CourseName.Text))
            {
                Courses.AddCourse(CourseName.Text);
                CourseName.Clear();
            }
            else MessageBox.Show(this, "Курс уже создан", "Notification", MessageBoxButtons.OK);
        }

        private void RemoveCourse_Click(object sender, EventArgs e)
        {
            if (Courses.Recorded(CourseName.Text))
            {
                Courses.RemoveCourse(CourseName.Text);
                CourseName.Clear();
            }
            else MessageBox.Show(this, "Курса не существует", "Notification", MessageBoxButtons.OK);
        }
}
}
