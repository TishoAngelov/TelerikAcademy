using System;
using System.Windows;

namespace ESchoolDiary.Views
{
    /// <summary>
    /// Interaction logic for RegistrationChoice.xaml
    /// </summary>
    public partial class RegistrationChoice : Window
    {
        public RegistrationChoice()
        {
            InitializeComponent();
        }

        private void txtBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxSearch.Text = "";
        }

        private void btnNewStudent_Click(object sender, RoutedEventArgs e)
        {
            ESchoolDiary.Views.RegistrationalFormStudent registrationalFormStudent = new ESchoolDiary.Views.RegistrationalFormStudent();

            registrationalFormStudent.Show();
            registrationalFormStudent.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnNewTeacher_Click(object sender, RoutedEventArgs e)
        {
            ESchoolDiary.Views.RegistrationalFormTeacher registrationalFormTeacher = new ESchoolDiary.Views.RegistrationalFormTeacher();

            registrationalFormTeacher.Show();
            registrationalFormTeacher.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            foreach (Student student in ESchoolDiaryData.Students)
            {
                if (txtBoxSearch.Text == student.Pin.ToString())
                {
                    StudentWindow studentWindow = new StudentWindow();
                    studentWindow.LoadStudent(student);
                    studentWindow.Show();
                    studentWindow.Visibility = Visibility.Visible;
                    studentWindow.btnChangePwd.Visibility = System.Windows.Visibility.Hidden;
                    studentWindow.btnLogout.Content = "Back";
                    txtBoxSearch.Text = "";

                    break;
                }
                else
                {
                    MessageBox.Show("Nobody found with such credentials.");
                }
            }
        }

        private void btnNewClass_Click(object sender, RoutedEventArgs e)
        {
            ESchoolDiary.Views.AddNewClass addClassForm = new ESchoolDiary.Views.AddNewClass();

            addClassForm.Show();
            addClassForm.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnSaveAllChanges_Click(object sender, RoutedEventArgs e)
        {
            DataEngine.SaveDatabase();

            MessageBox.Show("Changes have been saved!");
        }
    }
}