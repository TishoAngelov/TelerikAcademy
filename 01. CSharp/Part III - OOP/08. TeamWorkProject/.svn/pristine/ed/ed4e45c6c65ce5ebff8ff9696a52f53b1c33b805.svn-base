using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ESchoolDiary.Views
{
    /// <summary>
    /// Interaction logic for AddMark.xaml
    /// </summary>
    public partial class AddMark : Window
    {
        private Student student;
        private StudentWindow studentWindow;

        public AddMark(Student student, StudentWindow studentWindow)
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            this.student = student;
            this.studentWindow = studentWindow;
        }

        private void btnChooseSubject_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void btnMarkType_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            SubjectName subject = GetSubjectName();
            TypeOfMarks markType = GetMarkType();
            
            Mark newMark = new Mark(decimal.Parse(txtMarkValue.Text), markType, student, new Subject(subject));

            // Validate the mark. If the mark is incorrect, throw exception.
            try
            {
                Validation.ValidateMark(newMark);

                ESchoolDiaryData.Marks.Add(newMark);
                studentWindow.lblSubjectContent.Content += lblSubject.Content.ToString();
                studentWindow.lblMarksTypeContent.Content += lblMarkType.Content.ToString();
                studentWindow.lblMarksValueContent.Content += string.Format("{0:0.00}", decimal.Parse(txtMarkValue.Text));

                MessageBox.Show("Mark added.");

                this.Close();
            }
            catch (MarkException markEx)
            {
                MessageBox.Show(markEx.Message);
            }
            finally
            {
                txtMarkValue.Clear();
            }        
        }

        private SubjectName GetSubjectName()
        {
            if (lblSubject.Content.ToString() == "English")
            {
                return SubjectName.English;
            }

            if (lblSubject.Content.ToString() == "IT")
            {
                return SubjectName.IT;
            }

            if (lblSubject.Content.ToString() == "Physics")
            {
                return SubjectName.Physics;
            }

            if (lblSubject.Content.ToString() == "Geography")
            {
                return SubjectName.Geography;
            }

            if (lblSubject.Content.ToString() == "Biology")
            {
                return SubjectName.Biology;
            }

            if (lblSubject.Content.ToString() == "Math")
            {
                return SubjectName.Math;
            }

            return SubjectName.History;
        }

        private TypeOfMarks GetMarkType()
        {
            if (lblMarkType.Content == "Term")
            {
                return TypeOfMarks.Term;
            }
            else if (lblMarkType.Content == "Annual")
            {
                return TypeOfMarks.Annual;
            }

            return TypeOfMarks.Current;
        }

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
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

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            lblMarkType.Content = "Current";
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            lblMarkType.Content = "Term";
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            lblMarkType.Content = "Annual";
        }
    }
}