using System;
using System.Windows;

namespace ESchoolDiary.Views
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnForgotPsw_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnForgotPwd_Click(object sender, RoutedEventArgs e)
        {
            ESchoolDiary.Student student = ESchoolDiary.DataEngine.GetStudent(txtBoxID.Text);

            if (student != null)
            {
                string newPassword = GeneratePassword();
                string subject = "New password for ESchoolDiary";
                string from = "eschooldiary@gmail.com";
                string body = String.Format("Your new password for ESchoolDiary is: {0}", newPassword);
              
                MailUtil mailUtil = new MailUtil();

                mailUtil.SendMail(student.EMail, subject, from, body);
                student.Password = newPassword;

                MessageBox.Show("Your new password has been sent to your e-mail.");

                this.Close();

                // Send mail to the parent.
                mailUtil.SendMail(student.ParrentEmail, subject, from, body);
            }
            else
            {
                MessageBox.Show("Invalid username.");
            }
        }

        private string GeneratePassword()
        {
            Random rand = new Random(DateTime.Now.Millisecond);

            string firstPart = rand.Next(10000, 99999).ToString();
            string secondPart = rand.Next(10000, 99999).ToString();
            return firstPart + secondPart;
        }
    }
}