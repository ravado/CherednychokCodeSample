using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ResourcesLibrary;

namespace DataModelsLibrary
{
    /// <summary>
    /// Data model for user group
    /// </summary>
    /// <autor>Cherednychok Ivan</autor>
    /// <date>16 April 2013</date>
    [Serializable]
    public class GroupDataModel:IEquatable<GroupDataModel>
    {
        #region Fields
        private int _id;
        private string _name;
        private int _canceledMark;
        #endregion

        #region Constructors
        public GroupDataModel()
        {
            _id = -1;
            _name = String.Empty;
            _canceledMark = 0;
        }
        public GroupDataModel(int id, string name, int canceledMark = 0)
        {
            _id = id;
            _name = name;
            _canceledMark = canceledMark;
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return String.Format(Messages.Group, _id, _name, _canceledMark.ToString());
        }

        #region IEquatable implementation
        public bool Equals(GroupDataModel other)
        {
            if (other == null)
                return false;

            return this.ID.Equals(other.ID) && this.Name.Equals(other.Name);
        }
        #endregion

        public override bool Equals(object obj)
        {
            return Equals(obj as GroupDataModel);
        }

        public override int GetHashCode()
        {
            return string.Format("{0}{1}", ID, Name).GetHashCode();
        }

        public static bool operator ==(GroupDataModel operandA, GroupDataModel operandB)
        {
            return Equals(operandA, operandB);
        }

        public static bool operator !=(GroupDataModel operandA, GroupDataModel operandB)
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
        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        public int CanceledMark {
            get { return _canceledMark; }
            set { _canceledMark = value; }
        }
        #endregion
    }
}
