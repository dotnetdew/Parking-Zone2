﻿using Parking_Zone.Data;
using Parking_Zone.Models;
using Parking_Zone.Repositories;

namespace Parking_Zone.Repositories
{
    public class ParkingZoneRepository : GenericRepository<ParkingZone>, IParkingZoneRepository
    {
        public ParkingZoneRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
