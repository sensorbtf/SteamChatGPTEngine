using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Zaj01.ViewModels;

namespace Zaj01.Controllers
{
    public class RegisterConferenceController : Controller
    {
        private static readonly IList<ConferenceUserViewModel> _registeredUsers = new List<ConferenceUserViewModel>();
        private readonly IWebHostEnvironment _hostEnvironment;

        public RegisterConferenceController(IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_registeredUsers);
        }

        [HttpPost]
        public IActionResult Register(ConferenceUserViewModel conferenceUserViewModel)
        {
            if (ModelState.IsValid)
            {

                string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "Photos");
                var photoName = $"{Guid.NewGuid()}.{Path.GetExtension(conferenceUserViewModel.Photo.FileName)}";
                string filePath = Path.Combine(uploadsFolder, photoName);

                using (var photo = System.IO.File.Create(filePath))
                {
                    conferenceUserViewModel.Photo.CopyTo(photo);
                    conferenceUserViewModel.PhotoPath = $"/Photos/{photoName}";
                }

                //save to database...

                _registeredUsers.Add(conferenceUserViewModel);
                TempData["userAdded"] = true;

                return RedirectToAction(nameof(Register));
            }

            return View(conferenceUserViewModel);
        }
        public IActionResult Register()
        {
            ViewBag.RegisteredUsers = _registeredUsers;
            return View();
        }
    }
}
