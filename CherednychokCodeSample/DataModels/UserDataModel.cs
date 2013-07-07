using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourcesLibrary;

namespace DataModelsLibrary
{
    /// <summary>
    /// Data model for user
    /// </summary>
    /// <autor>Cherednychok Ivan</autor>
    /// <date>18 April 2013</date>
    [Serializable]
    public class UserDataModel :  IEquatable<UserDataModel>
    {
        #region Fields
        private int _id;
        private string _username;
        private string _email;        
        private string _password;
        private List<RoleDataModel> _roles;
        private GroupDataModel _group;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private int _canceledMark;
        #endregion

        #region Constructors
        public UserDataModel()
        {
            _id = -1;
            _username = String.Empty;
            _email = String.Empty;
            _password = String.Empty;
            _roles = new List<RoleDataModel>();
            _group = new GroupDataModel();
            _firstName = String.Empty;
            _lastName = String.Empty;
            _middleName = String.Empty;
            _canceledMark = 0;
        }

        public UserDataModel(
            int id,
            string username,
            string email,
            string password, 
            List<RoleDataModel> roles = null,
            GroupDataModel group = null,
            string firstName = "",
            string lastName = "",
            string middleName = "",
            int canceledMark = 0)
        {
            _id = id;
            _username = username;
            _email = email;
            _password = password;

            if (roles == null) roles = new List<RoleDataModel>();

            _roles = roles;
            _group = group;
            _firstName = firstName;
            _lastName = lastName;
            _middleName = middleName;

            _canceledMark = canceledMark;
        }
        #endregion

        #region Methods
        public bool HasRole(UserRole role)
        {
            var roleToFind = from r in _roles
                             where r.Role == role
                             select r;
            RoleDataModel findedRole = roleToFind.FirstOrDefault();

            if (findedRole != null)
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            string strRoles = "";
            foreach (RoleDataModel role in _roles)
	        {
		        strRoles += " " + role.Name;
	        }
 	         return String.Format(Messages.User,_id,_username,FullName,strRoles);
        }

        #region IEquatable implementation
        public bool Equals(UserDataModel other)
        {
            if (other == null)
                return false;

            return this.ID.Equals(other.ID)
                && this.Username.Equals(other.Username)
                && this.Email.Equals(other.Email)
                && this.Roles.Equals(other.Roles)
                && this.Group.Equals(other.Group)
                && this.FullName.Equals(other.FullName);            
        }
        #endregion

        public override bool Equals(object obj)
        {
            return Equals(obj as UserDataModel);
        }

        public override int GetHashCode()
        {
            return string.Format("{0}{1}{2}{3}{4}{5}", ID, Username, Roles, Email, Group, FullName).GetHashCode();
        }

        public static bool operator ==(UserDataModel operandA, UserDataModel operandB)
        {
            return Equals(operandA, operandB);
        }

        public static bool operator !=(UserDataModel operandA, UserDataModel operandB)
        {
            return !Equals(operandA, operandB);
        }
        #endregion

        #region Properties
        public int ID
        {
            get { return _id; }
            set {_id = value;}
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password;}
            set {_password = value;}
        }
        public List<RoleDataModel> Roles
        {
            get {return _roles;}
            set { _roles = value; }
        }
        public GroupDataModel Group
        {
            get { return _group; }
            set { _group = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }
        public int CanceledMark
        {
            get { return _canceledMark; }
            set { _canceledMark = value; }
        }
        public string FullName
        {
            get
            {
                return String.Format("{0} {1} {2}", _lastName, _firstName, _middleName);
            }            
        }
        #endregion
    }
}
