using System;
using System.Windows;
using System.Windows.Controls;

namespace ESchoolDiary.Views
{
    /// <summary>
    /// Interaction logic for AddNote.xaml
    /// </summary>
    public partial class AddNote : Window
    {
        private Student student;
        private StudentWindow studentWindow;

        public AddNote(Student student, StudentWindow studentWindow)
        {
            InitializeComponent();
            this.student = student;
            this.studentWindow = studentWindow;
        }

        private void btnSujectList_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            Note note = new Note();

            note.StudentPin = student.Pin;
            note.NoteMsg = String.Format("Subject: {0}. {1} ", lblSubject.Content, txtNote.Text);

            ESchoolDiaryData.Notes.Add(note);

            MessageBox.Show("Note added.");
            studentWindow.txtNotes.Text += note;

            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            lblSubject.Content = "Math";
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            lblSubject.Content = "IT";
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            lblSubject.Content = "Geography";
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            lblSubject.Content = "Biology";
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            lblSubject.Content = "History";
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            lblSubject.Content = "Chemistry";
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {
            lblSubject.Content = "Physics";
        }
    }
}