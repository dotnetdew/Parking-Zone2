using Parking_Zone.Data;
using Parking_Zone.Models;
using Parking_Zone.Repositories;

namespace Parking_Zone.Services
{
    public class ParkingZoneService : Service<ParkingZone>, IParkingZoneService
    {
        private readonly IParkingZoneRepository _repository;
        private readonly ApplicationDbContext _context;
        public ParkingZoneService(IParkingZoneRepository repository, ApplicationDbContext context) : base(repository, context)
        {
            this._repository = repository;
            this._context = context;
        }
    }
}
