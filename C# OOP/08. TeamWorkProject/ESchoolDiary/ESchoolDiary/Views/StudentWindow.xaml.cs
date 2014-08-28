using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ESchoolDiary.Views
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        public StudentWindow()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //ClearText();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //mainWindow.Visibility = System.Windows.Visibility.Visible;
        }

        public void LoadStudent(ESchoolDiary.Student student)
        {
            txtFirstName.Text = student.FirstName;
            txtSurname.Text = student.MiddleName;
            txtLastName.Text = student.LastName;
            txtID.Text = student.Pin.ToString();
            txtPhone.Text = student.Phone;
            txtEmail.Text = student.EMail;
            txtAddress.Text = student.Address;
            lblStudentName.Content = String.Format("{0} {1}, {2}", student.FirstName, student.LastName, student.GetType().Name);

            if (student.Sex == ESchoolDiary.Sex.Male)
            {
                Photo.Source = new BitmapImage(new Uri("../Images/male_icon.jpg", UriKind.Relative));
            }
            else
            {
                Photo.Source = new BitmapImage(new Uri("../Images/female_icon.jpg", UriKind.Relative));
            }

            if (student.GetNotes() != null)
            {
                List<Note> notes = student.GetNotes();
                foreach (Note note in notes)
                {
                    txtNotes.Text += note.ToString();
                }
            }
            

            List<Mark> marks = student.GetMarks();

            foreach (Mark mark in marks)
            {
                lblSubjectContent.Content += mark.SubjectName + "\n";
                lblMarksValueContent.Content += string.Format("{0:0.00}\n", mark.MarkValue);
                lblMarksTypeContent.Content += mark.MarkType + "\n";
            }
        }

        private void btnChangePwd_Click(object sender, RoutedEventArgs e)
        {
            ESchoolDiary.Views.ChangePassword changePwd = new ESchoolDiary.Views.ChangePassword();

            changePwd.Show();
            changePwd.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (Student student in ESchoolDiaryData.Students)
            {
                if (student.Pin.ToString() == txtID.Text)
                {
                    Headmaster.Instance.RemoveStudent(student);

                    break;
                }
            }

            MessageBox.Show(String.Format("{0} {1} <ID: {2}> has been deleted.", txtFirstName.Text, txtLastName.Text, txtID.Text));

            this.Close();
        }

        public void SetControlsVisibility(bool visible)
        {
            System.Windows.Visibility status;

            if (visible)
            {
                status = System.Windows.Visibility.Visible;
            }
            else
            {
                status = System.Windows.Visibility.Hidden;
            }

            mainBorder.Visibility = status;
            Photo.Visibility = status;
            lblFirstName.Visibility = status;
            lblSurname.Visibility = status;
            lblLastName.Visibility = status;
            lblID.Visibility = status;
            txtFirstName.Visibility = status;
            txtSurname.Visibility = status;
            txtLastName.Visibility = status;
            txtID.Visibility = status;
            lblPhone.Visibility = status;
            lblAddress.Visibility = status;
            lblEmail.Visibility = status;
            txtPhone.Visibility = status;
            txtAddress.Visibility = status;
            txtEmail.Visibility = status;
            txtNotes.Visibility = status;
            notesBorder.Visibility = status;
            txtNotes.Visibility = status;
            marksBorder.Visibility = status;
            lblMarks.Visibility = status;
            lblSubject.Visibility = status;
            lblMarksValue.Visibility = status;
            lblMarksType.Visibility = status;
            lblSubjectContent.Visibility = status;
            lblMarksValueContent.Visibility = status;
            lblMarksType.Visibility = status;
        }

        public void ClearText()
        {
            txtFirstName.Text = "";
            txtSurname.Text = "";
            txtLastName.Text = "";
            txtID.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtNotes.Text = "";
            txtNotes.Text = "";
            lblSubjectContent.Content = "";
            lblMarksValueContent.Content = "";
            lblMarksType.Content = "";
        }

        private void txtBoxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtBoxSearch.Text = "";
        }

        private void btnAddNote_Click(object sender, RoutedEventArgs e)
        {
            AddNote addNote = new AddNote(DataEngine.GetStudent(txtID.Text), this);

            addNote.Show();
            addNote.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnAddMark_Click_1(object sender, RoutedEventArgs e)
        {
            AddMark addMark = new AddMark(DataEngine.GetStudent(txtID.Text), this);

            addMark.Show();
            addMark.Visibility = System.Windows.Visibility.Visible;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            bool isFound = false;

            foreach (Student student in ESchoolDiaryData.Students)
            {
                if (txtBoxSearch.Text == student.Pin.ToString())
                {
                    this.LoadStudent(student);
                    this.btnAddMark.Visibility = System.Windows.Visibility.Visible;
                    this.btnAddNote.Visibility = System.Windows.Visibility.Visible;

                    txtBoxSearch.Text = "";

                    isFound = true;

                    break;
                }
            }

            if (!isFound)
            {
                MessageBox.Show("Nobody found with such credentials.");
            }
        }

        private void btnSaveAllChanges_Click(object sender, RoutedEventArgs e)
        {
            DataEngine.SaveDatabase();

            MessageBox.Show("Changes have been saved!");
        }
    }
}