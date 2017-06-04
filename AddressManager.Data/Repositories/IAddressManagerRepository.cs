using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.AddressManager.Data
{
    public interface IAddressManagerRepository
    {
        void Create<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        IContact GetContact(long id);

        IContact GetContactWithAddresses(long id);

        IEnumerable<IContact> GetAllContacts();

        IEnumerable<IAddress> GetAddressesByContactId(long id);

        IEnumerable<IAddress> GetAllAddresses();

        IAddress GetAddress(long id);

        Task<bool> SaveChangesAsync();

        bool SaveChanges();
    }
}
