using ContactManagement.Models;
using ContactManagement.Service;
using Microsoft.AspNetCore.Mvc;


namespace ContactManagement.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            return View(_contactService.GetAllContacts());
        }
        [HttpGet]public IActionResult Create()
        {
            return View();
        }
        [HttpPost]public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
            _contactService.AddContact(contact);
            return RedirectToAction("Index");
            }
            ViewBag.Message="please check the details entered...";
            return View();
        }

        [HttpGet]public IActionResult GetById(int id)
        {
            if (ModelState.IsValid)
            {
            var contact = _contactService.GetContactById(id);
            return View(contact);
            }
            return RedirectToAction("Index");
        }





       
    }
}
