using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourcesLibrary;

namespace DataModelsLibrary
{
    /// <summary>
    /// Data model for user roles
    /// </summary>
    /// <autor>Cherednychok Ivan</autor>
    /// <date>15 April 2013</date>
    [Serializable]
    public class RoleDataModel:IEquatable<RoleDataModel>
    {
        #region Fields
        private int _id;
        private UserRole _role;
        private string _name;
        private string _description;
        private int _canceledMark;
        #endregion

        #region Constructors
        public RoleDataModel()
        {
            _id = -1;
            _name = "";
            _description = "";
            _role = UserRole.None;
        }
        public RoleDataModel(int id, string name, UserRole role, string description = "")
        {
            _id = id;
            _name = name;
            _role = role;
            _description = description;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return String.Format(Messages.Role, _id, _name, _description);
        }

        #region IEquatable implementation
        public bool Equals(RoleDataModel other)
        {
            if (other == null)
                return false;

            return this.ID.Equals(other.ID) && this.Name.Equals(other.Name) && this.Role.Equals(other.Role);
        }
        #endregion

        public override bool Equals(object obj)
        {
            return Equals(obj as RoleDataModel);
        }

        public override int GetHashCode()
        {
            return string.Format("{0}{1}{2}", ID, Name, this.Role).GetHashCode();
        }

        public static bool operator ==(RoleDataModel operandA, RoleDataModel operandB)
        {
            return Equals(operandA, operandB);
        }

        public static bool operator !=(RoleDataModel operandA, RoleDataModel operandB)
        {
            return !Equals(operandA, operandB);
        }
        #endregion

        #region Properties
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public UserRole Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        public string Description {
            get { return _description; }
            set { _description = value; }
        }
        public int CanceledMark
        {
            get { return _canceledMark; }
            set { _canceledMark = value; }
        }
        #endregion
    }
}
