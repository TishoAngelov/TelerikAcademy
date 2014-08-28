using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ESchoolDiary.Views
{
    /// <summary>
    /// Interaction logic for RegistrationalFormStudent.xaml
    /// </summary>
    public partial class RegistrationalFormStudent : Window
    {
        public RegistrationalFormStudent()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            // Fill the combo box for class
            foreach (var item in ESchoolDiaryData.SchoolClasses.OrderBy(i => i.SchClass))
            {
                if (!cmbBoxClass.Items.Contains(item.SchClass))
                {
                    cmbBoxClass.Items.Add(item.SchClass);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ESchoolDiary.Sex sex;

            if ((bool)rdMale.IsChecked)
            {
                sex = ESchoolDiary.Sex.Male;
            }
            else
            {
                sex = ESchoolDiary.Sex.Female;
            }
            
            Student newStudent = new Student(txtBoxFirstName.Text, txtBoxMiddleName.Text, txtBoxLastName.Text, sex, (DateTime)txtDate.SelectedDate, 
                                                long.Parse(txtBoxPin.Text), txtBoxPhone.Text, txtEmail.Text, GetAddress(), txtParentEmail.Text, 
                                                int.Parse(cmbBoxClass.SelectedItem.ToString()), char.Parse(cmbBoxSubClass.SelectedItem.ToString()));
            
            ESchoolDiaryData.Students.Add(newStudent);

            MessageBox.Show(String.Format("The student {0} {1} has been successfully added.", newStudent.FirstName, newStudent.LastName));
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private string GetAddress()
        {
            StringBuilder address = new StringBuilder();

            address.Append(txtBoxCountry.Text + ", ");
            address.Append(txtBoxCity.Text + ", ");
            address.Append(txtBoxStreet.Text);

            return address.ToString();
        }

        private void cmbBoxClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Fill the combo box for sub classes (for the chosen class).
            cmbBoxSubClass.Items.Clear();

            int selectedClass = int.Parse(cmbBoxClass.SelectedItem.ToString());

            foreach (var item in ESchoolDiaryData.SchoolClasses.OrderBy(i => i.SchSubClass))
            {
                if (selectedClass == item.SchClass)
	            {
                    cmbBoxSubClass.Items.Add(item.SchSubClass);
	            }                
            }

            cmbBoxSubClass.IsEnabled = true;
        }

        private void cmbBoxSubClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}