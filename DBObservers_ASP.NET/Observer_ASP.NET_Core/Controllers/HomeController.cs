using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Observer_ASP.NET_Core.Models;

namespace Observer_ASP.NET_Core.Controllers
{
    public class HomeController : Controller
    {
        private MobileContext _db;

        public HomeController(MobileContext context)
        {
            _db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Phones.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Phone phone)
        {
            _db.Phones.Add(phone);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Phone phone = await _db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Phone phone = await _db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Phone phone)
        {
            _db.Phones.Update(phone);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Phone phone = await _db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Phone phone = await _db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                {
                    _db.Phones.Remove(phone);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
