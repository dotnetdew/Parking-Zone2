﻿using Parking_Zone.Models;
namespace Parking_Zone.ViewModels.ParkingZone
{
    public class ParkingZoneListItemVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfEstablishment { get; set; }
        public string Description { get; set; }

        public ParkingZoneListItemVM MapTo(Models.ParkingZone zone)
        {
            return new ParkingZoneListItemVM
            {
                Id = zone.Id,
                Name = zone.Name,
                Address = zone.Address,
                DateOfEstablishment = zone.DateOfEstablishment,
                Description = zone.Description,
            };
        }
    }
}
