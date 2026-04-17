using ContactManagementSystem.Models;
using ContactManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagementSystem.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        public IActionResult ShowContacts()
        {
            var contacts = _repo.GetAllContacts();
            return View(contacts);
        }

        public IActionResult GetContactById(int id)
        {
            var contact = _repo.GetContactById(id);
            return View(contact);
        }

        public IActionResult AddContact()
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            _repo.AddContact(contact);
            return RedirectToAction("ShowContacts");
        }

        public IActionResult EditContact(int id)
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();

            var contact = _repo.GetContactById(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult EditContact(ContactInfo contact)
        {
            _repo.UpdateContact(contact);
            return RedirectToAction("ShowContacts");
        }

        public IActionResult DeleteContact(int id)
        {
            var contact = _repo.GetContactById(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int ContactId)
        {
            _repo.DeleteContact(ContactId);
            return RedirectToAction("ShowContacts");
        }
    }
}

