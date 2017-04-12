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
    public partial class Sign_In : Form
    {
        CoursesRecord Courses;
        Students StudentList;
        TechSupport Support;
        Teachers TeacherList;

        Label EnterLabel;
        TextBox NameBox;
        RadioButton Student;
        RadioButton Teacher;
        RadioButton TechSupport;
        Panel ChooseBox;
        Button Login;

        public Sign_In()
        {
            Courses = new CoursesRecord();
            StudentList = new Students();
            Support = new TechSupport();
            TeacherList = new Teachers();

            EnterLabel = new Label
            {
                Location = new Point(5, 5),
                Size = new Size(ClientSize.Width - 10, 15),
                Text = "Введите ФИО",
            };
            NameBox = new TextBox
            {
                Location = new Point(5, EnterLabel.Bottom),
                Size = EnterLabel.Size
            };
            ChooseBox = new Panel
            {
                Location = new Point(0, NameBox.Bottom),
                Size = new Size(ClientSize.Width, 80)
            };
            Student = new RadioButton
            {
                Location = new Point(5, 5),
                Size = new Size(ChooseBox.Width, 25),
                Text = "Войти как студент",
                Checked = true,
                Enabled = false
            };
            Teacher = new RadioButton
            {
                Location = new Point(5, Student.Bottom),
                Size = new Size(ChooseBox.Width, 25),
                Text = "Войти как преподаватель",
                Enabled = false
            };
            TechSupport = new RadioButton
            {
                Location = new Point(5, Teacher.Bottom),
                Size = new Size(ChooseBox.Width, 25),
                Text = "Войти как техподдержка",
                Enabled = false
            };
            Login = new Button
            {
                Location = new Point(10, ChooseBox.Bottom + 5),
                Size = new Size(ClientSize.Width / 2, 25),
                Text = "Войти"
            };

            Controls.Add(EnterLabel);
            Controls.Add(NameBox);
            Controls.Add(ChooseBox);
            ChooseBox.Controls.Add(Student);
            ChooseBox.Controls.Add(Teacher);
            ChooseBox.Controls.Add(TechSupport);
            Controls.Add(Login);
            

            NameBox.TextChanged += new EventHandler(NameBox_TextChanged);
            Login.Click += new EventHandler(Login_Click);
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            if (NameBox.Text != String.Empty)
            {
                Teacher.Enabled = true;
                Student.Enabled = true;
                TechSupport.Enabled = true;
            }
            else
            {
                Teacher.Enabled = false;
                Student.Enabled = false;
                TechSupport.Enabled = false;
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (Student.Checked)
            {
                if (!StudentList.Recorded(NameBox.Text))
                {
                    StudentList.AddStudent(NameBox.Text);
                }
                Form StudentsWindow = new StudentsWindow(Courses, NameBox.Text);
                NameBox.Clear();
                StudentsWindow.Show();
            }
            else if (Teacher.Checked)
            {
                if (!TeacherList.Recorded(NameBox.Text))
                {
                    TeacherList.AddTeacher(NameBox.Text);
                }
                Form TeachersWindow = new TeacherWindow(Courses);
                NameBox.Clear();
                TeachersWindow.Show();
            }
            else if (TechSupport.Checked)
            {
                if (!Support.Recorded(NameBox.Text))
                {
                    Support.AddSupport(NameBox.Text);
                }
                Form TechSupport = new TechSupportWindow(Courses);
                NameBox.Clear();
                TechSupport.Show();
            }
        }
    }
}
