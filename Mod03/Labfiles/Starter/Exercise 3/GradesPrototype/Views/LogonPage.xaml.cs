using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GradesPrototype.Data;
using GradesPrototype.Services;

namespace GradesPrototype.Views
{
    /// <summary>
    /// Interaction logic for LogonPage.xaml
    /// </summary>
    public partial class LogonPage : UserControl
    {
        public LogonPage()
        {
            InitializeComponent();
        }

        #region Event Members
        public event EventHandler LogonSuccess;

        // TODO: Exercise 3: Task 1a: Define LogonFailed event

        #endregion

        #region Logon Validation

        // TODO: Exercise 3: Task 1b: Validate the username and password against the Users collection in the MainWindow window
        public event EventHandler LoginFailed;
        private void Logon_Click(object sender, RoutedEventArgs e)
        {
            var teacher = (from Teacher t in DataSource.Teachers
                           where String.Compare(t.UserName, username.Text) == 0
                           && String.Compare(t.Password, password.Password) == 0
                           select t).FirstOrDefault();
            if (!String.IsNullOrEmpty(teacher.UserName))
            {
                SessionContext.UserID = teacher.TeacherID;
                SessionContext.UserRole = Role.Teacher;
                SessionContext.UserName = teacher.UserName;
                SessionContext.CurrentTeacher = teacher;
                LogonSuccess?.Invoke(this, null);
                return;
            }
            else 
            {
                var student = (from Student s in DataSource.Students
                               where String.Compare(s.UserName, username.Text) == 0
                               && String.Compare(s.Password, password.Password) == 0
                               select s).FirstOrDefault();
                if (!String.IsNullOrEmpty(student.UserName))
                {
                    SessionContext.UserID = teacher.TeacherID;
                    SessionContext.UserRole = Role.Teacher;
                    SessionContext.UserName = teacher.UserName;
                    SessionContext.CurrentTeacher = teacher;
                    LogonSuccess?.Invoke(this, null);
                    return;
                }

            }
        }
        #endregion
    }
}
