using System;
using System.Windows;

namespace ESchoolDiary.Views
{
    /// <summary>
    /// Interaction logic for AddNewClass.xaml
    /// </summary>
    public partial class AddNewClass : Window
    {
        public AddNewClass()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int schClass = int.Parse(txtBoxClass.Text);
            char schSubClass = char.Parse(txtBoxSubClass.Text);

            SchoolClass newClass = new SchoolClass(schClass, schSubClass);

            // Add the new class in the "DB"
            ESchoolDiaryData.SchoolClasses.Add(newClass);

            txtBoxClass.Clear();
            txtBoxSubClass.Clear();

            MessageBox.Show("New class has been added!");
            Close();
        }
    }
}