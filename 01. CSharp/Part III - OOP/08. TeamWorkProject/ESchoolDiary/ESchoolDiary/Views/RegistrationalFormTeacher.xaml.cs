using System;
using System.Threading;
using System.Windows;

namespace ESchoolDiary.Views
{
    /// <summary>
    /// Interaction logic for RegistrationalFormTeacher.xaml
    /// </summary>
    public partial class RegistrationalFormTeacher : Window
    {
        public RegistrationalFormTeacher()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)        //Radio Button Yes
        {
            this.lblSchoolClass.Visibility = System.Windows.Visibility.Visible;
            this.txtBoxSchoolClass.Visibility = System.Windows.Visibility.Visible;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)        //Radio Button No
        {
            this.lblSchoolClass.Visibility = System.Windows.Visibility.Hidden;
            this.txtBoxSchoolClass.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)               // Button Logout
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}