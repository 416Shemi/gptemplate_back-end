using gptemplate.DAL;
using gptemplate.Models;
using gptemplate.Utlis.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace gptemplate.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ServiceController : Controller
    {
        public AppDbContext _context { get; }

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }
        // GET: ServiceController
        public ActionResult Index()
        {
            return View(_context.Services);
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service)
        {
            service.ImageUrl = service.Image.SaveFile("service");
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ServiceController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));
            Service s =_context.Services.Find(id);
            if (s == null) return NotFound();
            return View(s);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Service service)
        {
            if (id != service.Id) return BadRequest();
            Service s = _context.Services.Find(id);
            if (s == null) return NotFound();
            if (service.Image != null)
            {
                FileExtension.DeleteFile(Path.Combine("service",s.ImageUrl));
                s.ImageUrl = service.Image.SaveFile("service");
            }
            s.Link = service.Link;
            s.Title= service.Title;
            s.Description = service.Description;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ServiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
