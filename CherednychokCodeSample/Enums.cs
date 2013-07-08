using System;

namespace DataModelsLibrary
{
    /// <summary>
    /// Enumeration of user role
    /// </summary>
    public enum UserRole : byte
    {
        /// <summary>
        /// User has not a role yet
        /// </summary>
        None = 0,
        /// <summary>
        /// Administrator role, the most powerfull user
        /// </summary>
        Admin = 1,
        /// <summary>
        /// Student role
        /// </summary>
        Student = 2,
        /// <summary>
        /// Teacher role
        /// </summary>
        Teacher = 3,
        /// <summary>
        /// Guest role
        /// </summary>
        Guest = 4
    }
}
