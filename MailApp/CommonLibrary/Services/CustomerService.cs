using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLibrary.DataModels;
using System.Linq.Expressions;

namespace CommonLibrary.Services
{
    public class CustomerService : BaseService
    {
        public List<CustomerDataModel> GetCustomers()
        {
            using (MailStoredgeEntities context = base.GetContext())
            {
                List<CustomerDataModel> customers = (from c in context.Customers
                                                     select new CustomerDataModel()
                                                     {
                                                         Id = c.Id,
                                                         Email = c.Email,
                                                         CustomerName = c.CustomerName,
                                                         CompanyName = c.CompanyName,
                                                         RegistrationDate = c.RegisterDate
                                                     }).ToList<CustomerDataModel>();

                return customers;
            }
        }

        public List<CustomerDataModel> GetCustomers(Expression<Func<CustomerDataModel, bool>> predicate)
        {
            using (MailStoredgeEntities context = base.GetContext())
            {
                List<CustomerDataModel> customers = (from c in context.Customers
                                                     select new CustomerDataModel()
                                                     {
                                                         Id = c.Id,
                                                         Email = c.Email,
                                                         CustomerName = c.CustomerName,
                                                         CompanyName = c.CompanyName,
                                                         RegistrationDate = c.RegisterDate
                                                     }).Where(predicate).ToList<CustomerDataModel>();

                return customers;
            }
        }

        public List<CustomerDataModel> GetCustomers(string fromCompany)
        {
            using (MailStoredgeEntities context = base.GetContext())
            {
                List<CustomerDataModel> customers = (from c in context.Customers
                                                     where c.CompanyName == fromCompany
                                                     select new CustomerDataModel()
                                                     {
                                                         Id = c.Id,
                                                         Email = c.Email,
                                                         CustomerName = c.CustomerName,
                                                         CompanyName = c.CompanyName,
                                                         RegistrationDate = c.RegisterDate
                                                     }).ToList<CustomerDataModel>();

                return customers;
            }
        }

        public List<string> GetCompanyNames(string term)
        {
            using (MailStoredgeEntities context = base.GetContext())
            {
                List<string> customers = (from c in context.Customers
                                                     where c.CompanyName.StartsWith(term) 
                                                     select c.CompanyName).Distinct().ToList<string>();

                return customers;
            }
        }

        public void Add(CustomerDataModel record)
        {
            if (record == null)
                throw new ArgumentNullException("record", "Can't perform an add operation. Reason: data model is null.");

            using (var context = GetContext())
            {
                Customers customer = new Customers
                {
                    CustomerName = record.CustomerName,
                    CompanyName = record.CompanyName,
                    Email = record.Email,
                    RegisterDate = record.RegistrationDate,
                };
                
                context.AddToCustomers(customer);

                context.SaveChanges();

                record.Id = customer.Id;
            }
        }
    }
}
