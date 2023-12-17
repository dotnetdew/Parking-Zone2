﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parking_Zone.Data;
using Parking_Zone.Models;
using Parking_Zone.Repositories;
using Parking_Zone.Services;
using Parking_Zone.ViewModels.ParkingZone;

namespace Parking_Zone.Areas.Admin
{
    [Area("Admin")]
    public class ParkingZoneController : Controller
    {
        private readonly IParkingZoneService _parkingZoneService;
        public ParkingZoneController(IParkingZoneService parkingZoneService)
        {
            this._parkingZoneService = parkingZoneService;
        }

        // GET: Admin/ParkingZones
        public IActionResult Index()
        {
            var parkingZones = _parkingZoneService.GetAll();
            var vms = parkingZones.Select(x => new ParkingZoneDetailsVM(x));

            return View(vms);
        }

        // GET: Admin/ParkingZones/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingZone = _parkingZoneService.GetById(id);
            var vm = new ParkingZoneDetailsVM(parkingZone);
            if (vm == null)
            {
                return NotFound();
            }

            return View(vm);
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
        public IActionResult Create(ParkingZoneCreateVM VM)
        {
            if (VM is null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                var parkingZone = VM.MapToModel();
                _parkingZoneService.Insert(parkingZone);
                return RedirectToAction(nameof(Index));
            }
            return View(VM);
        }

        // GET: Admin/ParkingZones/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingZone = _parkingZoneService.GetById(id);

            if (parkingZone == null)
                return NotFound();

            var parkingZoneVM = new ParkingZoneEditVM(parkingZone);

            return View(parkingZoneVM);
        }

        //POST: Admin/ParkingZones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, ParkingZoneEditVM parkingZoneVM)
        {
            var parkingZone = _parkingZoneService.GetById(id);

            if (id != parkingZone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    parkingZoneVM.MapToModel(parkingZone);
                    _parkingZoneService.Update(parkingZone);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_parkingZoneService.GetById(id) is null)
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

            var parkingZone = _parkingZoneService.GetById(id);
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
            var parkingZone = _parkingZoneService.GetById(id);
            if (parkingZone != null)
            {
                _parkingZoneService.Delete(parkingZone);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
