using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ScientiaPotentiaEst.ViewModels.User;
using CommonLibrary;
using CommonLibrary.Services;
using DataModelsLibrary;
using System.Threading;
using ResourcesLibrary;

namespace CherednychokCodeSample.Windows.User
{
    /// <summary>
    /// Interaction logic for UserRegisterWindow.xaml
    /// </summary>
    public partial class UserRegisterWindow : Window
    {
        #region ViewModel manipulations
        private UserRegisterViewModel _viewModel;
        private UserRegisterViewModel _ViewModel
        {
            get { return GetViewModel(); }
            set { _viewModel = value; }
        }
        private void InitViewModel()
        {
            _viewModel = new UserRegisterViewModel();

            GroupDataService gService = new GroupDataService();

            // get all group names from db
            _viewModel.Groups = gService.GetData(s => s.ID >= 0).ToList().Select(g => g.Name).ToList<string>();


        }
        private UserRegisterViewModel GetViewModel()
        {
            if (_viewModel == null)
            {
                InitViewModel();
            }

            return _viewModel;
        }
        #endregion

        public UserRegisterWindow()
        {
            InitializeComponent();
            txtUsername.Focus();
            DataContext = GetViewModel();
        }

        private void RegisterUser()
        {
            List<RoleDataModel> userRoles = new List<RoleDataModel>();
            RoleDataService rService = new RoleDataService();
            GroupDataModel group = null;
            RoleDataModel role;
            UserRole selectedRole;

            if (_ViewModel.IsTeacher)
                selectedRole = UserRole.Teacher;
            else
                selectedRole = UserRole.Student;

            role = rService.GetRole(selectedRole);

            if (role != null)
            {
                userRoles.Add(role);
            }
            // such role not exist in db? - create it!
            else
            {
                role = new RoleDataModel();
                role.Role = selectedRole;

                if (selectedRole == UserRole.Student)
                {
                    role.Name = "Student";

                    GroupDataService gService = new GroupDataService();
                    group = gService.GetGroup(_ViewModel.SelectedGroup);
                    if (group == null)
                    {
                        group = gService.CreateGroup(_ViewModel.SelectedGroup);
                    }
                }
                else
                {
                    role.Name = "Teacher";
                }

                rService.Add(role);
                userRoles.Add(rService.GetRole(selectedRole));
            }

            // adding group to UserDM if registering student
            if (selectedRole == UserRole.Student)
            {
                GroupDataService gService = new GroupDataService();
                group = gService.GetGroup(_ViewModel.SelectedGroup);
                if (group == null)
                {
                    group = gService.CreateGroup(_ViewModel.SelectedGroup);
                }
            }



            // create new user object for write to db
            UserDataModel newUser = new UserDataModel
            {
                Username = _ViewModel.Username,
                Email = _ViewModel.Email,
                Password = Authentication.HashPassword(_ViewModel.Password),
                FirstName = _ViewModel.Name,
                LastName = _ViewModel.Surname,
                MiddleName = _ViewModel.MiddleName,
                Group = group,
                Roles = userRoles
            };


            UserDataService uService = new UserDataService();
            uService.Add(newUser);
            MessageBox.Show(Messages.RegisterSuccessfull, Messages.CaptionRegistered);
            this.Close();
        }

        private void btnCancelRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!_ViewModel.IsValid())
                {
                    this.DataContext = null;
                    this.DataContext = _ViewModel;
                }

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUserRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_ViewModel.IsValid())
                {
                    RegisterUser();
                }
                else
                {
                    // rebind DataContext for run validation mechanism
                    this.DataContext = null;
                    this.DataContext = _ViewModel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chbIsTeacher_Checked(object sender, RoutedEventArgs e)
        {
            lblGroup.IsEnabled = false;
            cmbGroup.IsEnabled = false;
            cmbGroup.Text = cmbGroup.Text; // for revalidate property in VM
        }

        private void chbIsTeacher_Unchecked(object sender, RoutedEventArgs e)
        {
            lblGroup.IsEnabled = true;
            cmbGroup.IsEnabled = true;
            cmbGroup.Text = cmbGroup.Text; // for revalidate property VM
        }

    }
}
