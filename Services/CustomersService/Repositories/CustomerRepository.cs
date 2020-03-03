using System;
using System.Collections.Generic;
using System.Linq;
using WebApiDataModel.GenericRepository;
using CustomersService.Entities;
using CustomersService.Contexts;
using CustomersBusiness.Helpers;

namespace CustomersService.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        #region Private member variables...

        private CustomerDbContext _context = null;
        private GenericRepository<Customer> _customerRepository;

        #endregion

        #region Public Repository Creation properties...

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public bool CustomerExists(int customerId)
        {
            return _context.Customers.Any(c => c.Id == customerId);
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == customerId);
        }

        public IQueryable<Customer> GetCustomers(IEnumerable<int> customerIds)
        {
            return _context.Customers.Where(c => customerIds.Contains(c.Id));
        }

        public int GetResultCount()
        {
            return _context.Customers.Count();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 1);
        }

        public IQueryable<Customer> GetCustomers(CustomersPagingParameters pagingParameters)
        {
            return _context.Customers
                .Where(c => c.Name.Contains(pagingParameters.Name ?? "")
                            && c.Address.Contains(pagingParameters.Address ?? "")
                            && c.Business.Contains(pagingParameters.Business ?? ""))
                .Skip(pagingParameters.PageSize * (pagingParameters.PageNumber - 1))
                .Take(pagingParameters.PageSize);
        }

        #endregion

        #region Public member methods...
        /// <summary>
        /// Construct
        /// </summary>
        public CustomerRepository(CustomerDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<Customer> GetCustomerRepository
        {
            get
            {
                if (this._customerRepository == null)
                    this._customerRepository = new GenericRepository<Customer>(_context);
                return _customerRepository;
            }
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~CustomerRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        


        #endregion
    }
}
