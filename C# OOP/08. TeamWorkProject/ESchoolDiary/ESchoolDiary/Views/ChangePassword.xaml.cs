using System;
using System.Windows;

namespace ESchoolDiary.Views
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ESchoolDiary.Student student = ESchoolDiary.DataEngine.GetStudent(txtBoxCurrentPwd.Password);

            if (student != null)
            {
                if (ESchoolDiary.Validation.IsEmpty(txtBoxCurrentPwd.Password) || ESchoolDiary.Validation.IsEmpty(txtBoxNewPwd.Password) || ESchoolDiary.Validation.IsEmpty(txtBoxRepeatPwd.Password))
                {
                    MessageBox.Show("Fields cannot be empty.");
                }
                else if (student.Password != txtBoxCurrentPwd.Password)
                {
                    MessageBox.Show("Invalid current password.");
                }
                else if (txtBoxNewPwd.Password == txtBoxRepeatPwd.Password)
                {
                    student.Password = txtBoxNewPwd.Password;
                    MessageBox.Show("Password changed.");

                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid password.");
            }
        }
    }
}