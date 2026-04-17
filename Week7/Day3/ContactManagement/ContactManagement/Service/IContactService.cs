using ContactManagement.Models;

namespace ContactManagement.Service
{
    public interface IContactService
    {
        public List<Contact> GetAllContacts();
        public Contact GetContactById(int id);
        public void AddContact(Contact contact);

    }
}
