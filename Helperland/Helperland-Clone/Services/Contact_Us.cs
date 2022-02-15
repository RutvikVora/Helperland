using Helperland_Clone.Data;
using Microsoft.AspNetCore.Hosting;
using Helperland_Clone.Models;
using Helperland_Clone.ViewModels;
using System;
using System.IO;

namespace Helperland_Clone.Services
{
    public class Contact_Us
    {
        private readonly HelperlandContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public Contact_Us(HelperlandContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public void Add(ContactUsViewModel contact)
        {
            ContactUs newcontact = new ContactUs()
            {
                Name = $"{contact.firstname} {contact.lastname}",
                PhoneNumber = contact.mono,
                Email = contact.email,
                Message = contact.msg,
                Subject = contact.subject,
                CreatedOn = DateTime.Now
            };
            string uniqueFilename;
            if (contact.File != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images", "ContactUsImages");
                uniqueFilename = Guid.NewGuid().ToString() + "_" + contact.File.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                newcontact.UploadFileName = uniqueFilename;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    contact.File.CopyTo(fileStream);
                }
            }
            context.ContactUs.Add(newcontact);
            context.SaveChanges();
        }
    }
}
