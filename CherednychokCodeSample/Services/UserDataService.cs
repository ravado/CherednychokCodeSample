using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CommonLibrary.Interfaces;
using DataModelsLibrary;
using ResourcesLibrary;
using System.Threading;
using CherednychokCodeSample;
using System.Data.Objects;

namespace CommonLibrary.Services
{
    /// <summary>
    /// Service for User
    /// </summary>
    /// <author>Evgeny Drapoguz & Cherednychok Ivan</author>
    /// <date>24 April 2013</date>
    public class UserDataService : BaseDataService, IDataService<UserDataModel>
    {
        #region Private Methods

        private void GetEntities(User targetData, UserDataModel modelData)
        {
            if (targetData != null)
            {
                targetData.UserName = modelData.Username;
                targetData.Password = modelData.Password;
                targetData.Email = modelData.Email;
                targetData.FirstName = modelData.FirstName;
                targetData.MiddleName = modelData.MiddleName;
                targetData.LastName = modelData.LastName;
                targetData.CanceledMark = modelData.CanceledMark;
            }
        }

        private User GetEntities(UserDataModel modelData)
        {
            User objectResult = new User();
            GetEntities(objectResult, modelData);
            return objectResult;
        }


        #endregion

        #region Implementation IBaseService
        public IEnumerable<UserDataModel> GetData(Expression<Func<UserDataModel, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate", Errors.NotSelectedPredicateNull);

            using (var context = GetContext())
            {

                List<UserDataModel> users =
                    context.Users.Select(u => new UserDataModel
                    {
                        ID = u.ID,
                        Username = u.UserName,
                        Email = u.Email,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        MiddleName = u.MiddleName,
                        Password = u.Password,
                        Group = (from g in context.Groups
                                 where g.ID == u.GroupID
                                 select new GroupDataModel
                                 {
                                     ID = g.ID,
                                     Name = g.Name,
                                     CanceledMark = g.CanceledMark
                                 }).FirstOrDefault<GroupDataModel>()
                        // Roles = (from r in u.Roles select new RoleDataModel { ID = r.ID }).ToList<RoleDataModel>() // won`t work
                    }).Where(predicate).ToList<UserDataModel>();




                // attachment of roles to each selected user
                foreach (var user in users)
                {
                    user.Roles = (from u in context.Users
                                  where u.ID == user.ID
                                  from r in u.Roles
                                  select new RoleDataModel
                                  {
                                      ID = r.ID,
                                      Name = r.Name,
                                      Description = r.Description,
                                      Role = (DataModelsLibrary.UserRole)r.Role1,
                                      CanceledMark = r.CanceledMark
                                  }).ToList<RoleDataModel>();
                }

                return users;
            }
        }

        public bool Add(UserDataModel record)
        {
            bool result = false;
            if (record == null)
                throw new ArgumentNullException("record", Errors.NotAddedDataModelNull);

            using (var context = GetContext())
            {
                User user = GetEntities(record);
                user.GroupID = (record.Group != null) ? record.Group.ID : (int?)null; //??? S.M.                

                // all id of user roles
                List<int> idRoles = (from r in record.Roles
                                     select r.ID).ToList<int>();

                List<Role> rolesOfNewUser = context.Roles.Where(item => idRoles.Contains(item.ID)).ToList<Role>();

                // add record to many-to-many relationship table
                if (rolesOfNewUser != null)
                {
                    foreach (var role in rolesOfNewUser)
                    {
                        user.Roles.Add(role);
                    }
                }
                context.AddToUsers(user);

                result = context.SaveChanges() > 0;
                record.ID = user.ID;
            }
            return result;
        }

        public bool Edit(UserDataModel recordOld, UserDataModel recordNew)
        {
            bool result = false;
            if (recordOld == null || recordNew == null)
                throw new ArgumentNullException("record", Errors.NotEditedObjectNull);

            using (var context = GetContext())
            {
                User editedUser = context.Users.Where(u => u.ID == recordNew.ID).FirstOrDefault();

                if (editedUser != null)
                {
                    GetEntities(editedUser, recordNew);
                    try
                    {
                        result = context.SaveChanges()>0;
                    }
                    catch (Exception)
                    {
                        context.Refresh(RefreshMode.ClientWins, editedUser);
                        result = context.SaveChanges() > 0;
                    }
                }
            }
            return result;
        }

        public bool Remove(UserDataModel record)
        {
            bool result = false;
            if (record == null)
                throw new ArgumentNullException("record", Errors.NotRemovedDataModelNull);

            using (var context = GetContext())
            {
                User userToDel = context.Users.Where(u => u.ID == record.ID).FirstOrDefault();

                if (userToDel != null)
                {
                    // get roles of user for attaching and delete relations
                    var rolesToAttach = context.Roles.AsEnumerable().Where(r => r.Users.Contains(userToDel)).ToList();
                    userToDel.Roles.Attach(rolesToAttach);

                    context.Users.DeleteObject(userToDel);
                    result = context.SaveChanges() > 0;
                }
            }
            return result;
        }
        #endregion

        #region Methods
        public UserDataModel GetUser(string username)
        {
            UserDataModel user = this.GetData(u => u.Username == username).FirstOrDefault<UserDataModel>();
            return user;
        }
        #endregion
    }
}
