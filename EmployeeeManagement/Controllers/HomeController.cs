using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeeManagement.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using EmployeeeManagement.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace EmployeeeManagement.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _ihosting;
        private IEmployeeData _employeerepo;
        public HomeController(IEmployeeData employeerepo, IHostingEnvironment ihosting)
        {
            this._employeerepo = employeerepo;
            this._ihosting = ihosting;
        }
        [Authorize]
        public IActionResult EmployeeDetails(int id)
        {
            
            Employee E = _employeerepo.GetEmployee(id);
            return View(E);
            
        }
        [Authorize]
        public IActionResult AllDetails()
        {
            var data = _employeerepo.EmployeeDetails();
            return View(data);
            
        }
        [HttpGet]
        public IActionResult SignUP()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(EmployeeViewModel model)
        {
            //The data is coming in correct form or not
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core
                    string uploadsFolder = Path.Combine(_ihosting.WebRootPath, "images");
                    // To make sure the file name is unique we are appending a new
                    // GUID value and and an underscore to the file name
                    //Guid Create a hash format for file name
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    EmailId = model.EmailId,
                    Number = model.Number,
                    Department = model.Department,
                    // Store the file name in PhotoPath property of the employee object
                    // which gets saved to the Employees database table
                    Photo = uniqueFileName
                };

                _employeerepo.Add(newEmployee);
                return RedirectToAction("AllDetails", new { Id = newEmployee.Id });
            }

            return View();

            }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Employee employee = _employeerepo.GetEmployee(Id);
            EditEmployeeViewModel editEmployeeViewModel= new EditEmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                EmailId = employee.EmailId,
                Number = employee.Number,
                Department = employee.Department,
                PhotoPath = employee.Photo
            };
            return View(editEmployeeViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeerepo.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.EmailId = model.EmailId;
                employee.Number = model.Number;
                employee.Department = model.Department;

                if(model.Photo!=null)
                {
                    if (model.PhotoPath != null)
                    {
                        string filePath = Path.Combine(_ihosting.WebRootPath, "images", model.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.Photo = ProcessUploadedFile(model);
                }
                Employee updatedEmployee = _employeerepo.Update(employee);
                return RedirectToAction("AllDetails");
            }
            return View(model);
        }

        private string ProcessUploadedFile(EditEmployeeViewModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_ihosting.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
                return uniqueFileName;
        }

        public IActionResult Delete(int Id)
        {
            _employeerepo.Delete(Id);
            return RedirectToAction("AllDetails");

        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult AboutUs()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
