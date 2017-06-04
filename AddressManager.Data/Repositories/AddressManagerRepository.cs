using System;
using System.Linq;
using Demo.AddressManager;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Demo.AddressManager.Data
{
    public class AddressManagerRepository: IAddressManagerRepository
    {
        private readonly AddressManagerDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public AddressManagerRepository(AddressManagerDbContext context)
        {
            _context = context;
        }

        public bool Delete(IContact contact)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IContact> GetAllContacts()
        {
            return _context.Contacts.ToList();
        }

        public IEnumerable<IAddress> GetAllAddresses()
        {
            return _context.Addresses.ToList();
        }

        public IContact GetContact(long id)
        {
            return _context.Contacts.FirstOrDefault(c => c.Id == id);
        }

        public IContact GetContactWithAddresses(long id)
        {
            return _context.Contacts
                .Include(c => c.ContactAddresses)
                .ThenInclude(ca => ca.Address)
                .FirstOrDefault(c => c.Id == id);
        }

        public IAddress GetAddress(long id)
        {
            return _context.Addresses.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<IAddress> GetAddressesByContactId(long id)
        {
            return _context.ContactAddresses
                .Include(a => a.Address)
                .Where(ca => ca.ContactId == id)
                .Select(ca => ca.Address).ToList();

        }

        public void Create<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public bool Update(IContact contact)
        {
            throw new NotImplementedException();
        }
    }
}
