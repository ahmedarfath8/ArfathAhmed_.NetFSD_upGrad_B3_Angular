using ContactManagement.Models;

namespace ContactManagement.Service
{
    public class ContactService : IContactService
    {
        private static List<Contact> contacts = new List<Contact>() {    
            new Contact { ContactId = 1, FirstName = "Arfath", LastName = "Ahmed", CompanyName = "ABC Infotech", EmailId = "arfath@gmail.com", MobileNo = "9876543210", Designation = "Software Engineer" },
            new Contact { ContactId = 2, FirstName = "Rahul", LastName = "Sharma", CompanyName = "TCS", EmailId = "rahul@gmail.com", MobileNo = "9123456780", Designation = "Developer" },
            new Contact { ContactId = 3, FirstName = "Sneha", LastName = "Reddy", CompanyName = "Infosys", EmailId = "sneha@gmail.com", MobileNo = "9988776655", Designation = "Analyst" },
            new Contact { ContactId = 4, FirstName = "Karan", LastName = "Mehta", CompanyName = "Wipro", EmailId = "karan@gmail.com", MobileNo = "9012345678", Designation = "Tester" },
            new Contact { ContactId = 5, FirstName = "Priya", LastName = "Nair", CompanyName = "Accenture", EmailId = "priya@gmail.com", MobileNo = "9090909090", Designation = "Consultant" }
        };
        public List<Contact> GetAllContacts() {
        return contacts;
        }
        public Contact GetContactById(int id) { 
            return contacts.FirstOrDefault(x => x.ContactId == id);
        }
        public void AddContact(Contact contact) { 
            contacts.Add(contact);
        }

    }
}
