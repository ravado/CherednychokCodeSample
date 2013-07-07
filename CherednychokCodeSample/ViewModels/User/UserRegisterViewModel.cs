using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModelsLibrary;
using System.ComponentModel;
using CommonLibrary;
using CommonLibrary.Services;
using ResourcesLibrary;

namespace ScientiaPotentiaEst.ViewModels.User
{
    /// <summary>
    /// ViewModel for user registration window
    /// </summary>
    /// <autor>Cherednychok Ivan</autor>
    /// <date>16 April 2013</date>
    [Serializable]
    public class UserRegisterViewModel: IDataErrorInfo
    {
        #region Fields
        private bool _firstRun; // for not aplying validation in first binding
        private string _username;
        private string _email;
        private string _password;
        private string _passwordConfirm;
        private bool _isTeacher;
        private string _name;
        private string _surname;
        private string _middleName;
        private List<string> _groups { get; set; }
        private string _selectedGroup { get; set; }
        #endregion

        public UserRegisterViewModel()
        {
            _groups = new List<string>();
            _selectedGroup = "";
            _username = "";
            _email = "";
            _password = "";
            _passwordConfirm = "";
            _name = "";
            _surname = "";
            _middleName = "";
            _isTeacher = false;
            _firstRun = true;
        }

        #region Properties
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                _firstRun = false;
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                _firstRun = false;
            }
        }
        public string Password {
            get { return _password; }
            set
            {
                _password = value;
                _firstRun = false;
            }
        }
        public string PasswordConfirm {
            get { return _passwordConfirm; }
            set
            {
                _passwordConfirm = value;
                _firstRun = false;
            }
        }
        public bool IsTeacher {
            get { return _isTeacher; }
            set
            {
                _isTeacher = value;
                _firstRun = false;
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                _firstRun = false;
            }
        }
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                _firstRun = false;
            }
        }
        public string MiddleName
        {
            get { return _middleName; }
            set
            {
                _middleName = value;
                _firstRun = false;
            }
        }
        public List<string> Groups { get; set; }
        public string SelectedGroup
        {
            get { return _selectedGroup; }
            set
            {
                _selectedGroup = value;
                _firstRun = false;
            }
        }
        #endregion

        #region IDataErrorInfo implemantation
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = "";
                switch (columnName)
                {
                    case "Username":
                        if (!_firstRun)
                        {
                            if (!Validation.ValidUsername(Username))
                            {
                                result = Messages.UserLeastFourSymbols;
                            }
                            else
                            {
                                UserDataService uService = new UserDataService();
                                UserDataModel user = uService.GetUser(Username);

                                if (user != null)
                                {
                                    result = Messages.UserAlreadyToken;
                                }
                            }
                        }
                        break;
                    case "Email": if (!_firstRun && (!Validation.ValidEmail(Email))) result = Messages.EmailIncorrect; break;
                    case "Password": 
                        if (!_firstRun && (!Validation.ValidPassword(Password)))
                            result = Messages.PasswordNotLeastSixSymbols;
                        break;
                    /*case "PasswordConfirm":
                        if (!_firstRun && (!Validation.ValidPassword(PasswordConfirm)))
                            result = "PasswordConfirm is incorrect";
                        break; */
                    case "Name": if (!_firstRun && (!Validation.ValidText(Name))) result = Messages.NameOnlyLettersToThirty; break;
                    case "Surname": if (!_firstRun && (!Validation.ValidText(Surname))) result = Messages.SurnameOnlyLettersToThirty; break;
                    case "MiddleName": if (!_firstRun && (!Validation.ValidText(MiddleName))) result = Messages.MiddleNameOnlyLettersToThirty; break;
                    case "SelectedGroup":
                        if (!_firstRun && !IsTeacher)
                        {
                            if (_selectedGroup == String.Empty)
                            {
                                return Messages.StudentNotGroup;
                            } 
                            else if (!Validation.ValidTextWithNumbers(_selectedGroup, 3))
                            {
                                return Messages.GroupNotLeastThreeSymbols;
                            }
                            
                        }                        
                        break;
                    default: break;
                };

                return result;
            }
        }
        #endregion

        //TODO: refactor this (checking is not correct)
        public bool IsValid()
        {
            bool valid = true;
            _firstRun = false;

            if (this["Username"] != String.Empty) valid = false;
            if (this["Email"] != String.Empty) valid = false;
            if (this["Password"] != String.Empty) valid = false;
            if (this["PasswordConfirm"] != String.Empty) valid = false;
            if (this["Name"] != String.Empty) valid = false;
            if (this["Surname"] != String.Empty) valid = false;
            if (this["MiddleName"] != String.Empty) valid = false;
            if (this["SelectedGroup"] != String.Empty) valid = false;

            return valid;
        }
    }
}
