using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Observer_ASP.NET_Core_Current.Models;

namespace Observer_ASP.NET_Core_Current.Controllers
{
    public class HomeController : Controller
    {
        private EquipmentContext db;
        public HomeController(EquipmentContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Equipments.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Equipment equipment)
        {
            equipment.EquipmentType = new EquipmentType() {Name = equipment.EquipmentTypeString};
            db.Equipments.Add(equipment);
            db.EquipmentTypes.Add(equipment.EquipmentType);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id != null)
            {
                Equipment equipment = await db.Equipments.FirstOrDefaultAsync(p => p.Id == id);
                if (equipment != null)
                    return View(equipment);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                Equipment equipment = await db.Equipments.FirstOrDefaultAsync(p => p.Id == id);
                if (equipment != null)
                    return View(equipment);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Equipment equipment)
        {
            db.Equipments.Update(equipment);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(Guid? id)
        {
            if (id != null)
            {
                Equipment equipment = await db.Equipments.FirstOrDefaultAsync(p => p.Id == id);
                if (equipment != null)
                    return View(equipment);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                Equipment equipment = await db.Equipments.FirstOrDefaultAsync(p => p.Id == id);
                if (equipment != null)
                {
                    db.Equipments.Remove(equipment);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
