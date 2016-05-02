using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Testverktyg;
using Testverktyg.Model;
using Testverktyg.Context;

namespace AdminApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Console.WriteLine("hello world!");

            //using (var db = new TestverktygContext()) {
            //    db.AdminAccounts.Add(new AdminAccount("Kalle", "mail", "abs"));
            //    db.StudentAccounts.Add(new StudentAccount("a", "b", "c"));
            //    db.TeacherAccounts.Add(new TeacherAccount("x", "y", "z"));
            //    db.TeacherAccounts.Add(new TeacherAccount("u", "v", "w"));

            //    db.SaveChanges();
            //}
            MockData.Reset();
        }
    }
}
