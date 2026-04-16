using System;
using System.Collections.Generic;
using System.Linq;
using BO;

namespace BlImplementation
{
    internal class CustomerImplementation : BlApi.ICustomer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public IEnumerable<Customer> GetList()
        {
            return _dal.Customer.ReadAll()
                .Select(c => new BO.Customer()
                {
                    id = c.Id,      // ב-DO זה Id גדול
                    name = c.Name,  // ב-DO זה Name גדול
                    address = c.Address,
                    phoneNumber = int.TryParse(c.Phone, out int p) ? p : 0
                });
        }

        public Customer Get(int id)
        {
            var c = _dal.Customer.Read(id);
            if (c == null)
                throw new BO.BLDoesNotExistException($"Customer with ID {id} does not exist");

            return new BO.Customer()
            {
                id = c.Id,
                name = c.Name,
                address = c.Address,
                phoneNumber = int.TryParse(c.Phone, out int p) ? p : 0
            };
        }

        public void Add(Customer customer)
        {
            if (customer.id <= 0)
                throw new BO.BLInvalidInputException("Invalid ID");

            try
            {
                // שימי לב: DO באותיות גדולות, ושדות ב-DAL באותיות גדולות
                _dal.Customer.Create(new Do.Customer()
                {
                    Id = customer.id,
                    Name = customer.name,
                    Address = customer.address,
                    Phone = customer.phoneNumber.ToString()
                });
            }
            catch (Exception ex)
            {
                throw new BO.BLAlreadyExistsException("Customer already exists", ex);
            }
        }

        public void Update(Customer customer)
        {
            try
            {
                _dal.Customer.Update(new Do.Customer()
                {
                    id = customer.id,
                    name = customer.name,
                    address = customer.address,
                    phoneNumber = customer.phoneNumber.ToString()
                });
            }
            catch (Exception ex)
            {
                throw new BO.BLDoesNotExistException("Customer not found", ex);
            }
        }

        public void Delete(int id)
        {
            try { _dal.Customer.Delete(id); }
            catch (Exception ex) { throw new BO.BLDoesNotExistException("Not found", ex); }
        }

        public bool ExistingCustomer(int id) => _dal.Customer.Read(id) != null;
    }
}