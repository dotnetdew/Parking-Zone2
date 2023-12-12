using Parking_Zone.Data;
using Parking_Zone.Models;

namespace Parking_Zone.Repositories
{
    public class ParkingZoneRepository : GenericRepository<ParkingZone>
    {
        public ParkingZoneRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
