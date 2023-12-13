using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parking_Zone.Data;
using Parking_Zone.Models;
using Parking_Zone.Repositories;

namespace Parking_Zone.Areas.Admin
{
    [Area("Admin")]
    public class ParkingZoneController : Controller
    {
        private readonly IParkingZoneRepository _repository;
        public ParkingZoneController(IParkingZoneRepository repository)
        {
            this._repository = repository;
        }

        // GET: Admin/ParkingZones
        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Admin/ParkingZones/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingZone = _repository.GetById(id);
            if (parkingZone == null)
            {
                return NotFound();
            }

            return View(parkingZone);
        }

        // GET: Admin/ParkingZones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/ParkingZones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ParkingZone parkingZone)
        {
            if (ModelState.IsValid)
            {
                parkingZone.Id = Guid.NewGuid();
                _repository.Insert(parkingZone);
                return RedirectToAction(nameof(Index));
            }
            return View(parkingZone);
        }

        // GET: Admin/ParkingZones/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingZone = _repository.GetById(id);

            return View(parkingZone);
        }

        //POST: Admin/ParkingZones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ParkingZone parkingZone)
        {
            if (id != parkingZone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(parkingZone);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_repository.GetById(id) is null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parkingZone);
        }

        // GET: Admin/ParkingZones/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingZone = _repository.GetById(id);
            if (parkingZone == null)
            {
                return NotFound();
            }

            return View(parkingZone);
        }

        // POST: Admin/ParkingZones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var parkingZone = _repository.GetById(id);
            if (parkingZone != null)
            {
                _repository.Delete(parkingZone);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
