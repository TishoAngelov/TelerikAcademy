using System;
using System.Windows;

namespace ESchoolDiary.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private StudentWindow studentWindow;

        public MainWindow()
        {
            InitializeComponent();

            // Fill ESchoolDiaryData.cs with data.
            ESchoolDiary.DataEngine.LoadDatabase();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (ESchoolDiary.Validation.IsEmpty(txtBoxID.Text) || ESchoolDiary.Validation.IsEmpty(txtBoxPassword.Password))
            {
                MessageBox.Show("Invalid username or password! Fields cannot be empty.");
            }
            else
            {
                ESchoolDiary.Student student = ESchoolDiary.DataEngine.GetStudent(txtBoxID.Text);    
       
                if (student != null && student.Password == txtBoxPassword.Password)
                {
                    studentWindow = new StudentWindow();

                    HideButtons();
                    studentWindow.LoadStudent(student);               
                    studentWindow.Show();
                    studentWindow.Visibility = Visibility.Visible;
                    ClearText();
                }
                else if (ESchoolDiary.Headmaster.Instance.Pin.ToString() == txtBoxID.Text && ESchoolDiary.Headmaster.Instance.Password == txtBoxPassword.Password)
                {
                    RegistrationChoice regChoiceWindow = new RegistrationChoice();

                    regChoiceWindow.Show();
                    regChoiceWindow.Visibility = Visibility.Visible;

                    ClearText();
                }
                else if (txtBoxPassword.Password.Length == 4)
                {
                    Teacher teacher = DataEngine.GetTeacher(txtBoxID.Text);

                    studentWindow = new StudentWindow();

                    studentWindow.btnChangePwd.Visibility = Visibility.Hidden;
                    studentWindow.btnDelete.Visibility = Visibility.Hidden;
                    studentWindow.Show();
                    studentWindow.Visibility = Visibility.Visible;
                    studentWindow.btnAddNote.Visibility = Visibility.Hidden;
                    studentWindow.btnAddMark.Visibility = Visibility.Hidden;
                    studentWindow.lblStudentName.Content = String.Format("{0} {1}, Teacher", teacher.FirstName, teacher.LastName);

                    ClearText();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }

        private void btnForgotPsw_Click(object sender, RoutedEventArgs e)
        {
            ESchoolDiary.Views.ForgotPassword forgotPwd = new ESchoolDiary.Views.ForgotPassword();
            forgotPwd.Show();
            forgotPwd.Visibility = System.Windows.Visibility.Visible;
        }

        private void ClearText()
        {
            txtBoxID.Text = "";
            txtBoxPassword.Password = "";
        }

        // Hides buttons, who the student shouldnt not see.
        private void HideButtons()
        {
            studentWindow.btnSaveAllChanges.Visibility = System.Windows.Visibility.Hidden;
            studentWindow.btnDelete.Visibility = System.Windows.Visibility.Hidden;
            studentWindow.btnAddMark.Visibility = System.Windows.Visibility.Hidden;
            studentWindow.btnAddNote.Visibility = System.Windows.Visibility.Hidden;
            studentWindow.btnSearch.Visibility = System.Windows.Visibility.Hidden;
            studentWindow.txtBoxSearch.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}