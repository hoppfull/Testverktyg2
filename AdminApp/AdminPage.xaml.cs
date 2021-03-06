﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Testverktyg.Model;
using Testverktyg.Repository;
using AdminApp.Controllers;

namespace AdminApp {
    public partial class AdminPage : Window {
        public AdminAccount LoggedInAccount { get; }
        public AdminPage(AdminAccount loggedInAccount) {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoggedInAccount = loggedInAccount;
            UpdateSubjectListView();
            UpdateTestDefinitionListView();
        }

        private void LogoutEvent(object sender, RoutedEventArgs e) {
            ViewController.Logout(this);
        }

        #region Subject management tools:
        private void lvw_Subjects_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            skp_EditSubjectTools.IsEnabled = true;
        }

        private void btn_ChangeSubjectName_Click(object sender, RoutedEventArgs e) {
            ToggleChangeSubjectTools(true);
            tbx_ChangeSubjectName.Text = ((Subject)lvw_Subjects.SelectedItem).Name;
        }

        private void btn_SaveChangeSubjectName_Click(object sender, RoutedEventArgs e) {
            if (Controller.EditSubject(lvw_Subjects.SelectedItem as Subject, tbx_ChangeSubjectName.Text)) {
                ToggleChangeSubjectTools(false);
                UpdateSubjectListView();
            } else
                MessageBox.Show("Kunde inte ändra namn på ämne!\nKanske är namnet ogiltigt.");
        }

        private void btn_AbortChangeSubjectName_Click(object sender, RoutedEventArgs e) {
            ToggleChangeSubjectTools(false);
        }

        private void ToggleChangeSubjectTools(bool enable) {
            btn_ChangeSubjectName.Visibility = enable ? Visibility.Collapsed : Visibility.Visible;
            skp_ChangeSubjectName.Visibility = enable ? Visibility.Visible : Visibility.Collapsed;
            tbx_ChangeSubjectName.Text = "";
        }

        private void btn_RemoveSubject_Click(object sender, RoutedEventArgs e) {
            if (Controller.DeleteSubject(lvw_Subjects.SelectedItem as Subject))
                UpdateSubjectListView();
            else
                MessageBox.Show("Kan inte ta bort detta ämne!\nKanske refereras det av ett eller fler prov.");
        }

        private void btn_AddSubject_Click(object sender, RoutedEventArgs e) {
            ToggleSaveSubjectTools(true);
        }

        private void btn_SaveSubject_Click(object sender, RoutedEventArgs e) {
            if (Controller.CreateSubject(tbx_AddSubjectName.Text) != null)
                UpdateSubjectListView();
            ToggleSaveSubjectTools(false);
        }

        private void btn_AbortSaveSubject_Click(object sender, RoutedEventArgs e) {
            ToggleSaveSubjectTools(false);
        }

        private void ToggleSaveSubjectTools(bool enable) {
            btn_AddSubject.Visibility = enable ? Visibility.Collapsed : Visibility.Visible;
            skp_SaveSubject.Visibility = enable ? Visibility.Visible : Visibility.Collapsed;
            tbx_AddSubjectName.Text = "";
        }

        private void UpdateSubjectListView() {
            lvw_Subjects.ItemsSource = Repository<Subject>.Instance.GetAll();
            skp_EditSubjectTools.IsEnabled = false;
            UpdateTestDefinitionListView();
        }
        #endregion

        #region User management tools:
        private void cbx_SelectUserType_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateUserListView(GetSelectedUserType());
            skp_UserTools.Visibility = Visibility.Visible;
        }

        private void lvw_Users_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            skp_EditUser.IsEnabled = true;
        }

        private void btn_AddUser_Click(object sender, RoutedEventArgs e) {
            ToggleSaveUserTools(true);
        }

        private void btn_SaveUser_Click(object sender, RoutedEventArgs e) {
            Controller.CreateUser(tbx_AddUserName.Text, tbx_AddUserEmail.Text, GetSelectedUserType().Value);
            UpdateUserListView(GetSelectedUserType());
            ToggleSaveUserTools(false);
        }

        private void btn_AbortSaveUser_Click(object sender, RoutedEventArgs e) {
            ToggleSaveUserTools(false);
        }

        private void ToggleSaveUserTools(bool enable) {
            btn_AddUser.Visibility = enable ? Visibility.Collapsed : Visibility.Visible;
            skp_SaveUser.Visibility = enable ? Visibility.Visible : Visibility.Collapsed;
            tbx_AddUserName.Text = "";
            tbx_AddUserEmail.Text = "";
        }

        private void btn_RemoveUser_Click(object sender, RoutedEventArgs e) {
            if (lvw_Users.SelectedItem != null) {
                ((AbstractUser)lvw_Users.SelectedItem).IsNotRemoved = false;
                if (Controller.DeleteUser(LoggedInAccount, lvw_Users.SelectedItem as AdminAccount)) {
                } else if (Controller.DeleteUser(LoggedInAccount, lvw_Users.SelectedItem as TeacherAccount)) {
                } else if (Controller.DeleteUser(LoggedInAccount, lvw_Users.SelectedItem as StudentAccount)) {
                } else
                    MessageBox.Show("Kan inte ta bort denna användare!\nKanske försöker du ta bort ditt eget konto.");
                UpdateUserListView(GetSelectedUserType());
            }
        }

        private void UpdateUserListView(UserType? userType) {
            Func<AbstractUser, bool> f = user => user.IsNotRemoved;
            lvw_Users.ItemsSource =
                userType == UserType.Admin ?
                    Repository<AdminAccount>.Instance.GetAll().Where(f) :
                userType == UserType.Teacher ?
                    Repository<TeacherAccount>.Instance.GetAll().Where(f) :
                userType == UserType.Student ?
                    Repository<StudentAccount>.Instance.GetAll().Where(f) :
                    null;
            skp_EditUser.IsEnabled = false;
        }

        private UserType? GetSelectedUserType() {
            if (cbx_SelectUserType.SelectedIndex == -1)
                return null;
            else
                return (UserType)((ComboBoxItem)cbx_SelectUserType.SelectedItem).Tag;
        }

        private void btn_ResetUserPassword_Click(object sender, RoutedEventArgs e) {
            if (lvw_Users.SelectedItem != null) {
                Controller.ResetPassword(lvw_Users.SelectedItem as AbstractUser);
                UpdateUserListView(GetSelectedUserType());
            }
        }
        #endregion

        #region Test management tools:

        private void lvw_TestDefinitions_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btn_InspectTestDefinition.IsEnabled = true;
            ;
        }
        
        private void btn_InspectTestDefinition_Click(object sender, RoutedEventArgs e) {
            var selectedItem = lvw_TestDefinitions.SelectedItem as Tuple<TestDefinition, TeacherAccount, Subject>;
            if (selectedItem != null && selectedItem.Item1 != null) {
                InspectTestDefinition w = new InspectTestDefinition(this, selectedItem.Item1);
                w.Show();
            }
        }

        public void UpdateTestDefinitionListView() {
            lvw_TestDefinitions.ItemsSource = Repository<TestDefinition>.Instance.GetAll()
                .Where(td => td.TestDefinitionState == TestDefinitionState.Sent || td.TestDefinitionState == TestDefinitionState.Validated)
                .Select(td => Tuple.Create(td,
                    Testverktyg.Controllers.Controller.GetTestDefinitionAuthor(td),
                    Testverktyg.Controllers.Controller.GetTestDefinitionSubject(td)));
            btn_InspectTestDefinition.IsEnabled = false;
            lvw_TestDefinitions.SelectedIndex = -1;
        }
        #endregion

        #region Statistics tools:
        private void tab_Statistics_MouseDown(object sender, RoutedEventArgs e) {
            UpdateSubjectMasterComboBox();
        }

        private void cbx_FilterSubject_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            tbx_FilterTestName.IsEnabled = true;
            tbx_FilterTestName.Text = "";
            UpdateTestsMasterListView();
        }

        private void tbx_FilterTestName_TextChanged(object sender, TextChangedEventArgs e) {
            UpdateTestsMasterListView();
        }

        private void lvw_TestStatisticsMaster_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // student, tid, betyg och poäng
            TestDefinition td = (lvw_TestStatisticsMaster.SelectedItem as Tuple<TestDefinition, TeacherAccount>)?.Item1;
            if (td != null) {
                IList<TestForm> tfs = Repository<TestForm>.Instance.GetAll()
                    .Where(tf => tf.TestDefinitionId == td.Id).ToList();
                lvw_TestStatisticsDetails.ItemsSource = Testverktyg.Controllers.Controller.GetResults(tfs);

                Tuple<double, double, double, int, int, int, int> statistics =
                    Testverktyg.Controllers.Controller.CalcStatistics(tfs);
                if (statistics != null)
                    grd_SummaryStatistics.DataContext = Tuple.Create(
                        statistics.Item1.ToString("0.##"),
                        statistics.Item2.ToString("0.##"),
                        statistics.Item3.ToString("0.##"),
                        string.Format($"{statistics.Item4}/{statistics.Item7}"),
                        string.Format($"{statistics.Item5}/{statistics.Item7}"),
                        string.Format($"{statistics.Item6}/{statistics.Item7}"));
                else
                    grd_SummaryStatistics.DataContext =
                        Tuple.Create("N/A", "N/A", "N/A", "N/A", "N/A", "N/A");
            } else {
                lvw_TestStatisticsDetails.ItemsSource = null;
                grd_SummaryStatistics.DataContext = null;
            }
        }

        private void UpdateTestsMasterListView() {
            lvw_TestStatisticsMaster.ItemsSource = cbx_FilterSubject.SelectedIndex != -1
                ? FilterTests((Subject)cbx_FilterSubject.SelectedItem, tbx_FilterTestName.Text)
                    .Select(test => Tuple.Create(test,
                    Repository<TeacherAccount>.Instance.Get(test.TeacherAccountId)))
                : null;
        }

        private void UpdateSubjectMasterComboBox() {
            cbx_FilterSubject.ItemsSource = Repository<Subject>.Instance.GetAll();
        }

        private IList<TestDefinition> FilterTests(Subject subject, string titleFilter) {
            Func<string, bool> textFilter = text => titleFilter.ToLower() == text.ToLower().Substring(0, Math.Min(titleFilter.Length, text.Length));

            return Repository<TestDefinition>.Instance.GetAll()
                .Where(test => test.SubjectId == subject.Id && (string.IsNullOrWhiteSpace(titleFilter) || textFilter(test.Title))).ToList();
        }
        #endregion

        #region Settings tools:
        private void tbx_AdminChangePassword_TextChanged(object sender, TextChangedEventArgs e) {
            btn_AcceptChangePassword.IsEnabled =
                tbx_AdminChangePassword.Text == tbx_AdminRepeatChangePassword.Text &&
                !string.IsNullOrWhiteSpace(((TextBox)sender).Text);
        }

        private void btn_AcceptChangePassword_Click(object sender, RoutedEventArgs e) {
            if(Testverktyg.Controllers.Controller.UpdatePassword(LoggedInAccount, tbx_AdminChangePassword.Text)) {
                btn_AcceptChangePassword.IsEnabled = false;
                tbx_AdminChangePassword.Text = "";
                tbx_AdminRepeatChangePassword.Text = "";
                if (GetSelectedUserType() == UserType.Admin)
                    UpdateUserListView(GetSelectedUserType());
                MessageBox.Show($"Lösenord ändrat till '{LoggedInAccount.Password}'");
            } else
                MessageBox.Show("Kunde inte ändra lösenordet!\nKanske är lösenordet inte giltigt.");
            
        }
        
        private void tbx_AdminChangeEmail_TextChanged(object sender, TextChangedEventArgs e) {
            btn_AcceptChangeEmail.IsEnabled =
                !string.IsNullOrWhiteSpace(tbx_AdminChangeEmail.Text) &&
                tbx_AdminChangeEmail.Text != LoggedInAccount.Email;
        }

        private void btn_AcceptChangeEmail_Click(object sender, RoutedEventArgs e) {
            if(Testverktyg.Controllers.Controller.UpdateEmail(LoggedInAccount, tbx_AdminChangeEmail.Text)) {
                btn_AcceptChangeEmail.IsEnabled = false;
                tbx_AdminChangeEmail.Text = "";
                if (GetSelectedUserType() == UserType.Admin)
                    UpdateUserListView(GetSelectedUserType());
            } else
                MessageBox.Show("Kunde inte ändra din email!\nKanske är mailen inte giltig.");
        }

        #endregion
    }
}
